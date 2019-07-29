using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField]
    private int health;
    public int startingHealth = 100;
    // Start is called before the first frame update
    void Start()
    {
        health = startingHealth;
    }

    
    public void Takedamage(int damageToTake)
    {
        health -= damageToTake;
        
        if (health <= 0)
        {
            Debug.Log("dead");
            gameObject.SetActive(false);
        }
    }
}
