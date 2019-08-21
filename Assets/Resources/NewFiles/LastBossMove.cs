using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastBossMove : MonoBehaviour
{
    
    Transform player;
    [SerializeField] float rotatespeed = 2;
     public bool loockPlayer;
    // Start is called before the first frame update
    void Start()
    {
        loockPlayer = true;
        player = PlayerController.instance.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (loockPlayer)
        {
            transform.LookAt(player, Vector3.up);
            Quaternion newRot = Quaternion.Euler(0, transform.eulerAngles.y, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRot, rotatespeed * Time.deltaTime);
        }
     
    }
}
