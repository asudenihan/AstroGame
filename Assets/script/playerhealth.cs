using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerhealth : MonoBehaviour
{
    public int maxHealth;

    public void TakeDamage(int BulletDamage)
    {

        maxHealth -= BulletDamage;

    }

    void Update()
    {

        if (maxHealth <= 0)
        {

            Destroy(gameObject);

        }

    }


}
