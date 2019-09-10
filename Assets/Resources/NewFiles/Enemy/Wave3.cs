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
    //Destroyerのアニメーション
    Animator destroyeranim;
    //SpaceStationのアニメーション
    Animator planetanim;
    //Corvetteスクリプト
   /* Corvette corvette3script;
    Corvette corvette6script;*/
    // Waveプレハブを収納する
    public GameObject[] waves;
    //現在のWave
    private int currentWave;
    CorvetteHEALTH corvette3script;
    CorvetteHEALTH corvette6script;

    void Start()
    {
      corvette3script = Corvette3.GetComponent<CorvetteHEALTH>();
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
                    //コルベットの当たり判定が出るまでWaveを止める
                    while(Corvette3.GetComponent<BoxCollider>().enabled == false){
                        yield return new WaitForEndOfFrame();
                    }
            }

            if (currentWave == 4){
                //一機目のコルベット殺
                if(corvette3script.currentHealth >= 0 && Corvette6.activeSelf == false){
                corvette3script.takeDamage(9999);
                }
                //退場するまで（意図として二機目が定位置に付くまで）Waveを止める
                while(Corvette3.activeSelf == true){
                    yield return new WaitForEndOfFrame();
                }
            }

            if(currentWave == 5){
                corvette6script = Corvette6.GetComponent<CorvetteHEALTH>();
            }

            //Corvette3が死んだ地点でCorvette6を沸かせるため
            if(corvette3script.currentHealth <= 0 && Corvette3.activeSelf == true){
                while(Corvette6.GetComponent<BoxCollider>().enabled == false){
                    yield return new WaitForEndOfFrame();
                }
                //Corvette6のHP取得用
                corvette6script = Corvette6.GetComponent<CorvetteHEALTH>();
            }

            if (currentWave == 2)
            {
                //corvette Event ProのAnimator起動
                CorvetteEvent3.GetComponent<Animator>().enabled = true;
                
            }
          
            //Waveを作成する,プレイヤーのポジションｘとｙと同じ講座
            GameObject wave = (GameObject)Instantiate(waves[currentWave], new Vector3(PlayerController.instance.transform.position.x, PlayerController.instance.transform.position.y, waves[currentWave].transform.position.z)
            , Quaternion.identity);

            //WaveをEmitterの子要素にする
            wave.transform.parent = transform;

            //Waveが4になったらDebrisPopをオンに
            //AsteroidEventPro 仮設置
            if (currentWave == 3)
            {
                this.Debri.GetComponent<DebrisPop>().enabled = true;
                Asteroid.GetComponent<Animator>().enabled = true;
            }
            //Waveが8になったらDebrisPopをオフに
            if (currentWave == 7){
                var iokasute = transform.GetChild(0).gameObject.GetComponent<AudioSource>();
                iokasute.Play();
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
            if (currentWave == 10){
                corvette6script.takeDamage(9999);
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
