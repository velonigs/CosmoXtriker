using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDamage : MonoBehaviour
{
    float damage=30;
    float stayDamage = 5;
    bool active;
    float damageTime = 1;

    Transform player;
    private void Start()
    {
        player = PlayerController.instance.transform; 
    }
    private void Update()
    {
        if (active)
        {
            damageTime -= Time.deltaTime;
            if (damageTime <= 0)
            {
                damageTime = 1;
                player.GetComponent<HealthManager>().Takedamage(5);
                
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.GetComponent<HealthManager>().Takedamage(30);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            active = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            active = false;
        }
        
    }

}
