using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidAnimation : MonoBehaviour
{
    /*
     * private Vector3 vel3;
    [SerializeField]
    GameObject wavecon;
    [SerializeField]
    GameObject CorvetteEvent1;
    */
    Animator animator;

    GameObject Debri;

    DebrisPop script;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        Debri = GameObject.Find("Debri Sponner");

        script = Debri.GetComponent<DebrisPop>();

    }

    // Update is called once per frame
    public void DebriStart()
    {
            animator.SetTrigger("St Forword");
    }
}