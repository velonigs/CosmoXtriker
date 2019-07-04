using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _tmpBullet : MonoBehaviour{
    void Start(){
        
    }
    void OnTriggerEnter(Collider collision){
        if(collision.gameObject.name == "KillZone"){
            Destroy(this.gameObject); //KZ入ったらDestroy
        }
    }

    void Update(){
        }
}
