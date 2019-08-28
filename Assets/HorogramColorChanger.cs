using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorogramColorChanger : HealthManager {

    private Material _material;
    
    void Start () {
        _material = GetComponent<Renderer>();
    }

    
    void Update () {
        //HPバーの色を変化させる
        //HPが50%以上であれば緑から黄色へ、HPが50%未満であれば黄色から赤色へ変化する
        if (currentHealth > startingHealth / 2) {
            //色はRGB表記
            //最初は(R=0,G=255,B=0)で開始、Rを0→255に変化させて緑→黄色
            _material.color = new Color32((byte)MapValues(currentHealth, startingHealth / 2, startingHealth, 255, 0), 255, 0, 255);
        } else {
            //HP50%未満では(R=255,G=255,B=0)で開始、Gを255→0に変化させて黄色→赤
            _material.color = new Color32(255, (byte)MapValues(currentHealth, 0, startingHealth / 2, 0, 255), 0, 255);
        }
    }

    public float MapValues(float x, float inMin, float inMax, float outMin, float outMax) {
        return (x - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}