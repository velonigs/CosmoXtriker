using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;//event Actionを使うため

public class BossHealth : MonoBehaviour, ITakeDamage
{
    //そとから呼び出すため
    public static BossHealth instance;
    public event Action<int> healthIsLess;
    [SerializeField] GameObject deathEffect;
    [SerializeField] GameObject drone;
    [SerializeField] Transform spawnPoint;
    Transform center;
    [SerializeField]
    GameObject[] debris;
    
    [SerializeField]
    float spawnLimits = 10;
    
    [SerializeField]
    int health = 3000;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        center = GameObject.Find("Center").transform;
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
            case 1500:DroneInvoke(10); if (healthIsLess != null) healthIsLess(2); break;
            case 1000:
                DroneInvoke(15);
                break;
            case 500: if (healthIsLess != null) healthIsLess(3); break;
            default:break;
        }
        if (health <= 0)
        {
            if (healthIsLess != null) healthIsLess(4);
        }
      
    }

    public void DroneInvoke(int num)
    {
      float randX = 0;
        float randy = 0;
        for (int i = 0; i < num; i++)
        {
            randX = UnityEngine.Random.Range(-spawnLimits, spawnLimits);
            randy = UnityEngine.Random.Range(-spawnLimits, spawnLimits);
            Instantiate(drone,new Vector3(spawnPoint.position.x+randX,
                spawnPoint.position.y+randy,spawnPoint.position.z), Quaternion.identity);
        }
    }

    public void death()
    {
        Instantiate(deathEffect,center.position, transform.rotation);
        for(int i = 0; i < 5; i++)
        {
            float randx = UnityEngine.Random.Range(-5, 5);
            float randy = UnityEngine.Random.Range(-5, 5);
            float randz= UnityEngine.Random.Range(-5, 5);
            int rand = UnityEngine.Random.Range(0, debris.Length);
            Instantiate(debris[rand], new Vector3(transform.position.x+randx, transform.position.y + 5+randy, transform.position.z + randz), transform.rotation);
        }
        
        gameObject.SetActive(false);
    }
}
