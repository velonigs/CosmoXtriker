using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    // Waveプレハブを収納する
    public GameObject[] waves;
    //現在のWave
    private int currentWave;

    void Start()
    {
    }
    void wavemake(){
        //Waveを作成する
        GameObject wave = (GameObject)Instantiate(waves[currentWave], transform.position, Quaternion.identity);
        //Waveをこいつの子要素にする
        wave.transform.parent = transform;
    }
    void Update()
    {
        while (waves.Length > currentWave)
        {
            wavemake();
            currentWave++;
        }
    }
}
