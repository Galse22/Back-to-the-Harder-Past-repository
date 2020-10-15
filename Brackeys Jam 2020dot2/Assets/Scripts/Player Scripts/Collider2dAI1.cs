using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider2dAI1 : MonoBehaviour
{
    private CollisionToThePlayer cPlayer;

    public GameObject test;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CanAttackTag")
        {
            cPlayer = collision.gameObject.GetComponent<CollisionToThePlayer>();
            test = collision.gameObject;
            cPlayer.canAttack = true;
            cPlayer.shouldWalk = false;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CanAttackTag")
        {
            cPlayer = collision.gameObject.GetComponent<CollisionToThePlayer>();
            test = collision.gameObject;
            cPlayer.canAttack = true;
            cPlayer.shouldWalk = false;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CanAttackTag")
        {
            cPlayer.shouldWalk = true;
        }
    }
}
