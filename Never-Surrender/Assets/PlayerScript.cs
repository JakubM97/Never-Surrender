using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Animator animator;
    public float speed;
    public float jumpForce;
    private float moveInput;
    Vector2 velTemp;
    public Rigidbody2D rb;
    public AudioSource audio;
    public AudioClip audioClip;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public int extraJumpsValue;
    private bool slideCollide = false;
    private double slideSpeed = 0;
    private int animationIndex;
    private int extraJumps;

    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(moveInput));


        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
        
    }

    private void Update()
    {
        StepSound();
        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsFalling", false);
            if(slideCollide == true)
            {
                if(facingRight == true)
                {
                    rb.AddForce(Vector2.right * (float)slideSpeed * (Math.Abs(rb.velocity.x)+10));
                }else
                {
                    rb.AddForce(Vector2.left * (float)slideSpeed * (Math.Abs(rb.velocity.x) + 10));

                }
                
            }
            if(slideCollide == true && slideSpeed >= 0.2)
            {
                slideSpeed -= 0.2;
            }
            if(slideCollide == true && slideSpeed <= 0.2 && moveInput != 0 )
            {
                slideSpeed = 20;
            }

        }
        else
        {
            animator.SetBool("IsFalling", true);
        }
        if((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
            animator.SetFloat("Speed", 0);
            animator.SetBool("IsJumping", true);
        } else if((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
            animator.SetFloat("Speed", 0);
            animator.SetBool("IsJumping", true);
        }
    }

    void StepSound()
    {
        animationIndex = ((int)(animator.GetCurrentAnimatorStateInfo(0).normalizedTime * (17))) % 17;
        
        if (isGrounded && (animationIndex == 2 || animationIndex == 9 || animationIndex == 16) && animator.GetFloat("Speed") > 0 && !audio.isPlaying)
        {
            audio.PlayOneShot(audioClip);
        }
    }

    void Flip()
    {

        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Slow")
        {
            this.speed -= 10;
            this.jumpForce -= 15;
        }
        if (collision.tag == "Slide")
        {
            velTemp = rb.velocity;
            slideSpeed = 20;
            slideCollide = true;
            speed -= 15;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Slow")
        {
            speed += 10;
            jumpForce += 15;
        }
        if (collision.tag == "Slide")
        {
            slideSpeed = 0;
            slideCollide = false;
            speed += 15;
        }
    }

}
