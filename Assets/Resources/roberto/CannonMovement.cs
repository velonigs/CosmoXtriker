using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonMovement : MonoBehaviour
{
    [SerializeField] float cannon1Offset;
    [SerializeField] float cannon2Offset;
    [SerializeField]
    Transform Torret;
    [SerializeField] Transform[] UPElement;
    [SerializeField] Transform[] DownElement;
    [SerializeField] Transform[] cannon;
    [SerializeField] float RotationSpeed = 10;
    
    public bool canMove;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        if (PlayerController.instance != null)
        {
            player = PlayerController.instance.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            if (player != null)
            {
                Torret.LookAt(player, Vector3.up);
                Torret.rotation = Quaternion.Euler(0, Torret.eulerAngles.y, 0);
                if (player.position.y > transform.position.y)
                {
                    
                    cannon[0].rotation = Quaternion.Slerp(cannon[0].rotation, UPElement[0].rotation, RotationSpeed);
                    
                    cannon[0].position = new Vector3(UPElement[0].position.x + cannon1Offset, UPElement[0].position.y, UPElement[0].position.z);
                    if (cannon.Length > 1)
                    {
                        cannon[1].rotation = Quaternion.Slerp(cannon[1].rotation, UPElement[1].rotation, RotationSpeed);
                        cannon[1].position = new Vector3(UPElement[1].position.x + cannon2Offset, UPElement[1].position.y, UPElement[1].position.z);
                    }
                    }
                else
                {
                    reAsset();
                }
            }
        }
        else
        {
            reAsset();
            
        }
    }

    public void reAsset()
    {
       
            for (int i = 0; i < cannon.Length; i++)
            {
                if (cannon[i].rotation != DownElement[i].rotation)
                    cannon[i].rotation = Quaternion.Slerp(cannon[i].rotation, DownElement[i].rotation, RotationSpeed);
                cannon[i].position = DownElement[i].position;
            }}
}
