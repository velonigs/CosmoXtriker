using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StEventAnimation : MonoBehaviour
{
    Animator _animator;

    GameObject Corvette3;

    CorvetteAnimation script;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        Corvette3 = GameObject.Find("corvette_ultimate1");
        script = Corvette3.GetComponent<CorvetteAnimation>();
    }

    // Update is called once per frame
    void Animationend()
    {
        script.EndAnimation();
    }
}
