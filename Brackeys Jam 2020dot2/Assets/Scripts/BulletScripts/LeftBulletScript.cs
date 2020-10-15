using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftBulletScript : MonoBehaviour
{

    public float speed;
    public float destructionLeftTime;

    public ParticleSystem particles;

    private GameObject thisGameObject;

    public bool shouldInsPar;

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        thisGameObject = this.gameObject;
        Destroy(gameObject, destructionLeftTime);
    }

    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Walls")
        {
            sr.enabled = false;
            Instantiate(particles, thisGameObject.transform.position, Quaternion.identity);
            Destroy(gameObject, 0.2f);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Walls")
        {
            sr.enabled = false;
            Instantiate(particles, thisGameObject.transform.position, Quaternion.identity);
            Destroy(gameObject, 0.2f);
        }
    }

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if(destructionLeftTime > 0.05f)
        {
            destructionLeftTime -= Time.deltaTime;
        }
        else 
        {
            if(shouldInsPar == true)
            {
                Instantiate(particles, thisGameObject.transform.position, Quaternion.identity);
            }
        }
    }
}
