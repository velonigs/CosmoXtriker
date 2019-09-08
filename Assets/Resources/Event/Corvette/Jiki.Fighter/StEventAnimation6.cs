using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StEventAnimation6 : MonoBehaviour
{
    Animator _animator;

    GameObject Corvette6;

    CorvetteAnimation6 script;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        Corvette6 = GameObject.Find("corvette_ultimate2");
        script = Corvette6.GetComponent<CorvetteAnimation6>();
    }

    // Update is called once per frame
    void Animationend()
    {
        if(script!=null)
        script.EndAnimation();
    }
}
