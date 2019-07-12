using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave3 : MonoBehaviour
{
    // Waveプレハブを収納する
    public GameObject[] waves;
    //現在のWave
    private int currentWave;

    void Start()
    {
        StartCoroutine(StartWave());
    }

    IEnumerator StartWave()
    {
        while (true)
        {

            //Waveを作成する
            GameObject wave = (GameObject)Instantiate(waves[currentWave], transform.position, Quaternion.identity);

            //WaveをEmitterの子要素にする
            wave.transform.parent = transform;

            //Waveの子要素のEnemyがすべて消去されるまで待機する
            while (wave.transform.childCount != 0)
            {
                yield return new WaitForEndOfFrame();
            }
            //Waveの削除
            Destroy(wave);

            //格納されているWaveをすべて実行したらcurrentWaveを0にする（最初から->ループ）
            currentWave++;
            if (waves.Length <= currentWave)
            {
                currentWave = 0;
            }

            yield return null;
        }
    }
}
