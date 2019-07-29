﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterAttackCoordinator : MonoBehaviour
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
    Corvette[] corvettes;
    

    // Start is called before the first frame update
    void Start()
    {
        fireRate = fireTime;
       
        corvettes = FindObjectsOfType<Corvette>();
        if (corvettes != null)
        {
            for (int i = 0; i < corvettes.Length; i++)
            {
                corvettes[i].changeFase("missile");
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        fireRate -= Time.deltaTime;
        if (fireRate <= 0)
        {
            fireRate = fireTime;

            
                StartCoroutine(FighterFire());
           
             spawnBullet(currentShip);
            currentShip++;
            if (currentShip >= ships.Length)
            {
                currentShip = 0;
            }
        }
        }
    
    IEnumerator FighterFire()
    {
        for(int i=0;i<Leaderfirepoint.Length; i++) {
            Instantiate(bulletPrefab, Leaderfirepoint[i].position, Leaderfirepoint[i].rotation);
        }
        
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < Leaderfirepoint.Length; i++) {
            Instantiate(bulletPrefab, Leaderfirepoint[i].position, Leaderfirepoint[i].rotation);
        }
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < Leaderfirepoint.Length; i++) {
            Instantiate(bulletPrefab, Leaderfirepoint[i].position, Leaderfirepoint[i].rotation);
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
