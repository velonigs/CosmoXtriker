using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave3 : MonoBehaviour
{
    // Debri収納
    GameObject Debri;
    // Corvette Wave3時
    [SerializeField]
    GameObject Corvette3;
    [SerializeField]
    GameObject CorvetteEvent3;
    // Corvette Wave6時
    [SerializeField]
    GameObject Corvette6;
   // [SerializeField]
   // GameObject CorvetteEvent6;
    //Asteroid Event
    [SerializeField]
    GameObject Asteroid;
    [SerializeField]
    GameObject Destroyerbody;
    Animator destroyeranim;
    Animator planetanim;
    // Waveプレハブを収納する
    public GameObject[] waves;
    //現在のWave
    private int currentWave;



    void Start()
    {
        this.Debri = GameObject.Find("Debri Sponner");
        planetanim = GameObject.Find("PlanetScalePivot").transform.GetComponent<Animator>();
        destroyeranim = GameObject.Find("DestroyerComplete2").transform.GetComponent<Animator>();
        StartCoroutine(StartWave());
    }

    IEnumerator StartWave()
    {
        while (waves.Length >= currentWave)
        {
            if (currentWave == 1)
            {
                //シーンにいるCorvetteのAnimatorを起動
                Corvette3.GetComponent<Animator>().enabled = true;
                Corvette3.GetComponent<Animator>().SetBool("Corvette3", true);

                /*//Animatorの終わりでCorvette3.csをActiveにするので、それまで待機
                while (Corvette3.GetComponent<Corvette>().enabled == false)
                {
                    yield return new WaitForEndOfFrame();
                }*/
            }
            if (currentWave == 2)
            {
                //corvette Event ProのAnimator起動
                CorvetteEvent3.GetComponent<Animator>().enabled = true;
                Corvette3.GetComponent<Animator>().SetBool("Corvette3", false);
            }
          
            //Waveを作成する,プレイヤーのポジションｘとｙと同じ講座
            GameObject wave = (GameObject)Instantiate(waves[currentWave], new Vector3(PlayerController.instance.transform.position.x, PlayerController.instance.transform.position.y, waves[currentWave].transform.position.z)
            , Quaternion.identity);

            //WaveをEmitterの子要素にする
            wave.transform.parent = transform;

            //Waveが5になったらDebrisPopをオンに
            if (currentWave == 4)
            {
                this.Debri.GetComponent<DebrisPop>().enabled = true;
            }
            //AsteroidEventPro 仮設置
            if (currentWave == 3)
            {
                Asteroid.GetComponent<Animator>().enabled = true;
            }
            //Waveが9になったらDebrisPopをオフに
            if (currentWave == 7)
            {
                this.Debri.GetComponent<DebrisPop>().enabled = false;
               // Corvette6.GetComponent<Animator>().SetTrigger("Stege out");
            }


            //Waveの子要素のEnemyがすべて消去されるまで待機する
            while (wave.activeSelf == true)
            {
                yield return new WaitForEndOfFrame();
            }
            //Waveの削除
            Destroy(wave);

            //格納されているWaveをすべて実行したらcurrentWaveを0にする（最初から->ループ）
            currentWave++;
            /*
            if (waves.Length <= currentWave)
            {
                currentWave = 0;
            }*/
            if (currentWave == 8)
            {
                break;
            }

            yield return null;
        }
        /* Destroyer起動 */
        destroyeranim.enabled = true;
        planetanim.SetBool("planettrigger", true);
    }
    void Update(){
    if(Destroyerbody.activeSelf == false){
        planetanim.SetBool("planettrigger2", true);
        }
    }
}
