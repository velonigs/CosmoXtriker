using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameover;

    public float currentHealth;
    public float startingHealth = 500;

    void Start()
    {
        currentHealth = startingHealth;
    }
    void Update()
    {

    }

    public void Takedamage(float damageToTake)
    {
        currentHealth -= damageToTake;
        
        if (currentHealth <= 0)
        {
            Debug.Log("dead");
            gameover.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
