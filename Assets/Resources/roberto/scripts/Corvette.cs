using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corvette : MonoBehaviour, ITakeDamage
{
    [SerializeField] CannonMovement laserCannon;
    [SerializeField] GameObject explosion;
    //attackポジション
    [SerializeField] Transform[] missileSpawnpoints;
    [SerializeField] Transform[] bulletsSpawnPoints;
    //時間
    [SerializeField] float attackdelay = 2f;
     float attackTimer;
    [SerializeField]
    float damageMultipler = 0.5f;
    [SerializeField] EnemyMissile missiles;
    public EnemyBullet bullet;
    [SerializeField]
    private int debritsNumberToSpawn;//ゴミ数
    public GameObject[] debridsToSpawn;//ゴミprefab
    string attack = "";
   Transform player;
    string currentAttack;
    [SerializeField]
     int health = 300;
    public int currentHealth;
    [SerializeField] float offset;
    CorvetteLaser corvetteLaser;
    bool death;
    public bool corvette1;
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
       laserCannon = GameObject.Find("mobileCannoX").GetComponent<CannonMovement>();
        currentHealth = health;
        currentAttack = "";
        player = PlayerController.instance.transform;
        changeFase("laser");
        corvetteLaser = GetComponent<CorvetteLaser>();

    }

    // Update is called once per frame
    void Update()
    {

        //攻撃タイプはレーサーじゃなければ
        if (attack != "laser")
        {
            laserCannon.canMove = false;
            
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
    
   }

    //バレット攻撃
 public IEnumerator bulletFire() {
        if(player.transform.position.y>transform.position.y-offset)
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
        if (corvetteLaser != null)
        {
            if (!corvetteLaser.Shot)
            {
                currentAttack = faseTochange;
                attack = currentAttack;
            }
        }
      
        
        if (attack == "laser")
        {
            laserCannon.canMove = true;
            CorvetteLaser laser= GetComponent<CorvetteLaser>();
            if (laser != null)
            {
                laser.LaserActive();
            }
        }
        
       
    }

    public void takeDamage(int damageToTake)
    {
        
        currentHealth -= damageToTake;
        if (currentHealth == 500)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            //レーサー攻撃を使う
            changeFase("laser");
            
        }
        if (currentHealth == 250)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            changeFase("laser");

        }
        if (currentHealth <= 0)
        {
            if (!death)
            {
                death = true;
                Instantiate(explosion, transform.position, transform.rotation);
                spawnDebrids(debritsNumberToSpawn);
            }

            if (corvette1)
            {
                GetComponent<Animator>().SetTrigger("Stege out");
            }
          
           
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            ushort _dmg = other.gameObject.GetComponent<_tmpBullet>().Damage;
           
            takeDamage(_dmg);
        }
        if (other.tag == "Player")
        {
            takeDamage(10);
            other.GetComponent<HealthManager>().Takedamage(10);
        }
    }

}
