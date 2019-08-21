using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour,ITakeDamage
{
    public LastBossAttack attack;
    public LastBossMove movement;
    [SerializeField]
    int health = 3000;
   

    // Start is called before the first frame update
    void Start()
    {
        attack = GetComponent<LastBossAttack>();
        movement = GetComponent<LastBossMove>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void takeDamage(int damage)
    {
        health -= damage;
        if (health == 100)
        {
            movement.loockPlayer = false;
            attack.currentAttack = LastBossAttack.attackType.cannon;
        }
    }
}
