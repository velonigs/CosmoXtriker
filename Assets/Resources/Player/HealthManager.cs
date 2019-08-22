using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameover;
    [SerializeField]
    private float health;
    public float startingHealth = 100;
    // Start is called before the first frame update
    void Start()
    {
        health = startingHealth;
    }

    
    public void Takedamage(float damageToTake)
    {
        health -= damageToTake;
        
        if (health <= 0)
        {
            Debug.Log("dead");
            if (gameover != null) 
            gameover.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
