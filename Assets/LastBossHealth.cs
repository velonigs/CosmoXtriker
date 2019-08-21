using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;//event Actionを使うため

public class LastBossHealth : MonoBehaviour, ITakeDamage
{
    //そとから呼び出すため
    public static LastBossHealth instance;
    public event Action healthIsLess;
    
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
            case 1500:DroneInvoke(10); break;
                //eventSystem
            case 1000:if (healthIsLess != null) healthIsLess();
                DroneInvoke(15);
                break;
            default:break;
        }
        if (health <= 0)
        {
            gameObject.SetActive(false);
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
