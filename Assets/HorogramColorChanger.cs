using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorogramColorChanger : MonoBehaviour {

    void Start () {
        
    }

    // 改善点：このスクリプトまで体力が反映されていないのでそれを解決する
                
    void Update () {
    }

    public void ColorChange_Green() {
        GetComponent<Renderer>().material.color = new Color32(0, 255, 0, 100);
    }

    public void ColorChange_Yellow() {
        GetComponent<Renderer>().material.color = new Color32(255, 255, 0, 100);
    }

    public void ColorChange_Red() {
        GetComponent<Renderer>().material.color = new Color32(255, 0, 0, 100);
    }
}