using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _RotateVertical : CannonRotation
{
    Vector3 _thistra;
    // Start is called before the first frame update
    void Start()
    {
        _thistra.y = this.transform.rotation.y;
    }

    // Update is called once per frame
    void Update()
    {
        _ray = Camera.main.ScreenPointToRay(_target);
        var _newRotation = Quaternion.LookRotation(_hit.point - transform.position).eulerAngles;
        _newRotation.y = 0;
        _newRotation.z = 0;
        transform.rotation = Quaternion.Euler(_newRotation);
    }
}
