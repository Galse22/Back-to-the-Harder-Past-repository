using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveKill : MonoBehaviour
{
    public GameObject test;
    private HealthSceneManagement hSm;

    private HealthStat hS;
    public float dmgPlayerBullet;
    public GameObject hSgo;

    public bool thisBullet;

    private SpriteRenderer sr;

    public GameObject particlesGo;

    private GameObject thisGO;


    void Start()
    {
        hSgo =  GameObject.FindGameObjectWithTag("HealthStats");
        hS = hSgo.GetComponent<HealthStat>();
        sr = GetComponent<SpriteRenderer>();
        thisGO = this.gameObject;
        dmgPlayerBullet = hS.dmgPb;
        thisBullet = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cristal")
        {
            test = collision.gameObject;
            hSm = collision.gameObject.GetComponent<HealthSceneManagement>();
            if(thisBullet == true)
            {
                sr.enabled = false;
                thisBullet = false;
                hSm.health -= dmgPlayerBullet;
                Instantiate(particlesGo, thisGO.transform.position, Quaternion.identity);
                Destroy(thisGO, 0.2f);
            }
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cristal")
        {
            test = collision.gameObject;
            hSm = collision.gameObject.GetComponent<HealthSceneManagement>();
            if(thisBullet == true)
            {
                sr.enabled = false;
                thisBullet = false;
                hSm.health -= dmgPlayerBullet;
                Instantiate(particlesGo, thisGO.transform.position, Quaternion.identity);
                Destroy(thisGO, 0.2f);
            }
        }
    }
}
