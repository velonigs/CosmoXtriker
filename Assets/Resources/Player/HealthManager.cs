using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameover;

    // [SerializeField]
    // private GameObject _strikerHologram;

    public float health;
    public float startingHealth = 500;

    void Start()
    {
        health = startingHealth;
    }

    // TODO:体力の残量によって自機ホログラムの色を変更されるようにする
    void Update()
    {
        if (health > startingHealth / 2)
        {

        }
        else
        {

        }
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
