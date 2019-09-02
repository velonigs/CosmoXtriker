using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _tmpBullet : MonoBehaviour{
    [SerializeField] GameObject impact;
    public ushort Damage = 1; //ダメージ
    void Start(){    
    }
    void OnTriggerEnter(Collider collision){
        if(collision.gameObject.name == "BulletKillZone")
        {
            Destroy(this.gameObject); //KZ入ったらDestroy
        }
        if(collision.tag=="Enemy"|| collision.tag == "Corvette")
        Instantiate(impact, transform.position, transform.rotation);
       
    }

    void Update(){
        }
}
