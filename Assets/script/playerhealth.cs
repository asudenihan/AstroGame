using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerhealth : MonoBehaviour
{
    public int maxHealth;

    public GameObject youAreDeadMenu;



    public void TakeDamage(int BulletDamage)
    {

        Debug.Log("Take Damage Function worked..");
        Debug.Log("Incoming bullet damage = " + BulletDamage);
        Debug.Log("Max health =" + maxHealth);


        maxHealth -= BulletDamage;

        Debug.Log("Decreased health =" + maxHealth);

        if (maxHealth <= 0)
        {

            // Check if the pauseMenu is found
            if (youAreDeadMenu != null)
            {
                Debug.Log("pause menu isnt null");
                // Set it active
                youAreDeadMenu.SetActive(true);

                Time.timeScale = 0;
            }
            else
            {
                // Log an error if the "YouAreDeadMenu" GameObject is not found
                Debug.LogError("Could not find GameObject with tag 'YouAreDeadMenu'");
            }
        }

    }

}
