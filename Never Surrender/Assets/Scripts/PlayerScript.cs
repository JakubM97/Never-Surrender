using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Config;
using static Collision;
using static ConsoleScript;

public class PlayerScript : MonoBehaviour
{
    public Animator animator;
    public float speed;
    public float jumpForce = Config.jumpForce;
    private float moveInput;
    public Rigidbody2D rb;
    public AudioSource audio;
    public AudioClip audioClip;

    private bool facingRight = true;
    float slideForce;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public int extraJumpsValue;
    private bool slideCollide = false;
    private int animationIndex;
    private int extraJumps;
    private AreaEffector2D AE;
    private bool inLava;
    public Image screenToHotWarning;
    public static Color color = new Vector4(1, 1, 1, 0);
    private float lastVelocity = 0;
    private GameObject camera;
    public GameObject dustEffect;
    private bool dustBool = false;
    public static int deathCount;
    public static int deathBySaw;
    public static int deathBySpike;
    public static int deathByBullet;
    public static int deathByTesla;
    public static int deathByLava;
    public static int deathBySlime;

    void Start()
    {
        camera = GameObject.Find("Main Camera");
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        deathCount = PlayerPrefs.GetInt("Death");
        deathBySaw = PlayerPrefs.GetInt("DeathBySaw");
        deathBySpike = PlayerPrefs.GetInt("DeathBySpike");
        deathByBullet = PlayerPrefs.GetInt("DeathByBullet");
        deathByTesla = PlayerPrefs.GetInt("DeathByTesla");
        deathByLava = PlayerPrefs.GetInt("DeathByLava");
        deathBySlime = PlayerPrefs.GetInt("DeathBySlime");
    }

    private void FixedUpdate()
    {
        if (!ConsoleScript.noclip)
        {
            rb.gravityScale = 7.4f;
            foreach (Collider2D c in rb.gameObject.GetComponents<Collider2D>())
            {
                c.enabled = true;
            }
            if (rb.velocity.y < lastVelocity)
            {
                lastVelocity = rb.velocity.y;
            }
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
            if (GameObject.Find("SavedGame").GetComponent<SavedData>().gameOver == false)
            {
                moveInput = Input.GetAxis("Horizontal");
                rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
                animator.SetFloat("Speed", Mathf.Abs(moveInput));
            }
            else
            {
                rb.velocity = new Vector2(0, 0);
            }
        }else if(ConsoleScript.noclip)
        {

            rb.gravityScale = 0f;
            foreach (Collider2D c in rb.gameObject.GetComponents<Collider2D>())
            {
                c.enabled = false;
            }
            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                this.gameObject.transform.position = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 1);
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                this.gameObject.transform.position = new Vector2(this.gameObject.transform.position.x - 1, this.gameObject.transform.position.y);
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                this.gameObject.transform.position = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y - 1);
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                this.gameObject.transform.position = new Vector2(this.gameObject.transform.position.x + 1, this.gameObject.transform.position.y);
            }
        }
        else
        {
            rb.gravityScale = 7.4f;
        }


        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
        if(inLava)
        {
            if (color.a < 0.7f)
            {
                Debug.Log(color.a);
                screenToHotWarning.color = color;
                color = new Vector4(1, 1, 1, color.a + 0.005f);
            }
        }else
        {
            if (color.a > 0)
            {
                screenToHotWarning.color = color;
                color = new Vector4(1, 1, 1, color.a - 0.02f);
            }
        }
        

    }

    private void Update()
    {
        if (GameObject.Find("SavedGame").GetComponent<SavedData>().gameOver == false && !ConsoleScript.noclip)
        {
            StepSound();
            if (isGrounded == true)
            {
                extraJumps = extraJumpsValue;
                animator.SetBool("IsJumping", false);
                animator.SetBool("IsFalling", false);
                if(lastVelocity < -70)
                {
                    StartCoroutine(ShakeCamera(.15f, .2f));
                    lastVelocity = 0;
                }
                if (dustBool)
                {
                    Instantiate(dustEffect, groundCheck.position, Quaternion.identity);
                    dustBool = false;
                }
            }
            else
            {
                animator.SetBool("IsFalling", true);
                dustBool = true;
            }
            if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && extraJumps > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                extraJumps--;
                animator.SetFloat("Speed", 0);
                animator.SetBool("IsJumping", true);
            }
            else if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && extraJumps == 0 && isGrounded == true)
            {
                rb.velocity = Vector2.up * jumpForce;
                animator.SetFloat("Speed", 0);
                animator.SetBool("IsJumping", true);
            }
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }
    }

    IEnumerator ShakeCamera(float duration, float magnitude)
    {
        Vector3 originalPos = camera.transform.localPosition;

        float elapsed = 0.0f;

        while(elapsed < duration)
        {
            float x = UnityEngine.Random.Range(-1f, 1f) * magnitude;
            float y = UnityEngine.Random.Range(-1f, 1f) * magnitude;

            camera.transform.localPosition = new Vector3(x, y, camera.transform.position.z);
            elapsed += Time.deltaTime;
            yield return null;
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
        if (collision.tag == "Lava")
        {
            inLava = true;
            rb.gravityScale = 0.5f;
            jumpForce = 8.0f;
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y / 2);
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
            slideCollide = false;
        }
        if (collision.tag == "Lava")
        {
            inLava = false;
            rb.gravityScale = 7.4f;
            jumpForce = Config.jumpForce;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.tag == "Slide")
        {
            if (moveInput != 0)
            {
                slideForce = 400.0f;
            }
            if (moveInput > -0.8 && moveInput < 0.8 && rb.velocity.x != 0)
            {
                collision.GetComponent<AreaEffector2D>().forceMagnitude = slideForce;
                if (rb.velocity.x > 5)
                {
                    collision.GetComponent<AreaEffector2D>().forceAngle = 0;
                }else if (rb.velocity.x < -5)
                {
                    collision.GetComponent<AreaEffector2D>().forceAngle = 180;
                }
            }
            else if (moveInput != 0 && rb.velocity.x != 0)
            {
                collision.GetComponent<AreaEffector2D>().forceMagnitude = slideForce - 50;
                if (moveInput < -0.8)
                {
                    collision.GetComponent<AreaEffector2D>().forceAngle = 0;
                }
                else if (moveInput > 0.8)
                {
                    collision.GetComponent<AreaEffector2D>().forceAngle = 180;
                }
                
            }
            if (slideForce > 0)
            {
                slideForce -= 5f;
            }
            if (rb.velocity.x == 0)
            {
                collision.GetComponent<AreaEffector2D>().forceMagnitude = 0;
            }
            
        }

    }

}
