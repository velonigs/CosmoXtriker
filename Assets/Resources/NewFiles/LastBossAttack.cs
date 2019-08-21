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
    
    float bulletAttackDelay = 2f;

    float bulletspawnDelay = 0.12f;
    
    float ShotGunAttackDelay = 2f;
    float passValue;
    [SerializeField]
    int changeAttackCounter;
    
    //攻撃の間の待つ時間
    [SerializeField]
    float waiting=0.75f;
    float waitForNewAttack;
    /// <summary>
    /// enumクラスでボースの攻撃を変更する
    /// </summary>
    public enum attackType { bullet, shotGun, cannon};
    //現在の攻撃
    public attackType currentAttack;

    bool canAttack;
    int bulletSpawned;
    //cannonを使わないように
    public bool thirdPhaseActive;
    public bool timeStop;
    // Start is called before the first frame update
    void Start()
    {
        thirdPhaseActive = false;
        attackDelay = bulletAttackDelay;
        currentAttack = attackType.bullet;

        //何回目同じ攻撃の繰り返し値
        changeAttackCounter = 3;

        bulletSpawned = 0;
        timeStop = false;
        //イベントに関数を追加する
        LastBossHealth.instance.healthIsLess += activeThirdPhase;
        waitForNewAttack = waiting;
    }

    // Update is called once per frame
    void Update()
    {
        if (!timeStop)
        {
            attackDelay -= Time.deltaTime;
        }
        
        if (attackDelay <= 0)
        {
            timeStop = true;
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
        //攻撃タイプを変更する
        currentAttack++;

        if (!thirdPhaseActive) { if (currentAttack > attackType.shotGun)
                currentAttack = attackType.bullet;
        }
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
            //3回攻撃ができるようにこのタイマーを入れた
            waitForNewAttack -= Time.deltaTime;
            if (waitForNewAttack <= 0)
            {
                bulletspawnDelay -= Time.deltaTime;
            }
           
            
            if (bulletspawnDelay<= 0)
            {
                Instantiate(bulletPrefab, bulletSpawnPoint.position, transform.rotation);
                bulletspawnDelay = 0.125f;
                bulletSpawned++;
                //バレット10以上になったら、タイマーリセットする
                if (bulletSpawned >= 10)
                {
                    
                    changeAttackCounter--;
                    timeStop = false;
                    bulletSpawned = 0;
                    waitForNewAttack= waiting ;
                }
            }
        }
      }
    


    public void shotgunAttack()
    {
       
        if (canAttack)
        {
            waitForNewAttack -= Time.deltaTime;
            if (waitForNewAttack <= 0)
            {
                waitForNewAttack= waiting ;
                Instantiate(shotGunBulletPrefab, ShotgunSpawnPoint.position, ShotgunSpawnPoint.rotation);
                canAttack = false;
                attackDelay = ShotGunAttackDelay;
                changeAttackCounter--;
                timeStop = false;
            }
           
        }
       
       
     }

    public void cannonAttack()
    {

        
        
        if (canAttack)
        {
            waitForNewAttack -= Time.deltaTime;
            if (waitForNewAttack <= 0)
            {
                LastBossMove.instance.loockPlayer = false;
                waitForNewAttack = waiting;
                for (int i = 0; i < cannonSpawnPoints.Length; i++)
                {
                    Instantiate(cannonbulletPrefab, cannonSpawnPoints[i].position, transform.rotation);
                    
                }
                canAttack = false;
                attackDelay = cannonAttackDelay;
                changeAttackCounter--;
                LastBossMove.instance.loockPlayer = true;
                timeStop = false;
            }
           }
  }
  
    
    public void activeThirdPhase()
    {
        thirdPhaseActive = true;
        currentAttack = attackType.cannon;
        timeStop = false;
    }

    private void OnDisable()
    {
        //イベントに関数を引く
        LastBossHealth.instance.healthIsLess -= activeThirdPhase;
    }
}
