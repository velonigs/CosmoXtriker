using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class DestroyerCannonAttack : MonoBehaviour,ITakeDamage
{
    [SerializeField] float Health=100;
    [SerializeField] int power = 10;
    [SerializeField] GameObject explosion;
    [SerializeField]  EnemyBullet bullet; 
   
    [SerializeField] Transform[] firepoints;
 
    public void fire()
    {
        for(int i = 0; i < firepoints.Length; i++)
        {
            EnemyBullet newBullet= Instantiate(bullet, firepoints[i].position, transform.rotation) as EnemyBullet;
            newBullet.damage = power;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            takeDamage(10);
        }
    }

    public void takeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            EnemyHealthManager health = GetComponent<EnemyHealthManager>();
            if(health!=null)
            health.takeDamage(50);
            Instantiate(explosion, firepoints[0].position, transform.rotation);
            gameObject.SetActive(false);
        }
        

    }
}
