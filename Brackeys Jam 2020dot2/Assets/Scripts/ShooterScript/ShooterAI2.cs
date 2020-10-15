using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterAI2 : MonoBehaviour
{

    // optimazation (or trying to)

    private float dist;
    
    private GameObject thisThing;
    private GameObject player;

    // anim

    private Animator anim;

    // attack variables

    public GameObject bulletRight;
    public GameObject bulletLeft;

    public GameObject attackPos;

    public float defaultValueCooldownAttack;
    public float cooldownAttack;

    public bool facingRight;

    public bool isAlive;

    // destruction time

    public float dTime;

    // sfx

    public GameObject explosionSFX;

    public GameObject laserSFX;

    public bool shouldPlaySound;

    public bool hasntPlayedSoundYet;

    // auto explosive turret

    public float autoExplosiveTime;

    public bool shouldEventualyExplode;

    private bool shouldExplode;

    // bug

    private BoxCollider2D bc;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        thisThing = this.gameObject;
        anim = GetComponent<Animator>();
        bc = GetComponent<BoxCollider2D>();
        hasntPlayedSoundYet = true;
        shouldPlaySound = false;
        isAlive = true;
    }
    
    void Update ()
    {
        dist = Vector2.Distance(player.transform.position, thisThing.transform.position);

        if(isAlive == true && dist < 30)
        {
            if(cooldownAttack < 0.1)
            {
                anim.SetTrigger("ShouldShoot");
            }
           // attack thing
           if(facingRight == true && cooldownAttack <= 0)
           {
                Instantiate(laserSFX,attackPos.transform.position, Quaternion.identity);
                Instantiate(bulletRight, attackPos.transform.position, Quaternion.identity);
                cooldownAttack = defaultValueCooldownAttack;
           }

           if(facingRight == false && cooldownAttack <= 0)
           {
               Instantiate(laserSFX,attackPos.transform.position, Quaternion.identity);
               Instantiate(bulletLeft, attackPos.transform.position, Quaternion.identity);
               cooldownAttack = defaultValueCooldownAttack;
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
            if(shouldEventualyExplode == false)
            {
                bc.enabled = false;
            }
            Destroy(gameObject, dTime);
        }

        if(shouldPlaySound == true)
        {
            shouldPlaySound = false;
            anim.SetBool("isDead", true);
            if(hasntPlayedSoundYet == true)
            {
                hasntPlayedSoundYet = false;
                Instantiate(explosionSFX,attackPos.transform.position, Quaternion.identity);
            }
        }
    }
}
