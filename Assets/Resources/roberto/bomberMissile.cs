using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomberMissile : EnemyBullet
{
    [SerializeField]
    GameObject explosion;

    public override void OnTriggerEnter(Collider other)
    {
        Instantiate(explosion, transform.position, transform.rotation);
        base.OnTriggerEnter(other);
    }
}
