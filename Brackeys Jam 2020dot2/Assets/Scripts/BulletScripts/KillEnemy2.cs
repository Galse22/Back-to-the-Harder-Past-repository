using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy2 : MonoBehaviour
{
    private PatrolScript pScript;

    public GameObject test;

    public bool sPsBool = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            pScript = collision.gameObject.GetComponent<PatrolScript>();
            test = collision.gameObject;
            pScript.isAlive = false;
            sPsBool = true;
        }
    }

    void Update()
    {
        if(sPsBool == true)
        {
            pScript.shouldPlaySound = true;
            sPsBool = false;
        }
    }
}
