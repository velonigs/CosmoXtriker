/*
移動
斜めに移動する機構
Zの位置で左右どちらに移動するか決める
目的地の設定
目的地に到着したら消す
目的地をZ軸のみにしたい
当たったら止めたいからRigidbody
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Rigidbody必須
[RequireComponent(typeof(Rigidbody))]
public class IDou : MonoBehaviour
{
    //移動を行う秒間
    [SerializeField]
    public float timeout;
    //経過時間
    private float timeElapsed;
    //目的地
    private Vector3 destination;
    //スピード
    [SerializeField]
    private float Speed = 2.0f;
    //方向
    private Vector3 direction;
    //目的地に到着したフラグ
    private bool arrived;


    // Start is called before the first frame update
    void Start()
    {
        destination = new Vector3 (0f, 2f, -10f);
        arrived = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeElapsed += Time.deltaTime;

        Transform myTransform = this.transform;

        Vector3 Iti = myTransform.position;
        //Rigidbodyを取得
        Rigidbody Rb = this.GetComponent<Rigidbody> ();
        Vector3 force = new Vector3 (0f, 0f,  Speed * 0.0f);
        Rb.AddForce (force);
        //x.yのforceを0に設定
            force.x = 0.0f;
            force.y = 0.0f;
        //xが-、yが-の時にxを+、yを+に動かす
        if(Iti.x <= 0 && Iti.y <= 0 && timeElapsed >= timeout){
            force.x = 0.0f;
            force.y = 0.0f;
            force.x += Speed * Random.Range(150f, 200f);
            force.y += Speed * Random.Range(150f, 200f);
            Rb.AddForce (force);
            timeElapsed = 0.0f;
        }
        //xが-、yが+の時にxを+、yを-に動かす
        if (Iti.x <= 0 && Iti.y >= 0 && timeElapsed >= timeout){
            force.x = 0.0f;
            force.y = 0.0f;
            force.x += Speed * Random.Range(150f, 200f);
            force.y += Speed * Random.Range(-150f, -200f );
            Rb.AddForce (force);
            timeElapsed = 0.0f;
        }
        //xが+、yが-の時にxを-、yを+に動かす
        if (Iti.x >= 0 && Iti.y <= 0 && timeElapsed >= timeout){
            force.x = 0.0f;
            force.y = 0.0f;
            force.x += Speed * Random.Range(-150f, -200f );
            force.y += Speed * Random.Range(150f, 200f);
            Rb.AddForce (force);
            timeElapsed = 0.0f;
        }
        //xが+、yが+の時にxを-、yを-に動かす
        if (Iti.x >= 0 && Iti.y >= 0 && timeElapsed >= timeout){
            force.x = 0.0f;
            force.y = 0.0f;
            force.x += Speed * Random.Range(-150f, -200f );
            force.y += Speed * Random.Range(-150f, -200f );
            Rb.AddForce (force);
            timeElapsed = 0.0f;
        }
    }
}
