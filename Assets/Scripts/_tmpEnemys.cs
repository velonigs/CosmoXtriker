using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//基本敵クラス　これを継承して各敵クラスを作成する
public class _tmpEnemys : MonoBehaviour{
    public ushort HP = 20; //これがなくなったらDestroy
    public GameObject Explode; //撃破エフェクト

    [SerializeField]
    private int debritsNumberToSpawn;//ゴミ数
    public GameObject[] debridsToSpawn;//ゴミprefab
    //移動方向
    [SerializeField] private float IdouX;
    [SerializeField] private float IdouY;
    [SerializeField] private float IdouZ;

    void Start(){
        
    }
    void OnTriggerEnter(Collider collision){
            if(collision.gameObject.tag == "Bullet"){
            ushort _dmg = collision.gameObject.GetComponent<_tmpBullet>().Damage;
            HP -= _dmg;
            
        }
        if(collision.gameObject.name == "KillZone"){
            Destroy(this.gameObject); //KZ入ったらDestroy
        }
    }
    void Update(){
        Transform myTransform = this.transform; //Transformの設定？
        myTransform.Translate(IdouX, IdouY, IdouZ, Space.World); //World座標での移動
        if(HP <= 0){
            Destroy(this.gameObject); //HP無くなったらDestroy
            Instantiate (Explode, transform.position, transform.rotation); //現在位置にエフェクト生成
            //ゴミを作る
            spawnDebrids(debritsNumberToSpawn);
        }
    }
    /// <summary>
    /// ゴミ
    /// </summary>
    public  void spawnDebrids(int num)
    {
        for (int i = 0; i < num; i++)
        {
            ///オブジェクト配列の中でinstantiateするゴミを選択する
            int rand_Sel = Random.Range(0, debridsToSpawn.Length);
            //ランダムポジションを作ろうため
            float randomPos = Random.Range(-2, 2);
            Instantiate(debridsToSpawn[rand_Sel], new Vector3(transform.position.x + randomPos, transform.position.y + randomPos, transform.position.z + randomPos), transform.rotation);
        }
    }
}
