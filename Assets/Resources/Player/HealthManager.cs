using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameover;
    public float health = 500;
    public float startingHealth = 500;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Takedamage(float damageToTake)
    {
        health -= damageToTake;
        
        if (health <= 0)
        {
            Debug.Log("dead");
            gameover.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
