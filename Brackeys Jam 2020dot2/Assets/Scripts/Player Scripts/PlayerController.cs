using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // basic movement

    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;

    private bool facingRight = true;

    public bool isGrounded;
    
    public Transform groundCheck;
    public float checkRadius;

    public LayerMask whatIsGround;

    // coyote jump
    private float gRemember;
    public float gRememberT;

    // jump value
    public int eJumps;
    public int eJumpsV;

    // shooting

    public GameObject rightBullet;
    public GameObject leftBullet;

    public GameObject shootPos;

    public int ammo;

    public float cooldownBtwFire;

    public float baseCooldownBtwFire;

    private Bullets bullettt;

    public Animator anim;

    public GameObject sfx;


    void Start()
    {
        anim = GetComponent<Animator>();
        eJumps = eJumpsV;
        rb = GetComponent<Rigidbody2D>();
        bullettt = GetComponent<Bullets>();
        bullettt.bullets = ammo;
        bullettt.numberOfBullets = ammo;
    }

    void Update()
    {
        bullettt.bullets = ammo;

        if(Input.GetKeyDown(KeyCode.Space) && eJumps == 0 && (gRemember > 0)) 
        {
            anim.SetTrigger("takeOff");
            rb.velocity = Vector2.up * jumpForce;
            eJumps--;

        }

        if(isGrounded == true)
        {
            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isJumping", true);
        }

    }

    void FixedUpdate()
    {

        if(isGrounded == true)
        {
            eJumps = eJumpsV;
            gRemember = gRememberT;
        }
        gRemember -=Time.deltaTime;

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);


        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if(moveInput == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }

        // going right but facing left 
        if(facingRight == false && moveInput > 0)
        {
            Flip();
        }

        // going left but facing right
        if(facingRight == true && moveInput < 0)
        {
            Flip();
        }

        if(Input.GetKeyDown(KeyCode.Mouse0) && cooldownBtwFire <= 0)
        {
            
            if(facingRight == true && ammo > 0)
            {
                anim.SetTrigger("shoot");
                Instantiate(rightBullet, shootPos.transform.position, Quaternion.identity);
                Instantiate(sfx, shootPos.transform.position, Quaternion.identity);
                ammo = ammo - 1;
                cooldownBtwFire = baseCooldownBtwFire;
            }
            if(facingRight == false && ammo > 0)
            {
                anim.SetTrigger("shoot");
                Instantiate(leftBullet, shootPos.transform.position, Quaternion.identity);
                Instantiate(sfx, shootPos.transform.position, Quaternion.identity);
                ammo = ammo - 1;
                cooldownBtwFire = baseCooldownBtwFire;
            }
        }

        if(cooldownBtwFire > 0)
        {
            cooldownBtwFire -= Time.deltaTime;
        }
    }

    // changes the z value ( I think)
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
