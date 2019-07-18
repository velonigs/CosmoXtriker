using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonRotation : MonoBehaviour {
    private int _layermask;
    public Ray _ray;
    public RaycastHit _hit;
    public Vector3 _target;
    Vector3 _pos;
    
    void Start() {
        int _layermask = (1 << LayerMask.NameToLayer("TargetArea"));
    }

    // Update is called once per frame
    void Update() {
        _target = Input.mousePosition;
        _target.z = 10.0f;
    }
}
