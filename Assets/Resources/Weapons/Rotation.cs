using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

    private int _layermask;
    private Ray _ray;
    RaycastHit _hit;
    

    void Start() {
        int _layermask = (1 << LayerMask.NameToLayer("TargetArea"));
    }

    // Update is called once per frame
    void Update() {
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _hit, Mathf.Infinity, _layermask)) {
            Vector3 _pos = _hit.point;
            transform.rotation = Quaternion.Euler(_pos);
        }
    }
}
