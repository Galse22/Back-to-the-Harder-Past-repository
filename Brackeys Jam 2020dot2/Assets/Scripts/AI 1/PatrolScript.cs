using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolScript : MonoBehaviour
{
    // optimazation (or trying to)

    private float dist;

    private GameObject thisThing;
    private GameObject player;

    // walk
    public float speed;
    public float distance;

    public bool movingRight;
    public Transform groundDetection;

    // anim

    private Animator anim;

    // attack variables

    public bool sWalk;

    public GameObject bulletRight;
    public GameObject bulletLeft;

    public GameObject attackPos;
    public bool isSupposedToAttack;

    public float defaultValueCooldownAttack;
    private float cooldownAttack;

    public bool isAlive;

    // destruction time

    public float dTime;

    // sfx

    public GameObject explosionSFX;

    public GameObject laserSFX;

    public bool shouldPlaySound;

    private bool hasntPlayedSoundYet;

    // auto explode

    public float autoExplosiveTime;

    public bool shouldEventualyExplode;

    private bool shouldExplode;

    // bugs

    private BoxCollider2D bc;

    //private float tesst;

    //public GameObject who;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        thisThing = this.gameObject;
        anim = GetComponent<Animator>();
        bc = GetComponent<BoxCollider2D>();
        isSupposedToAttack = false;
        shouldPlaySound = false;
        sWalk = true;
        isAlive = true;
        hasntPlayedSoundYet = true;
    }

    //void OnTriggerEnter2D(Collider2D col)
    //{
        
        //if (col.gameObject.CompareTag("Dead2"))
        //{
            //who = col.gameObject;
            //tesst = Vector2.Distance(who.transform.position, thisThing.transform.position);
            //Debug.Log("hit" + who + "at" + tesst + "m");
            //isAlive = false;
        //}
    //}

    
    void Update ()
    {

        dist = Vector2.Distance(player.transform.position, thisThing.transform.position);

        if(isAlive == true && dist < 30)
        {
            if(sWalk == true)
            {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            }

        

            RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
            if (groundInfo.collider == false)
            {
            if(movingRight == true)
            {
                // animation
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else if(movingRight == false)
            {
                // animation
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
           }

           // attack thing
           if(isSupposedToAttack == true && movingRight == true && cooldownAttack <= 0)
           {
               Instantiate(laserSFX,attackPos.transform.position, Quaternion.identity);
               Instantiate(bulletRight, attackPos.transform.position, Quaternion.identity);
               isSupposedToAttack = false;
               cooldownAttack = defaultValueCooldownAttack;
               sWalk = true;
           }

           if(isSupposedToAttack == true && movingRight == false && cooldownAttack <= 0)
           {
               Instantiate(laserSFX,attackPos.transform.position, Quaternion.identity);
               Instantiate(bulletLeft, attackPos.transform.position, Quaternion.identity);
               isSupposedToAttack = false;
               cooldownAttack = defaultValueCooldownAttack;
               sWalk = true;
           }

           if(cooldownAttack > 0)
          {
              cooldownAttack -= Time.deltaTime;
          }
        }

        autoExplosiveTime -= Time.deltaTime;

        if(autoExplosiveTime <= 0)
        {
            shouldExplode = true;
        }

        if(shouldEventualyExplode == true && shouldExplode == true)
        {
            shouldExplode = false;
            isAlive = false;
            shouldPlaySound = true;
        }

        if(isAlive == false)
        {
            anim.SetBool("isDead", true);
            bc.enabled = false;
            Destroy(gameObject, dTime);
        }

        if(shouldPlaySound == true)
        {
            shouldPlaySound = false;
            if(hasntPlayedSoundYet == true)
            {
                hasntPlayedSoundYet = false;
                Instantiate(explosionSFX,attackPos.transform.position, Quaternion.identity);
            }
        }
    }
}
