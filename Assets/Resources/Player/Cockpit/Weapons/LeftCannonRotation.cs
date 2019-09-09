using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftCannonRotation : MonoBehaviour {
    GameObject _camcon;
    GameObject _lmuzz;
    Transform center;
    GameObject sight;
    private Ray _ray;
    private Ray _ray2;
    Vector3 _pos;
    public Vector3 _pos2;
    Vector3 _pos3;
    Vector3 _pos4;
    float roty;
    float rotx;
    [SerializeField]
    float _xmarzin = 0.06f;
    [SerializeField]
    float _ymarzin = 0.006f;
    [SerializeField]
    float RotateSpeed = 10.0f;
    
    void Start() {
        _camcon = GameObject.Find("CameraController");
        _lmuzz = GameObject.Find("LeftMuzzle");
        center = _camcon.transform.Find("Crosshair");
        sight = GameObject.Find("Target");
    }
    void _target()
    {
        _pos = sight.transform.position - center.transform.position;
        _ray = new Ray(center.transform.position, _pos);
        foreach (RaycastHit _lhit in Physics.RaycastAll(_ray))
        {
            if (_lhit.collider.gameObject.tag == "Enemy")
            {
                _pos2 = _lhit.point;
                break;
            }
            else if(_lhit.collider.gameObject.tag == "Debris"){
                _pos2 = _lhit.point;
            }
            else if (_lhit.collider.gameObject.name == "CrosSphere")
            {
                _pos2 = _lhit.point;
            }
            else
            {
            }
            Debug.DrawLine(_ray.origin, _lhit.point, Color.red);
        }
    }
    void _target2()
    {
        _pos4 = _pos2 - _lmuzz.transform.position;
        _ray2 = new Ray(_lmuzz.transform.position, _pos4);
        foreach (RaycastHit _lhit2 in Physics.RaycastAll(_ray2))
        {
            if (_lhit2.collider.gameObject.name == "CrosSphere")
            {
                _pos3 = _lhit2.collider.gameObject.transform.position;
            }
            Debug.DrawLine(_ray2.origin, _lhit2.point, Color.green);
        }
    }

    void Update() {
        _target();
        _target2();
        Quaternion newRotation = Quaternion.LookRotation(_pos2 - _pos3);
        newRotation.z = 0;
        roty = newRotation.y;
        rotx = newRotation.x;
        newRotation.y += _xmarzin;
        newRotation.x += _ymarzin;
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * RotateSpeed);
        newRotation.y = roty;
        newRotation.x = rotx;
    }
}
