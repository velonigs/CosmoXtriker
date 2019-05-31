using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour{
    public int HP = 20;

    void Start(){
        
    }
    private void OnTriggerEnter(Collider collider){
        HP -= 10;
    }
    void Update(){
        if(HP <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
