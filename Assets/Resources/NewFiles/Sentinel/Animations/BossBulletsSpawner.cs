using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletsSpawner : MonoBehaviour
{
    [SerializeField] GameObject bullet, rayGun, missiles,cannonBulletPrefab;
    [SerializeField] Transform bulletSpawnPoint, raygunSpawnPoint;
    [SerializeField] Transform[] missilesSpawnPoints;
    [SerializeField] Transform[] cannonSpawnPoints;
    float bulletSpawnDelay = 0.125f;
    int bullespawned = 0;
    
   public static bool canAttack;
   [SerializeField] float waitingtime = 1;

    private void Start()
    {
        canAttack = false;
    }
    void Update()
    {
        if (canAttack)
        {
            bulletSpawnDelay -= Time.deltaTime;
            if (bulletSpawnDelay <= 0)
            {
                bulletSpawnDelay = 0.125f;
                
               
                gatlingAttack();
                
            }
        }
        
    }

    public void deactiveGatling()
    {
        canAttack = false;
    }

    public void activeGatling()
    {
        canAttack = true;
    }

    public void gatlingAttack()
    {
        Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullespawned++;
        if (bullespawned < 12)
        {
            canAttack = false;
        }
    }
    public void raygunAttack()
    {
        Instantiate(rayGun, raygunSpawnPoint.position, raygunSpawnPoint.rotation);
        

    }
    public void cannonAttack()
    {
        foreach (Transform point in missilesSpawnPoints)
        {
            Instantiate(cannonBulletPrefab, point.position, point.rotation);

        }
        
    }
    public void MissileAttack()
    {
        foreach (Transform point in missilesSpawnPoints)
        {
            Instantiate(missiles, point.position, point.rotation);

        }
    }
}