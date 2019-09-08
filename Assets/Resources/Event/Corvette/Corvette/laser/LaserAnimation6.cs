using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAnimation6 : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Laser()
    {
        animator.SetTrigger("Kazu_Laser");
    }
}
