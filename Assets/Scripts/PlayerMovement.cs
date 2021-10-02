using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    

    public float playerSpeed= 500f;
    public float jumpForce = 300f;
    public Transform feetPos;
    public float overlapBoxSize = 0.5f;
    public float leftLimit = -6f;
    public float rightLimit =9f;
    public int keyCount;

    public BoxCollider2D collider2DVariable;
    public GameObject obstacleImage;
    public Text scoreText;
    private SpriteRenderer sp;
    private Rigidbody2D playerRb;
    bool jumpPressed = false;

    private float vertical;
    private float speed = 4f;
    private bool isLadder;
    private bool isClimbing;
    private bool isBoxPushing;
    private bool obstacleBool;

    [SerializeField]
    private Animator camAnimator;

    Animator animator;
    [SerializeField] private Rigidbody2D rb;

    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        playerRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Cursor.visible = false;
        obstacleImage.gameObject.SetActive(false);

    }

    private void Update()
    {
        Collider2D col = Physics2D.OverlapBox(feetPos.position, new Vector2(transform.localScale.x, overlapBoxSize), 0, LayerMask.GetMask("Ground"));
        if (Input.GetButtonDown("Jump")&& col)
        {
            jumpPressed = true;
        }

        vertical = Input.GetAxis("Vertical");

        if (isLadder && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
            animator.SetBool("isClimbing", true);
            transform.GetChild(2).GetChild(0).gameObject.SetActive(false);
        }
        scoreText.text =  keyCount.ToString()+ " / 7";

        if (keyCount==7)
        {
            collider2DVariable.gameObject.SetActive(false);
        }
        else
        {
           collider2DVariable.gameObject.SetActive(true);
        }

    }
    void FixedUpdate()
    {
        WalkScript();

        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
            if (vertical != 0)
            {
                animator.speed = 1;
            }
            else
            {
                animator.speed = 0;
            }
        }
        else
        {
            rb.gravityScale = 3f;
        }
    }
    void WalkScript()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        //playerRb.velocity=new Vector3(Time.deltaTime * horizontalInput * playerSpeed,playerRb.velocity.y);
        transform.Translate(new Vector3(Time.deltaTime * horizontalInput * playerSpeed * 0.02f, 0));

        if (jumpPressed)
        {
            playerRb.AddForce(new Vector3(0, jumpForce * Time.deltaTime), ForceMode2D.Impulse);
            jumpPressed = false;
        }

        animator.SetFloat("h_speed", horizontalInput);

        if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1, 1,1);
            animator.SetBool("isMoving", true);
        }
        else if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1,1,1);
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
        if (playerRb.transform.position.x<leftLimit)
        {
            playerRb.transform.position = new Vector3(leftLimit, playerRb.transform.position.y,transform.position.z);
        }


        if (playerRb.transform.position.x>rightLimit)
        {
            playerRb.transform.position = new Vector3(rightLimit, playerRb.transform.position.y,playerRb.transform.position.z);
        }
        
        

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            animator.SetBool("isBoxPushing", true);
        }
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
       

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
            animator.SetBool("isClimbing", false);
            
            transform.GetChild(2).GetChild(0).gameObject.SetActive(true);
            animator.speed = 1;
        }
        animator.SetBool("isBoxPushing", false);

    }

    private void OnCollisionEnter2D(Collision2D collisionCol)
    {
        if (collisionCol.gameObject.CompareTag("Obstacle")&& keyCount!=7)
        {
            Debug.Log("is working");
            obstacleImage.gameObject.SetActive(true);
        }
        else
        {
            obstacleImage.gameObject.SetActive(false);
        }


    }
    public void PlayerAudio()
    {
        GetComponent<AudioSource>().Play();
    }



}
