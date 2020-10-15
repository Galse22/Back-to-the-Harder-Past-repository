using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullets : MonoBehaviour
{
    public int bullets;
    public int numberOfBullets;

    public Image[] b;
    public Sprite bulletWithBullet;
    public Sprite noBullet;

    void Update()
    {

        if(bullets > numberOfBullets)
        {
            bullets = numberOfBullets;
        }
        for (int i = 0; i < b.Length; i++)
        {
            if(i < bullets)
            {
                b[i].sprite = bulletWithBullet;
            }
            else
            {
                b[i].sprite = noBullet;
            }


            if(i < numberOfBullets)
            {
                b[i].enabled = true;
            }
            else
            {
                b[i].enabled = false;
            }
        }
    }
}
