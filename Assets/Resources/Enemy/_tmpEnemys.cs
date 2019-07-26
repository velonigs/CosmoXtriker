
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//基本敵クラス　これを継承して各敵クラスを作成する
public class _tmpEnemys : MonoBehaviour ,ITakeDamage {
    
    public GameObject Explode; //撃破エフェクト

    [SerializeField]
    private int debritsNumberToSpawn;//ゴミ数
    public GameObject[] debridsToSpawn;//ゴミprefab
    //移動方向
   private float IdouX;
     private float IdouY;
    private float IdouZ;


    public int HP = 20;

    void Start(){
        
    }
    public virtual void OnTriggerEnter(Collider collision){
            if(collision.gameObject.tag == "Bullet"){
            ushort _dmg = collision.gameObject.GetComponent<_tmpBullet>().Damage;
            takeDamage(_dmg);

         

        }
        if(collision.gameObject.name == "KillZone"){
            Destroy(this.gameObject); //KZ入ったらDestroy
        }
    }
    void Update(){

        Movement();
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
            //ランダムポジションを作るため
            float randomPos = Random.Range(-2, 2);
            Instantiate(debridsToSpawn[rand_Sel], new Vector3(transform.position.x + randomPos, transform.position.y + randomPos, transform.position.z + randomPos), transform.rotation);
        }
    }

    public virtual void shot()
    {

    }
    public virtual  void Movement()
    {
        Transform myTransform = this.transform; //Transformの設定？
        myTransform.Translate(IdouX, IdouY, IdouZ, Space.World); //World座標での移動*/

}

    public void takeDamage(int damage)
    {
        HP -= damage;

        if (HP <= 0)
        {
            Destroy(this.gameObject); //HP無くなったらDestroy
            Instantiate(Explode, transform.position, transform.rotation); //現在位置にエフェクト生成
                                                                          //ゴミを作る
            spawnDebrids(debritsNumberToSpawn);
        }
    }
}
