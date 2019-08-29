using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerBCannonMove : CannonMovement
{
    Quaternion[] maxRot;
    [SerializeField] 
    Transform upPose;
    Vector3 maxPos;
    bool maxPosIsReached;
    Vector3 startpos;
    void Start()
    {
        maxPosIsReached = false;
        base.Init();
        maxPos = upPose.position - cannon[0].position;
        startpos = cannon[0].position;
    }

    
    void Update()
    {
        Tick();
    }
    public override void findPlayer()
    {
        if (player.position.y > cannon[0].position.y + 5)
            for (int i = 0; i < cannon.Length; i++)
            {
                if (cannon[i].position.y < upPose.position.y)
                {
                    cannon[i].Translate(maxPos * Time.deltaTime);
                    if (cannon[cannon.Length - 1].position == upPose.position)
                    {
                        maxPosIsReached = true;
                    }
                }
            }
   
        if (!maxPosIsReached)
        {
            for (int i = 0; i < cannon.Length; i++)
            {

                Quaternion targetRot = Quaternion.LookRotation(player.position - cannon[i].position);
                cannon[i].rotation = Quaternion.Lerp(cannon[i].rotation, targetRot.normalized, RotationSpeed * Time.deltaTime);
                upPose.rotation = cannon[i].rotation;

           }
        }
    }
           
        
    

    public override void Tick()
    {
        if (canMove)
        {
            if (player != null)
            {
                //左と右の移動
                transform.LookAt(player, Vector3.right);
                transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
                findPlayer();

            }
            
        }
        if (reassetting)
        {
            reasset();

        }
    }

}
