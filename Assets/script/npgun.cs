using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npgun : MonoBehaviour
{
    public Transform NpBulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;

    public GameObject miniskeleton;
    public GameObject Astronaut;

    public float timer = 1.0f;
    public bool firing = false;

    private void Start()
    {
 

    }

    void Update()
    {
        if (miniskeleton.GetComponent<NpcControl>().aim == true)
        {
            if (firing == false)
            {
                InvokeRepeating("LaunchProjectile", 1.0f, timer);
                firing = true;

            } 
        }
            else
            {
                CancelInvoke("LaunchProjectile");
                firing = false;
         }
    }

    void LaunchProjectile() 
    {

        var bullet = Instantiate(bulletPrefab, NpBulletSpawnPoint.position, NpBulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = NpBulletSpawnPoint.forward * bulletSpeed;



    }



}