using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftCannonRotation : MonoBehaviour {
    GameObject _lmuzz = GameObject.Find("_lmuzzle");
    GameObject center = GameObject.Find("Crosshair");
    GameObject sight = GameObject.Find("Target");
    private Ray _ray;
    Vector3 _pos;
    Vector3 _pos2;
    
    void _target()
    {
        _pos = sight.transform.position - center.transform.position;
        _ray = new Ray(center.transform.position, _pos);
        foreach (RaycastHit _lhit in Physics.RaycastAll(_ray))
        {
            if(_lhit.collider.gameObject.tag == "Enemy")
            {
                _pos2 = _lhit.collider.gameObject.transform.position;
            }
            else
            {

            }
        }
    }
    void Start() {
    }

    void Update() {

    }
}
