using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private float followRange = 500f;
   
    [SerializeField]
    private float attackrange = 100f;
    private PlayerController player;
    
    // Start is called before the first frame update
    void Start()
    {
        //プレーヤーを探す機能
        player = FindObjectOfType<PlayerController>();   
    }

    // Update is called once per frame
    void Update()
    {
        //プレーヤーと敵の距離
        var distanceToPlayer = (transform.position-player.transform.position).sqrMagnitude;
      
        //レンジを作って、その中でエネミーはプレーヤの場へ向かう
        if (distanceToPlayer <= followRange&&distanceToPlayer>attackrange)
        {

            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 0.2f);
        }
        else
        {　　　//真っ直ぐへ移動
            transform.Translate(0, 0, -0.2f);
        }
    }
}
