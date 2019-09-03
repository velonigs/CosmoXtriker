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
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void EndAnimation()
    {
        animator.SetTrigger("St Ani End");
    }
}
