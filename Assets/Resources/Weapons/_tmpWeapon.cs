using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _tmpWeapon : MonoBehaviour{
    public GameObject Bullet; //使用する弾丸
    public Transform RightMuzzle; //右の銃口
    public Transform LeftMuzzle; //左の銃口
    public ushort RPM = 120; //分間連射速度
    public ushort speed = 1; //弾速
    GameObject Leftcannon;
    GameObject Bullets;
    private LeftCannonRotation cannonsc;

    public float _tmpfire = 0.0f;
    public float _lastfired = 0.0f;
    Vector3 force; //弾にかかるforce
    Vector3 _poss;
    Vector3 _bulletvec;

    
    public void Start(){
        _tmpfire = 60.0f / RPM; //RPM（分間連射速度）に変換
        
        Leftcannon = GameObject.Find("LeftJointPivot");
        cannonsc = Leftcannon.GetComponent<LeftCannonRotation>();
    }
    public void shot(){
        Bullets = Instantiate(Bullet) as GameObject; // Bullet呼び出し
        _bulletvec = _poss - RightMuzzle.transform.position;
        force = _bulletvec.normalized * speed; // 銃口の正面に対してspeedをかけてforce
        Bullets.GetComponent<Rigidbody>().AddForce(force); // Addforce
        Bullets.transform.position = RightMuzzle.position; // 発射位置

        Bullets = Instantiate(Bullet) as GameObject;
        _bulletvec = _poss - LeftMuzzle.transform.position;
        force = _bulletvec.normalized * speed;
        Bullets.GetComponent<Rigidbody>().AddForce(force);
        Bullets.transform.position = LeftMuzzle.position;
    }

    void Update(){
        _poss = cannonsc._pos2;
        _lastfired += Time.deltaTime;
        if (_lastfired >= _tmpfire){
            _lastfired = _tmpfire;
                if(Input.GetButton("Fire1")){
            _lastfired = 0.0f;
            shot(); //Button取得 -> 最後に発射した時間から数えてRPM分の連射速度でshot()を呼び出す
            }
        }
    }
}
  
