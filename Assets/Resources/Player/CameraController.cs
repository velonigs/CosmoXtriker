using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private
    GameObject player;
    Vector3 offset;

    private void Start()
    {
        this.player = GameObject.Find("Sphere");

        offset = transform.position - player.transform.position;
    }
    private void Update()
    {
        transform.position = player.transform.position + offset;
        transform.rotation = player.transform.rotation;
    }
}
