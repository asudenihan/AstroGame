using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossbullet : MonoBehaviour
{
    public float life = 3;
    public int npbulletDamage = 1;

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


        if (collision.gameObject.tag == "Player")
        {

            collision.gameObject.GetComponent<playerhealth>().TakeDamage(npbulletDamage);
            Destroy(gameObject);
        }
    }
}
