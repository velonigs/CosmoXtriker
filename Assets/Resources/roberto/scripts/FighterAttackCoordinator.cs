using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterAttackCoordinator : MonoBehaviour
{

    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    fighter[] ships;
    private float fireRate=2;
    [SerializeField]
    private float fireTime=2;
    private int currentShip;
    [SerializeField]
    Transform[] Leaderfirepoint;
    
    

    // Start is called before the first frame update
    void Start()
    {
        fireRate = fireTime;
       
   }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.instance != null)
        {

        
        fireRate -= Time.deltaTime;
        if (fireRate <= 0)
        {
            fireRate = fireTime;

            if(transform.position.z>PlayerController.instance.transform.position.z)
                StartCoroutine(FighterFire());
           
             spawnBullet(currentShip);
            currentShip++;
            if (currentShip >= ships.Length)
            {
                currentShip = 0;
            }
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
            if(transform.position.z> PlayerController.instance.transform.position.z)
            ships[currentShip].shot();
           
         }


    }

}
