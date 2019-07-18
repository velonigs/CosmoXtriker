using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lossyscale : MonoBehaviour
{
    Vector3 defaultscale;
    Vector3 _lossscale;
    Vector3 _localscale;
    void Start()
    {
        defaultscale = transform.lossyScale;
    }

    // Update is called once per frame
    void Update()
    {
        _lossscale = transform.lossyScale;
        _localscale = transform.localScale;
        transform.localScale = new Vector3(
            _localscale.x / _lossscale.x * defaultscale.x,
            _localscale.y / _lossscale.y * defaultscale.y,
            _localscale.z / _lossscale.z * defaultscale.z
            );
    }
}
