using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    Transform leftPart, RightPart;
    Vector3 leftStartPos;
    Vector3 rightStartPos;
    [SerializeField]
    Transform endPosRight, endPoseLeft;

    public bool closing;
    [SerializeField]
    float closingSpeed;

    
    
    // Start is called before the first frame update
    void Start()
    {
        closing = false;
        leftStartPos = leftPart.position;
        rightStartPos = RightPart.position;
        leftPart.position = endPoseLeft.position;
        RightPart.position = endPosRight.position;
        

    }

    // Update is called once per frame
    void Update()
    {
        if (closing)
        {


            leftPart.position = Vector3.MoveTowards(transform.position, leftStartPos, 0.1f * closingSpeed*Time.deltaTime);
            RightPart.position = Vector3.MoveTowards(transform.position, rightStartPos, 0.1f * closingSpeed*Time.deltaTime);
           

        }
    }


    public void closeTheDoor()
    {
        closing = true;
    }
}
