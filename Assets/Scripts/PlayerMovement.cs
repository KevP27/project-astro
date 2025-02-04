using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public Joystick joystick;

    public GameObject Bullet;
    public Transform FirePos;

    public Animator animator;
    private bool isMoving = false;
    private bool isJumping = false;

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
        if (joystick.Horizontal >= .1f)
        {
            horizontalMove = runSpeed;

            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        }

        else if (joystick.Horizontal <= -.1f)
        {
            horizontalMove = -runSpeed;

            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        }

        else
        {
            horizontalMove = 0f;
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        }

        currentHeight = transform.position.y;

        if (currentHeight < -50f)
        {
            SceneManager.LoadScene("Game Over 1");
            //ads.ShowBanner();
        }

        if (Input.GetKeyDown("delete"))
        {
            PlayerPrefs.DeleteAll();
            highScore.text = "0";
        }
    }

    public void Jump()
    {
        jump = true;

        animator.SetBool("isJumping", true);
        animator.SetFloat("Speed", 0f);
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
    }
}
