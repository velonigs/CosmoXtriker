using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _tmpBullet : MonoBehaviour{
    public ushort Damage = 1; //ダメージ
    void Start(){    
    }
    void OnTriggerEnter(Collider collision){
        if(collision.gameObject.name == "BulletKillZone"){
            Destroy(this.gameObject); //KZ入ったらDestroy
        }
    }

    void Update(){
        }
}
