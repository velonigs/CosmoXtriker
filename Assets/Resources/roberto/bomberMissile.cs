using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomberMissile : EnemyBullet
{
    [SerializeField]
    GameObject explosion;

    private void Update()
    {
        move();
    }

    public override void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            other.GetComponent<HealthManager>().Takedamage(damage);
             Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (other.tag == "KillZone"||other.tag=="Bullet")
        {
            if (other.tag == "Bullet")
            {
                Instantiate(explosion, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
        
       
    }

    public override void move()
    {
        // 登録した口座へ移動
        if (PlayerController.instance != null)
        {
            transform.position += target * Time.deltaTime * bulletSpeed * speedMultipler;
            Vector3 dir = player.position - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), rotateSpeed * Time.deltaTime);

        }
        else
        {
            transform.Translate(0, 0, -bulletSpeed, Space.World);
        }
    }
}
