using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3;
    public int bulletDamage = 1;

    void Awake()
    {
        Destroy(gameObject, life);
    }



    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "bullet")
        {
            Destroy(gameObject);
        }


        if (collision.gameObject.tag == "npc" || collision.gameObject.tag == "boss")
        {

            collision.gameObject.GetComponent<health>().TakeDamage(bulletDamage);
            Destroy(gameObject);
        }

    }
}