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
    [SerializeField] float UpElementOffset;
    public bool canMove;
    public bool reassetting;
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
               //左と右の移動
                Torret.LookAt(player, Vector3.up);
                Torret.rotation = Quaternion.Euler(0, Torret.eulerAngles.y, 0);
                
                //最高のリミットを作りました
                if (cannon[0].rotation.x<-90|| cannon[0].rotation.x >0)
                {
                    limitIsReaced();
                }
                else
                {
                    findPlayer();
                }
            }
        }
        if (reassetting)
        {
            reasset();
            
        }
    }
    
    public void findPlayer()
    {
       
            for (int i = 0; i < cannon.Length; i++)
            {

            Quaternion targetRot = Quaternion.LookRotation(player.position - cannon[i].position);
            cannon[i].rotation = Quaternion.Lerp(cannon[i].rotation, targetRot, RotationSpeed*Time.deltaTime);
          
           }
    }
    
    void limitIsReaced()
    {
        if(cannon[0].rotation.x<=-90)
        {
            //rotationだけじゃなくてポジションも変更しなきやいけない
            Vector3 upPos = new Vector3(UPElement[0].position.x + cannon1Offset, UPElement[0].position.y, UPElement[0].position.z);
            cannon[0].position = Vector3.MoveTowards(cannon[0].position, upPos, RotationSpeed * Time.deltaTime);
            cannon[0].rotation = Quaternion.Lerp(cannon[0].rotation, UPElement[0].rotation, RotationSpeed * Time.deltaTime);
            
            //複数がある場合
            if (cannon.Length > 1)
            {
                Vector3 newupPos = new Vector3(UPElement[1].position.x + cannon1Offset, UPElement[1].position.y, UPElement[1].position.z);
                cannon[1].position = Vector3.MoveTowards(cannon[1].position, newupPos, RotationSpeed * Time.deltaTime);
                cannon[1].rotation = Quaternion.Lerp(cannon[1].rotation, UPElement[1].rotation, RotationSpeed * Time.deltaTime);
               
            }
        }
        else 
        {
            reasset();
           
        }
        
    }

    public void reasset()
    {
        for (int i = 0; i < cannon.Length; i++)
        {
            //下へ行かないのにまたリミットをつくりました
            
                Vector3 downPos = new Vector3(DownElement[i].position.x + cannon1Offset, DownElement[i].position.y, DownElement[i].position.z);
                cannon[i].position = Vector3.MoveTowards(cannon[i].position, downPos, RotationSpeed * Time.deltaTime);
                cannon[i].rotation = Quaternion.Lerp(cannon[i].rotation, DownElement[i].rotation, RotationSpeed * Time.deltaTime);
                
                if(cannon[cannon.Length-1].rotation == DownElement[cannon.Length-1].rotation)
                {
                    reassetting = false;
                }
              }
        }
       
    }

