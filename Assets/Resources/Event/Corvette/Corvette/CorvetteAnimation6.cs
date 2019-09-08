using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorvetteAnimation6 : MonoBehaviour
{
    /*
     * private Vector3 vel3;
    [SerializeField]
    GameObject wavecon;
    [SerializeField]
    GameObject CorvetteEvent1;
    */
    Animator animator;

    GameObject Corvettelaser6;

    LaserAnimation6 script;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Corvettelaser6 = GameObject.Find("Corvette_Laser6");
        script = Corvettelaser6.GetComponent<LaserAnimation6>();
    }

    // Update is called once per frame
    public void EndAnimation()
    {
        animator.SetTrigger("St Ani End");
        script.Laser();
    }
}
