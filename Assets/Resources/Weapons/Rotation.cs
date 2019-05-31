using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(_ray.direction);
    }
}
