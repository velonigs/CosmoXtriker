using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class De : MonoBehaviour
{
    void Update()
    {
        Transform myTransform = this.transform;

        Vector3 Iti = myTransform.position;
        //到着したかどうか
        if (myTransform.position.z <= -5.0f)
        {
            Destroy(gameObject);
        }
    }
}
