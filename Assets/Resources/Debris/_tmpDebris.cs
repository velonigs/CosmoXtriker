using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//デブリクラス
public class _tmpDebris : MonoBehaviour
{
    public GameObject Explode; //撃破エフェクト
    [SerializeField] private ushort HP = 20;
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider collision){
        if(collision.gameObject.name == "KillZone"){
            Destroy(this.gameObject); //KZ入ったらDestroy
        }
    }
    void Update()
    {
        if(HP <= 0){
            Destroy(this.gameObject); //HP無くなったらDestroy
            Instantiate (Explode, transform.position, transform.rotation); //現在位置にエフェクト生成
        }
    }
}
