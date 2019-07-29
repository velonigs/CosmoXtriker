using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    
    public int damage=5;
    [SerializeField]
    float bulletSpeed= 0.4f;
    PlayerController player;
    
    
    float playerPoseY;
    float playerPoseX;
    float playPoseZ;
    Vector3 target;
    private void Start()
    {
        Destroy(gameObject, 5f);
        //プレイヤーのポジションを登録する
        playerPoseX = (PlayerController.instance.transform.position.x ) ;
        playerPoseY= (PlayerController.instance.transform.position.y);
        playPoseZ= (PlayerController.instance.transform.position.z );
        target = new Vector3(playerPoseX, playerPoseY, playPoseZ);

    }
    private void Update()
    {
       // 登録した口座へ移動
        transform.position = Vector3.MoveTowards(transform.position, target, bulletSpeed);
        
    }
    
    //プレイヤーにダメージをあげる
    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<HealthManager>().Takedamage(damage);
        }
        Destroy(gameObject);
    }
}
