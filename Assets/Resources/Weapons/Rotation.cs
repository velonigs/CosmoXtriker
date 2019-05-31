using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit _hit;
    int layermask = (1 << LayerMask.NameToLayer("TargetArea"));

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(_ray, out _hit, Mathf.Infinity, layermask))
        {
            Vector3 _pos = _hit.point;
            transform.rotation = Quaternion.Euler(_pos);
        }
    }
}
