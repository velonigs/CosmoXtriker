using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonMovement : MonoBehaviour
{
    Vector3 cannonStartPos;
    [SerializeField]
    Transform  Cannon;
    
    [SerializeField] float RotationSpeed=15;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerController.instance != null)
        {
            player = PlayerController.instance.transform;
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Cannon.LookAt(player,Vector3.up);
        }
      
            
        
      
    }
}
