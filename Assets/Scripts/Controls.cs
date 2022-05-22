using UnityEngine;
using System. Collections;
using UnityEngine.SceneManagement;
using System;
using System.Collections.Generic;
using UnityEngine.UI;


public class Controls : MonoBehaviour {
    public Rigidbody2D rb;
    public float movespeed;
    public float jumpheight;
    public bool moveright;
    public bool moveleft;
    public bool jump;
    public int pilskes;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool onGround;
    private Animator anim;
    public GameObject  gameOverPanel;
    public int countdownTime;
    public bool gamePlaying;
    public static Controls instance;
	public GameObject hudContainer;
    public GameObject uiContainer;
    public GameObject BackgroundMusic;
	public Text timeCounter;
    public Text countdownText;
	private float startTime, elapsedTime;
    TimeSpan timePlaying;

    // Use this for initialization
		void Start() 
	{
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        gamePlaying = false;

        StartCoroutine(CountDownToStart());
	}

    void FixedUpdate()
    {
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        
    }
	private void Awake()
	{
		instance = this;
	}
    // Update is called once per frame
    void Update () {

        if (pilskes == 24)
        {
            EndGame();
        }

        if (rb.velocity.x != 0 && onGround)
        {
            anim.SetBool("Walking", true);
            anim.SetBool("Jumping", false);
        } else
        {
            anim.SetBool("Walking", false);
            anim.SetBool("Jumping", true);
        }

        if (!onGround)
        {
            anim.SetBool("Jumping", true);
        }else
        {
            anim.SetBool("Jumping", false);
        }
        if (gamePlaying)
        {
            elapsedTime = Time.time - startTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);

            string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
            timeCounter.text = timePlayingStr;
        }





        if (Input.GetKey(KeyCode.LeftArrow) && gamePlaying)
        {
            rb.velocity = new Vector2(-movespeed, rb.velocity.y);

        }
        if (Input.GetKey(KeyCode.RightArrow) && gamePlaying)
        {
            rb.velocity = new Vector2(movespeed, rb.velocity.y);

        }

        if (Input.GetKey(KeyCode.Space) && gamePlaying)
        {
            if (onGround)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpheight);
            }
        }

        if (jump && gamePlaying)
        {
            if (onGround)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpheight);
            }
            jump = false;
        }

        if (moveright && gamePlaying)
        {
            rb.velocity = new Vector2(movespeed, rb.velocity.y);
        }
        if (moveleft && gamePlaying)
        {
            rb.velocity = new Vector2(-movespeed, rb.velocity.y);
        }

    }
	
	private void BeginGame()
	{
        gamePlaying = true;
		startTime = Time.time;
	}
    private void EndGame()
	{
        gamePlaying = false;
		ShowGameOverScreen();
	}
	private void ShowGameOverScreen()
	{
		gameOverPanel.SetActive(true);
        hudContainer.SetActive(false);
        uiContainer.SetActive(false);
        BackgroundMusic.SetActive(false);
        string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
        gameOverPanel.transform.Find("FinalTimeText").GetComponent<Text>().text = timePlayingStr;
    }

    IEnumerator CountDownToStart()
    {
        while (countdownTime > 0)
        {
            countdownText.text = countdownTime.ToString();
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }
        BeginGame();
        countdownText.text = "GO!";

        yield return new WaitForSeconds(1f);

        countdownText.gameObject.SetActive(false);
    }
}

