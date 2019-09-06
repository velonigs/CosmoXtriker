using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorvetteAnimation : MonoBehaviour
{
    /*
     * private Vector3 vel3;
    [SerializeField]
    GameObject wavecon;
    [SerializeField]
    GameObject CorvetteEvent1;
    */
    Animator animator;

    GameObject Corvettelaser;

    LaserAnimation script;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Corvettelaser = GameObject.Find("Corvette_Laser");
        script = Corvettelaser.GetComponent<LaserAnimation>();
    }

    // Update is called once per frame
    public void EndAnimation()
    {
        animator.SetTrigger("St Ani End");
        script.Laser();
    }
}
