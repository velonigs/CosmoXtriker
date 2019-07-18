using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackCoordinator : MonoBehaviour
{
    
    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    Transform[] ships;
    private float fireRate;
    [SerializeField]
    private float fireTime;
    private int currentShip;
   
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
            GameObject newBullet = Instantiate(bulletPrefab, ships[currentShip].position, ships[currentShip].rotation);
            Rigidbody rb = newBullet.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward *2, ForceMode.VelocityChange);
        }
    }

   
}
