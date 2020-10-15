using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionToThePlayer : MonoBehaviour
{
    public GameObject parentEnemyScript;

    private PatrolScript pScript;

    public bool canAttack;

    public bool shouldWalk;

    void Start()
    {
        canAttack = false;
        shouldWalk = true;
        parentEnemyScript = gameObject.transform.parent.gameObject;
        pScript = parentEnemyScript.GetComponent<PatrolScript>();
    }

    void Update()
    {
        if(canAttack == true)
        {
            pScript.isSupposedToAttack = true;
            canAttack = false;
        }

        if(shouldWalk == false)
        {
            pScript.sWalk = false;
        }
    }
}
