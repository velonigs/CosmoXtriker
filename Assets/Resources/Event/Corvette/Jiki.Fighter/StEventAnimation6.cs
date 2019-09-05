using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StEventAnimation6 : MonoBehaviour
{
    Animator _animator;

    GameObject Corvette6;

    CorvetteAnimation script;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        Corvette6 = GameObject.Find("corvette_ultimate2");
        script = Corvette6.GetComponent<CorvetteAnimation>();
    }

    // Update is called once per frame
    void Animationend()
    {
        script.EndAnimation();
    }
}
