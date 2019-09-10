using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotOrbiter : MonoBehaviour
{
    [SerializeField]
    GameObject OrbitTarget;
    Vector3 _pivotpos;
    [SerializeField]
    float speed;
    void Start()
    {
       _pivotpos = OrbitTarget.transform.position;
    }

    void Update()
    {
        transform.LookAt(OrbitTarget.transform);
        transform.RotateAround(_pivotpos, Vector3.up, speed * Time.deltaTime);
    }
}
