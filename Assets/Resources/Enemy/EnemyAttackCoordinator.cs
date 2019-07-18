using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackCoordinator : MonoBehaviour
{

    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    fighter[] ships;
    private float fireRate;
    [SerializeField]
    private float fireTime;
    private int currentShip;
    [SerializeField]
    Transform[] Leaderfirepoint;
    int rl = 0;


    // Start is called before the first frame update
    void Start()
    {
        fireRate = fireTime;

    }

    // Update is called once per frame
    void Update()
    {
        fireRate -= Time.deltaTime;
        if (fireRate <= 0)
        {
            fireRate = fireTime;
            if (rl == 0)
            {
                GameObject leaderFire = Instantiate(bulletPrefab, Leaderfirepoint[0].position, Leaderfirepoint[0].rotation) as GameObject;
            }
            else
            {

                GameObject leaderFire = Instantiate(bulletPrefab, Leaderfirepoint[1].position, Leaderfirepoint[1].rotation) as GameObject;
            }
            



            spawnBullet(currentShip);
            currentShip++;
            if (currentShip >= ships.Length)
            {
                currentShip = 0;
            }

        }
    }

    private void spawnBullet(int currentShip)
    {
        if (ships[currentShip] != null)
        {
            ships[currentShip].shot();
           
         }


    }
}
