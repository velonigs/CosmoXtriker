using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corvette : MonoBehaviour, ITakeDamage
{
    [SerializeField] CannonMovement laserCannon;
    [SerializeField] LineRenderer laserLine;
   [SerializeField] float RotationSpeed=5f;
    [SerializeField] float cannonLoadingTime = 3f;
    float cannonShotCounter;
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
   Transform player;
    string currentAttack;
    [SerializeField]
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
        cannonShotCounter = cannonLoadingTime;
        laserCannon = GameObject.Find("mobileCannoX").GetComponent<CannonMovement>();
        currentHealth = health;
        laserAttackTime = laserAttackdelay;
        attack = "laser";
        currentAttack = "";
        player = PlayerController.instance.transform;
       

    }

    // Update is called once per frame
    void Update()
    {

        //攻撃タイプはレーサーじゃなければ
        if (attack != "laser")
        {
            laserCannon.canMove = false;
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
            laserCannon.canMove = true;
            cannonShotCounter -= Time.deltaTime;
          
            if (cannonShotCounter <= 0)
            {

                laserCannon.canMove = false;
            if (!laserLine.enabled)
            {

                laserLine.enabled = true;
            }


            laserAttackTime -= Time.deltaTime;
            RaycastHit laserHit;
            if(Physics.Raycast(laserSpawnPoint.position,laserSpawnPoint.forward,out laserHit))
            {
                if (laserHit.collider.GetComponent<HealthManager>())
                {
                    laserHit.collider.GetComponent<HealthManager>().Takedamage(1*damageMultipler);
                }
            }
            laserLine.SetPosition(0, laserSpawnPoint.position);
            laserLine.SetPosition(1, laserSpawnPoint.forward * 5000);
            
            if (laserAttackTime <= 0)
            {
                if (currentAttack == "") { currentAttack = "bullet"; }
                attack = currentAttack;
                    laserCannon.reassetting = true;
                    laserAttackTime = laserAttackdelay;
                
                   
            } } }  }

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
            Instantiate(explosion, transform.position, transform.rotation);
            //レーサー攻撃を使う
            attack = "laser";
            cannonShotCounter = cannonLoadingTime;
        }
        if (currentHealth == 100)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            attack = "laser";
            cannonShotCounter = cannonLoadingTime;
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
