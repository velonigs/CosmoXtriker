using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlyStatic : MonoBehaviour
{
    void Start()
    {
        
    }

    //触れたらMIA
    void OnTriggerEnter(Collider collider){
        if(collider.tag == "Player"){
            Debug.Log("aaa");
            collider.GetComponent<HealthManager>().Takedamage(50000);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
