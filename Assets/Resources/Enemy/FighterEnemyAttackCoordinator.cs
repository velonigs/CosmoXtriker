using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterEnemyAttackCoordinator : MonoBehaviour
{
    
    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    fighter[] ships;
    private float LeaderfireRate=2f;
    [SerializeField]
    private float plotonFireRate=1f;
    [SerializeField]
    private float fireTime;
    private int currentShip;
    [SerializeField]
    Transform[] Leaderfirepoint;
    int rl = 0;


    // Start is called before the first frame update
    void Start()
    {
        LeaderfireRate = fireTime;

    }

    // Update is called once per frame
    void Update()
    {
        //リーダーの攻撃
        LeaderfireRate -= Time.deltaTime;
        if (LeaderfireRate <= 0)
        {
            LeaderfireRate = fireTime;
            if (rl == 0)
            {
                GameObject leaderFire = Instantiate(bulletPrefab, Leaderfirepoint[0].position, Leaderfirepoint[0].rotation) as GameObject;
            }
            else
            {

                GameObject leaderFire = Instantiate(bulletPrefab, Leaderfirepoint[1].position, Leaderfirepoint[1].rotation) as GameObject;
            }
        }
        //プロトンの攻撃
        plotonFireRate -= Time.deltaTime;
        if (plotonFireRate <= 0)
        {
            plotonFireRate = 1f;
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
