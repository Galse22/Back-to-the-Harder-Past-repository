using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSceneManagement : MonoBehaviour
{

    // health

    public float health;
    public float maxHealth;

    // change scene stuff
    
    private bool hasntPlayedSoundYet;

    public float changeSceneTime;
    public ParticleSystem particles;
    public GameObject cristalSound;
    public GameObject thisGO;

    private SpriteRenderer sr;

    private BoxCollider2D bc;

    // change level

    public string level; 

    // animation

    private Animator anim;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();

        anim = GetComponent<Animator>();

        thisGO = this.gameObject;
        health = maxHealth;
        hasntPlayedSoundYet = true;
    }

    void Update()
    {
        anim.SetFloat("Health", health);
        if(health <= 0)
        {
            CinemachineShake.Instance.ShakeCamera(30f, .1f);
            bc.enabled = false;
            sr.enabled = false;
            changeSceneTime -= Time.deltaTime;
            if(hasntPlayedSoundYet == true)
            {
                hasntPlayedSoundYet = false;
                Instantiate(cristalSound, thisGO.transform.position, Quaternion.identity);
                Instantiate(particles, thisGO.transform.position, Quaternion.identity);
            }
        }

        if(changeSceneTime <= 0)
        {
            SceneManager.LoadScene(level);
        }
    }
}
