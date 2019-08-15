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
    [SerializeField]
    float damageMultipler = 0.5f;
    [SerializeField] EnemyMissile missiles;
    [SerializeField] EnemyBullet bullet;
    [SerializeField]
    private int debritsNumberToSpawn;//ゴミ数
    public GameObject[] debridsToSpawn;//ゴミprefab
    string attack = "";
    PlayerController player;
    string currentAttack;
    
    int health = 300;
    public int currentHealth;


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
        currentHealth = health;
        laserAttackTime = laserAttackdelay;
        attack = "laser";
        currentAttack = "";
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
            RaycastHit laserHit;
            if(Physics.Raycast(transform.position,transform.forward,out laserHit))
            {
                if (laserHit.collider.GetComponent<HealthManager>())
                {
                    laserHit.collider.GetComponent<HealthManager>().Takedamage(1*damageMultipler);
                }
            }
            laserLine.SetPosition(0, laserSpawnPoint.position);
            laserLine.SetPosition(1, transform.forward*5000);

            if (laserAttackTime <= 0)
            {
                if (currentAttack == "") { currentAttack = "bullet"; }
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
        
        currentHealth -= damageToTake;
        if (currentHealth == 200)
        {
            //レーサー攻撃を使う
            attack = "laser";
        }
        if (currentHealth == 100)
        {
            attack = "laser";
        }
        if (currentHealth <= 0)
        {
           
            Instantiate(explosion, transform.position, transform.rotation);
            spawnDebrids(debritsNumberToSpawn);
            gameObject.SetActive(false);
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
