using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StEventAnimation : MonoBehaviour
{
    Animator _animator;

    [SerializeField]GameObject Corvette;

    CorvetteAnimation script;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        
        script = Corvette.GetComponent<CorvetteAnimation>();
    }

    // Update is called once per frame
    void Animationend()
    {
        script.EndAnimation();
    }
}
