using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventHealthManager : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "laser")
        {
            gameObject.SetActive(false);
        }
    }
}
