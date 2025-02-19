using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System.Collections;

public class Player : MonoBehaviour
{
	[SerializeField] private float m_JumpForce = 400f;                          // Amount of force added when the player jumps.
	[Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;          // Amount of maxSpeed applied to crouching movement. 1 = 100%
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement
	[SerializeField] private bool m_AirControl = false;                         // Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
	[SerializeField] private Transform m_GroundCheck;                           // A position marking where to check if the player is grounded.
	[SerializeField] private Transform m_CeilingCheck;                          // A position marking where to check for ceilings
	[SerializeField] private Collider2D m_CrouchDisableCollider;                // A collider that will be disabled when crouching

    [SerializeField] private GameObject pause;
    [SerializeField] private GameObject coin;
    [SerializeField] private GameObject watermelon;
    [SerializeField] private GameObject healthbar;


    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	private bool m_Grounded;            // Whether or not the player is grounded.
	const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  // For determining which way the player is currently facing.
	private Vector3 m_Velocity = Vector3.zero;

	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	public BoolEvent OnCrouchEvent;
	private bool m_wasCrouching = false;

	public AudioSource jumpSound;

	public float maxHealth = 100;
	public float currentHealth;

	public HealthBar1 healthBar;

	public AudioSource Laser;

    public delegate void PlayerLanded();
    public static event PlayerLanded OnPlayerLanded;

    void Start()
    {
        pause.SetActive(false);
        coin.SetActive(false);
        watermelon.SetActive(false);
        healthbar.SetActive(false);
        GetComponent<PlayerMovement>().enabled = false;

        currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);

        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        if (sceneName == "Game 1")
        {
            m_Rigidbody2D.gravityScale = 0.8f;
            StartCoroutine(FallingFromSky());
        }
        else if (sceneName == "Level 0.1")
        {
            m_Rigidbody2D.gravityScale = 1f;
            StartCoroutine(FallingFromSky2());
        }
        else if (sceneName == "Level 1")
        {
            m_Rigidbody2D.gravityScale = 1f;
            StartCoroutine(FallingFromSky2());
        }
    }

    public void Update()
    {
        if (m_Grounded)
		{
            pause.SetActive(true);
            coin.SetActive(true);
            watermelon.SetActive(true);
            healthbar.SetActive(true);
			GetComponent<PlayerMovement>().enabled = true;
        }
    }

    public IEnumerator FallingFromSky()
    {
        yield return new WaitForSeconds(5);
		m_AirControl = true;
		m_Rigidbody2D.gravityScale = 3;
    }
    public IEnumerator FallingFromSky2()
    {
        yield return new WaitForSeconds(2);
        m_AirControl = true;
        m_Rigidbody2D.gravityScale = 3;
    }

    public void TakeDamage(float damage)
    {
		currentHealth -= damage;
		healthBar.SetHealth(currentHealth);

		if (currentHealth <= 0)
        {
			Die();
        }
    }

	void Die()
    {
		Laser.Stop();
		Destroy(gameObject);
		SceneManager.LoadScene("Game Over 1");
	}

	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();

		if (OnCrouchEvent == null)
			OnCrouchEvent = new BoolEvent();
	}

	private void FixedUpdate()
	{
		bool wasGrounded = m_Grounded;
		m_Grounded = false;

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				m_Grounded = true;
				if (!wasGrounded)
                    OnLandEvent.Invoke();
					OnPlayerLanded?.Invoke();
            }
		}
	}


	public void Move(float move, bool crouch, bool jump)
	{
		// If crouching, check to see if the character can stand up
		if (!crouch)
		{
			// If the character has a ceiling preventing them from standing up, keep them crouching
			if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
			{
				crouch = true;
			}
		}

		//only control the player if grounded or airControl is turned on
		if (m_Grounded || m_AirControl)
		{

			// If crouching
			if (crouch)
			{
				if (!m_wasCrouching)
				{
					m_wasCrouching = true;
					OnCrouchEvent.Invoke(true);
				}

				// Reduce the speed by the crouchSpeed multiplier
				move *= m_CrouchSpeed;

				// Disable one of the colliders when crouching
				if (m_CrouchDisableCollider != null)
					m_CrouchDisableCollider.enabled = false;
			}
			else
			{
				// Enable the collider when not crouching
				if (m_CrouchDisableCollider != null)
					m_CrouchDisableCollider.enabled = true;

				if (m_wasCrouching)
				{
					m_wasCrouching = false;
					OnCrouchEvent.Invoke(false);
				}
			}

			// Move the character by finding the target velocity
			Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
			// And then smoothing it out and applying it to the character
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

			// If the input is moving the player right and the player is facing left...
			if (move > 0 && !m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (move < 0 && m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
		}
		// If the player should jump...
		if (m_Grounded && jump)
		{
			jumpSound.Play();
			// Add a vertical force to the player.
			m_Grounded = false;
			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
		}
	}


	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		transform.Rotate (0f, -180f, 0f);
	}
}