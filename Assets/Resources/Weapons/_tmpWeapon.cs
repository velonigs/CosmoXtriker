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
    private LeftCannonRotation cannonsc;

    private float _tmpfire = 0;
    private float _lastfired = 0;
    Vector3 force; //弾にかかるforce
    Vector3 _poss;
    Vector3 _bulletvec;

    [SerializeField]
    GameObject flayr;

    [SerializeField]
    float flayerDealay = 10f;

    float flayerTimer = 10f;
    bool flayerActive;
    void Start(){
        _tmpfire = RPM / 60.0f; //RPM（分間連射速度）に変換
        flayerActive = true;
        Leftcannon = GameObject.Find("LeftJointPivot");
        cannonsc = Leftcannon.GetComponent<LeftCannonRotation>();
    }
    void shot(){
        GameObject Bullets = Instantiate(Bullet) as GameObject; // Bullet呼び出し
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
        if (Input.GetButton("Fire1") && Time.time - _lastfired > 1 / _tmpfire)
        {
            _lastfired = Time.time;
            shot(); //Key取得 -> 最後に発射した時間から数えてRPM分の連射速度でshot()を呼び出す

        }

            if (!flayerActive)
            {
                flayerDealay -= Time.deltaTime;
                if (flayerDealay <= 0)
                {
                    flayerActive = true;
                    flayerDealay = flayerTimer;
                }
            }
            else
            {
                
                    if (Input.GetButtonDown("Fire2"))
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            Instantiate(flayr, transform.position, transform.rotation);
                        }
                    flayerActive = false;
                }

                   
                
            }
        }

}
  
