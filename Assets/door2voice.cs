using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door2voice : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag == "Player"){
            this.gameObject.GetComponent<AudioSource>().Play();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
