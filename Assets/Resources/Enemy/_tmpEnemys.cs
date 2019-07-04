using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//基本敵クラス　これを継承して各敵クラスを作成する
public class _tmpEnemys : MonoBehaviour{
    public int HP = 20; //これがなくなったらDestroy
    //移動方向
    [SerializeField] private float IdouX;
    [SerializeField] private float IdouY;
    [SerializeField] private float IdouZ;

    void Start(){
        
    }
    void OnTriggerEnter(Collider collision){
        if(collision.gameObject.name == "KillZone"){
            Destroy(this.gameObject); //KZ入ったらDestroy
        }
    }
    void Update(){
        Transform myTransform = this.transform; //Transformの設定？
        myTransform.Translate(IdouX, IdouY, IdouZ, Space.World); //World座標での移動
        if(HP <= 0){
            Destroy(this.gameObject); //HP無くなったらDestroy
        }
    }
}
