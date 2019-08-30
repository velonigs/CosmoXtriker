using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doors : MonoBehaviour
{
    Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _anim = this.gameObject.GetComponent<Animator>();
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            _anim.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
