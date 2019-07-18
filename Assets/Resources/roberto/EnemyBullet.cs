using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    
    public int damage=5;
    [SerializeField]
    float bulletSpeed= 0.2f;
    private void Start()
    {
        Destroy(gameObject, 5f);
    }
    private void Update()
    {
        transform.Translate(0, 0, bulletSpeed);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<HealthManager>().Takedamage(damage);
        }
        Destroy(gameObject);
    }
}
