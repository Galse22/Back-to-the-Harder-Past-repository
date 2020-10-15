using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy3 : MonoBehaviour
{

    private ShooterAI2 sAI2;
    private bool sPsBool;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy2")
        {
            sAI2 = collision.gameObject.GetComponent<ShooterAI2>();
            sAI2.isAlive = false;
            sPsBool = true;
        }
    }

    void Update()
    {
        if(sPsBool == true)
        {
            sAI2.shouldPlaySound = true;
            sPsBool = false;
        }
    }
}
