using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _enemymove : MonoBehaviour
{
    //移動方向
    [SerializeField] private float IdouX;
    [SerializeField] private float IdouY;
    [SerializeField] private float IdouZ;

    //void OnTriggerEnter(Collider collision){
      //  if(collision.gameObject.name == "KillZone"){
        //    Destroy(this.gameObject); //KZ入ったらDestroy
        //}
    //}
    void Update()
    {
        //Transformの設定？
        Transform myTransform = this.transform;
        //World座標での移動
        myTransform.Translate(IdouX, IdouY, IdouZ, Space.World);
    }
}
