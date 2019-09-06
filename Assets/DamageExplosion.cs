using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageExplosion : MonoBehaviour
{
    int damage = 0;
    private void Start()
    {
        damage = UnityEngine.Random.Range(5, 15); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player"){
            other.GetComponent<HealthManager>().Takedamage(damage);
            }
    }
}
