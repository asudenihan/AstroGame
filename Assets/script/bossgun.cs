using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossgun : MonoBehaviour
{
    public Transform BossBulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;

    public GameObject LowPolySkeleton;
    public GameObject Astronaut;

    public float timer = 1.0f;
    public bool firing = false;

    private void Start()
    {


    }

    void Update()
    {
        if (LowPolySkeleton.GetComponent<bosscontrol>().aim == true)
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

        var bullet = Instantiate(bulletPrefab, BossBulletSpawnPoint.position, BossBulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = BossBulletSpawnPoint.forward * bulletSpeed;



    }



}
