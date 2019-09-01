using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    
    public int damage=5;
    [SerializeField]
   protected float speedMultipler=1f;
    [SerializeField]
   protected float bulletSpeed = 0.4f, rotateSpeed = 1;
    
   protected Transform player;
    
   protected  Vector3 target;
    
    private void Start()
    {
      if (PlayerController.instance == null)
        {
            return;
        }

        player = PlayerController.instance.transform;
        if (player.position.z > transform.position.z)
        {
            player = null;
            return;

        }
        target =  player.position-transform.position;
    }
    private void Update()
    {

        move();
        
    }
    
    public virtual void move()
    {

        // 登録した口座へ移動
        if (PlayerController.instance != null)
        {
            transform.position += target * Time.deltaTime * bulletSpeed * speedMultipler;


        }
        else
        {
            transform.Translate(0, 0, -bulletSpeed, Space.World);
        }

    }
    //プレイヤーにダメージをあげる
    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<HealthManager>().Takedamage(damage);
            Destroy(gameObject);
        }
        else if (other.tag == "KillZone"||other.tag=="Cannon")
        {
            Destroy(gameObject);
        }
        
    }
}
