using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class health : MonoBehaviour
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
            if(gameObject.tag == "boss")
            {

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }

            // Removes the gameObject. Can be boss or skeleton.
            Destroy(gameObject);
        }
    }


}
