using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastBossAttack : MonoBehaviour
{
    [SerializeField] Transform ShotgunSpawnPoint;
    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] Transform[] cannonSpawnPoints;
    [SerializeField] GameObject bulletPrefab, shotGunBulletPrefab;
    [SerializeField] GameObject cannonbulletPrefab;
    [SerializeField] float attackDelay;
    [SerializeField]
    float cannonAttackDelay = 15;
    
    float bulletAttackDelay = 1f;

    float bulletspawnDelay = 0.12f;
    
    float ShotGunAttackDelay = 2f;
    float passValue;
    [SerializeField]
    int changeAttackCounter;
    public enum attackType { bullet, shotGun, cannon};
    public attackType currentAttack;
    bool canAttack;
    int bulletSpawned;
    // Start is called before the first frame update
    void Start()
    {
        attackDelay = bulletAttackDelay;
        currentAttack = attackType.bullet;
        changeAttackCounter = 3;
        bulletSpawned = 0;
    }

    // Update is called once per frame
    void Update()
    {
        attackDelay -= Time.deltaTime;
        if (attackDelay <= 0)
        {
            
            canAttack = true;
        }
       if (changeAttackCounter <= 0)
            {
                 changeAttack();
            }
           
        
        switch (currentAttack)
        {
            case attackType.bullet:bulletAttack(); break;
            case attackType.shotGun:shotgunAttack(); break;
            case attackType.cannon:cannonAttack();  break;
        }
    }

    private void changeAttack()
    {
        currentAttack++;
        if (currentAttack > attackType.cannon)
        {
            currentAttack = attackType.bullet;
        }
        if (currentAttack == attackType.shotGun) 
        {
            changeAttackCounter = 3;
            attackDelay = ShotGunAttackDelay;
        }
        else if(currentAttack == attackType.bullet)
        {
            changeAttackCounter = 3;
            attackDelay = bulletAttackDelay;
        }
        else if (currentAttack == attackType.cannon)
        {
            changeAttackCounter = 4;
            attackDelay = cannonAttackDelay;
            
        }
        
    }

    public void bulletAttack()
    {

        if (canAttack)
        {
            bulletspawnDelay -= Time.deltaTime;
            
            if (bulletspawnDelay<= 0)
            {
                Instantiate(bulletPrefab, bulletSpawnPoint.position, transform.rotation);
                bulletspawnDelay = 0.12f;
                bulletSpawned++;
                if (bulletSpawned >= 10)
                {
                    canAttack = false;
                    changeAttackCounter--;
                }
            }
        }
       

    }
    


    public void shotgunAttack()
    {
        if (canAttack)
        {
            Instantiate(shotGunBulletPrefab, ShotgunSpawnPoint.position, ShotgunSpawnPoint.rotation);
            canAttack = false;
            attackDelay = ShotGunAttackDelay;
            changeAttackCounter--;
        }
       
       
     }

    public void cannonAttack()
    {
        if (canAttack)
        {
            for (int i = 0; i < cannonSpawnPoints.Length; i++)
            {
                Instantiate(cannonbulletPrefab, cannonSpawnPoints[i].position, transform.rotation);
                canAttack = false;
                attackDelay = cannonAttackDelay;
                changeAttackCounter--;
            }
        }
     
        
      
    }
  
    


}
