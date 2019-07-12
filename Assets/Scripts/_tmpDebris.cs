using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//デブリクラス
public class _tmpDebris : MonoBehaviour
{
    public GameObject Explode; //撃破エフェクト
    [SerializeField]
    private int damage = 5;
    [SerializeField] private ushort HP = 20;
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider collision){
        if(collision.gameObject.tag == "Bullet"){
            ushort _dmg = collision.gameObject.GetComponent<_tmpBullet>().Damage;
            HP -= _dmg;
        }
        if(collision.gameObject.name == "KillZone"){
            Destroy(this.gameObject); //KZ入ったらDestroy
        }
        if (collision.tag == "Player")
        {
            collision.GetComponent<HealthManager>().Takedamage(damage);
        }
    }
    void Update()
    {
        if(HP <= 0){
            Destroy(this.gameObject); //HP無くなったらDestroy
            Instantiate (Explode, transform.position, transform.rotation); //現在位置にエフェクト生成
        }
    }
}
