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
        StartCoroutine("wavecor");
    }
    void wavemake(){
        
        //Waveを作成する,プレイヤーのポジションｘとｙと同じ講座
        wave = (GameObject)Instantiate(waves[currentWave], new Vector3(PlayerController.instance.transform.position.x,PlayerController.instance.transform.position.y,transform.position.z)
            , Quaternion.identity);
        //Waveをこいつの子要素にする
        wave.transform.parent = transform;
    }
    IEnumerator wavecor(){
        while(waves.Length > currentWave){
        wavemake();
        yield return new WaitForSeconds(7);
        currentWave++;
        }
            yield break;
    }
    void Update()
    {
    }
}
