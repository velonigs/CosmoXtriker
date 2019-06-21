using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisMovement : MonoBehaviour
{
    //移動方向
    [SerializeField] private float IdouX;
    [SerializeField] private float IdouY;
    [SerializeField] private float IdouZ;

    void Update()
    {
        //Transformの設定？
        Transform myTransform = this.transform;
        //World座標での移動
        myTransform.Translate(IdouX, IdouY, IdouZ, Space.World);
        //回転をランダムで決める
        transform.Rotate
        (new Vector3(Random.Range(0, 180),
        Random.Range(0, 180),Random.Range(0, 180)) * Time.deltaTime);
    }
}
