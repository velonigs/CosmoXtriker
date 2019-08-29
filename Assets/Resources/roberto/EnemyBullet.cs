using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    
    public int damage=5;
    [SerializeField]
    float bulletSpeed= 0.4f;
    [SerializeField]
    float veloctyTimeFactor = 100f;
    Vector3 playerPos;
    Vector3 move;
    
    private void Start()
    {
       
        Destroy(gameObject, 5f);
        if (PlayerController.instance == null)
        {
            return;
        }
        playerPos = PlayerController.instance.transform.position;
        move = playerPos - transform.position;
        

    }
    private void Update()
    {

        // 登録した口座へ移動
        if (PlayerController.instance != null)
        {
            transform.position += move * (bulletSpeed * Time.deltaTime);
        }


        else
        {
            transform.Translate(0, 0, (-bulletSpeed * (Time.deltaTime * veloctyTimeFactor)), Space.World);
        }

  }
    
    //プレイヤーにダメージをあげる
    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            HealthManager health = other.GetComponent<HealthManager>();
            if (health != null)
            {
                health.Takedamage(damage);
            }
            Destroy(gameObject);
        }
        if (other.tag == "KillZone")
        {
            Destroy(gameObject);
        }
       
    }
}
