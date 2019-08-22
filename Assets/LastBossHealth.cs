using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;//event Actionを使うため

public class LastBossHealth : MonoBehaviour, ITakeDamage
{
    //そとから呼び出すため
    public static LastBossHealth instance;
    public event Action<int> healthIsLess;
    [SerializeField] GameObject deathEffect;
    [SerializeField] GameObject drone;
    [SerializeField] Transform spawnPoint;
    
    [SerializeField]
    int health = 3000;

    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            takeDamage(500);
        }
    }
    public void takeDamage(int damage)
    {
        health -= damage;

        //体力によってドローンを作る
        switch (health)
        {
            case 2500: DroneInvoke(5); break;
            //eventSystem
            case 1500:DroneInvoke(10); if (healthIsLess != null) healthIsLess(1); break;
            case 1000:
                DroneInvoke(15);
                break;
            case 500: if (healthIsLess != null) healthIsLess(2); break;
            default:break;
        }
        if (health <= 0)
        {
            gameObject.SetActive(false);
            Instantiate(deathEffect, transform.position, transform.rotation);
        }
      
    }

    public void DroneInvoke(int num)
    {
        for(int i = 0; i < num; i++)
        {
            Instantiate(drone, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
