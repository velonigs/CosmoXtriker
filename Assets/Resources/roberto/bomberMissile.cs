using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomberMissile : EnemyBullet
{
    [SerializeField]
    GameObject explosion;

    public override void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            other.GetComponent<HealthManager>().Takedamage(damage);
             Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (other.tag == "KillZone")
        {
            Destroy(gameObject);
        }
        
       
    }
}
