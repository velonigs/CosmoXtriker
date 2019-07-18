﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _tmpWeapon : MonoBehaviour{
    public GameObject Bullet; // 使用する弾丸
    public Transform RightMuzzle; // 右の銃口
    public Transform LeftMuzzle; // 左の銃口
    public ushort RPM = 120; // 分間連射速度
    public ushort speed = 1000; // 弾速

    private float _tmpfire = 0;
    private float _lastfired = 0;
    Vector3 force; // 弾にかかるforce

    void Start(){
        _tmpfire = RPM / 60.0f; // RPM（分間連射速度）に変換
    }
    void shot(){
        GameObject Bullets = Instantiate(Bullet) as GameObject; // Bullet呼び出し
        force = RightMuzzle.transform.forward * speed; // 銃口の正面に対してspeedをかけてforce
        Bullets.GetComponent<Rigidbody>().AddForce(force); // Addforce
        Bullets.transform.position = RightMuzzle.position; // 発射位置

        Bullets = Instantiate(Bullet) as GameObject;
        force = LeftMuzzle.transform.forward * speed;
        Bullets.GetComponent<Rigidbody>().AddForce(force);
        Bullets.transform.position = LeftMuzzle.position;
    }

    void Update(){
        if (Input.GetButton("Fire1") && Time.time - _lastfired > 1 / _tmpfire){
            _lastfired = Time.time;
            shot(); // Key取得 -> 最後に発射した時間から数えてRPM分の連射速度でshot()を呼び出す
        }
    }
}