using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    // Waveプレハブを収納する
    public GameObject[] waves;
    //現在のWave
    private int currentWave;
    GameObject wave;
    private GameObject miniboss;

    void Start()
    {
        
    }
    void wavemake(){
        //Waveを作成する
        wave = (GameObject)Instantiate(waves[currentWave], transform.position, Quaternion.identity);
        //Waveをこいつの子要素にする
        wave.transform.parent = transform;
    }
    public IEnumerator wavecor(){
        while(waves.Length > currentWave){
        wavemake();
        yield return new WaitForSeconds(7);
        currentWave++;
        }
            yield break;
    }

    public void startCor()
    {
        StartCoroutine(wavecor());
    }
    void Update()
    {
    }
}
