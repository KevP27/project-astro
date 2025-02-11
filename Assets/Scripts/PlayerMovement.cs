using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static Player;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    public AudioSource boop;
    public AudioSource coin;

    public Player controller;

    public float runSpeed = 100f;

    float horizontalMove = 0f;

    bool jump = false;

    int scoreValue = 0;
    public Text score;

    public Text highScore;

    public float currentHeight;
    public float previousHeight = 0f;
    public float travel;

    //public Joystick joystick;

    private GameObject Bullet;
    public Transform FirePos;

    public Animator animator;
    private bool isMoving = false;
    private bool isJumping = false;

    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    private bool m_Grounded;            // Whether or not the player is grounded.
    public UnityEvent OnLandEvent;
    [SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
    [SerializeField] private Transform m_GroundCheck;                           // A position marking where to check if the player is grounded.
    public static event PlayerLanded OnPlayerLanded;

    //public AdsManager2 ads;

    void Start()
    {
        score.text = scoreValue.ToString();
        highScore.text = PlayerPrefs.GetInt("HighScore").ToString();



        //ads.HideBanner();
    }
    // Update is called once per frame
    void Update()
    {
        horizontalMove = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            horizontalMove = -runSpeed;
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontalMove = runSpeed;
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        }
        else
        {
            animator.SetFloat("Speed", 0f);
        }

        if (m_Grounded) {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                Shoot();
            }
        }

        currentHeight = transform.position.y;

        if (currentHeight < -50f)
        {
            SceneManager.LoadScene("Game Over 1");
        }

        if (Input.GetKeyDown(KeyCode.Delete))
        {
            PlayerPrefs.DeleteAll();
            highScore.text = "0";
        }
    }

    void Jump()
    {
        jump = true;
        animator.SetBool("isJumping", true);
    }

    void Shoot()
    {
        Instantiate(null, FirePos.position, FirePos.rotation);
    }

    public void onLanding()
    {
        animator.SetBool("isJumping", false);
    }
   
    void OnTriggerEnter2D(Collider2D Coins)
    {
        if(Coins.transform.CompareTag("Coin"))
        {
            Destroy(Coins.gameObject);
            coin.Play();
            scoreValue++;
            score.text = scoreValue.ToString();
        }
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;

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
}
