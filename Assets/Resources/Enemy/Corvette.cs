using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corvette : MonoBehaviour, ITakeDamage
{
    [SerializeField] LineRenderer laserLine;
   
    [SerializeField] GameObject explosion;
    //attackポジション
    [SerializeField] Transform[] missileSpawnpoints;
    [SerializeField] Transform laserSpawnPoint;
    [SerializeField] Transform[] bulletsSpawnPoints;
    //時間
    [SerializeField] float attackdelay = 2f;
    float laserAttackTime;
    [SerializeField] float laserAttackdelay = 5f;
    float attackTimer;
    //
    [SerializeField] EnemyMissile missiles;
    [SerializeField] EnemyBullet bullet;
    [SerializeField]
    private int debritsNumberToSpawn;//ゴミ数
    public GameObject[] debridsToSpawn;//ゴミprefab
    string attack = "";
    PlayerController player;
    string currentAttack;
    int health = 300;


    //attack文字列によって攻撃は違う
    public bool missileAttack
    {
        get { return attack == "missile"; }
    }
    public bool bulletAttack
    {
        get { return attack == "bullet"; }
    }
    public bool laserAttack
    {
        get { return attack == "laser"; }
    }  
    // Start is called before the first frame update
    void Start()
    {
        
        laserAttackTime = laserAttackdelay;
        attack = "laser";
        
        player = FindObjectOfType<PlayerController>();//プレイヤーを探す
    }

    // Update is called once per frame
    void Update()
    {
        //攻撃タイプはレーサーじゃなければ
        if (attack != "laser")
        {
            laserLine.enabled = false;
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0)
            {
                attackTimer = attackdelay;

                if (bulletAttack)
                {
                    StartCoroutine(bulletFire());
                }
                else if (missileAttack)
                {
                    missileFire();
                }
            }
        }
        //レーサーだったら、時間が終わるまでレーサーを使う
        else
        {
            if (!laserLine.enabled)
            {

                laserLine.enabled = true;
            }


            laserAttackTime -= Time.deltaTime;

            laserLine.SetPosition(0, laserSpawnPoint.position);
            laserLine.SetPosition(1, player.transform.position);

            if (laserAttackTime <= 0)
            {
                attack = currentAttack;
                laserAttackTime = laserAttackdelay;
                
            }

        }


        
    }

    //バレット攻撃
 public IEnumerator bulletFire() {

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < bulletsSpawnPoints.Length; j++)
            {
                Instantiate(bullet, bulletsSpawnPoints[j].position, bulletsSpawnPoints[j].rotation);
            }
            yield return new WaitForSeconds(0.5f);
        }


    }
    //ミサイル攻撃
    void missileFire() {
        for (int i = 0; i < missileSpawnpoints.Length; i++)
        {
            Instantiate(missiles, missileSpawnpoints[i].position, missileSpawnpoints[i].rotation);
        }
    }


    //攻撃タイプを変更する
    public void changeFase(string faseTochange)
    {
       
        currentAttack = faseTochange;
        attack = currentAttack;
        
       
    }

    public void takeDamage(int damageToTake)
    {
        
        health -= damageToTake;
        if (health == 200)
        {
            //レーサー攻撃を使う
            attack = "laser";
        }
        if (health == 100)
        {
            attack = "laser";
        }
        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            spawnDebrids(debritsNumberToSpawn);
            Destroy(gameObject);
        }
    }
    public void spawnDebrids(int num)
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
}
