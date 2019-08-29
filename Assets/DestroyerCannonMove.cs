using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerCannonMove :CannonMovement
{
    [SerializeField] Transform[] UPElement;
    // Start is called before the first frame update
    void Start()
    {
        base.Init(); 
    }

    // Update is called once per frame
    void Update()
    {
        Tick();
    }
    public override void findPlayer()
    {
           if (player.transform.position.y > cannon[0].position.y)
            {
                for(int i = 0; i < cannon.Length; i++)
                {

                cannon[i].rotation = Quaternion.Lerp(cannon[i].rotation, UPElement[i].rotation, RotationSpeed * Time.deltaTime);
                cannon[i].position = Vector3.MoveTowards(cannon[i].position, UPElement[i].position, RotationSpeed*Time.deltaTime);
                }
        }
        else
        {

            for (int i = 0; i < cannon.Length; i++)
            {
                cannon[i].rotation = Quaternion.Lerp(cannon[i].rotation, DownElement[i].rotation, RotationSpeed * Time.deltaTime);
                cannon[i].position = Vector3.MoveTowards(cannon[i].position, DownElement[i].position, RotationSpeed * Time.deltaTime);
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
