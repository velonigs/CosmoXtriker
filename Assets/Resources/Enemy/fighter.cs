using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fighter : _tmpEnemys
{
    public bool randomMove;
    [SerializeField]
    EnemyBullet bulletPrefab;
    [SerializeField]
    Transform[] spawnpoint;
    //最小と最大の値を決める
    [SerializeField] private float minValue=-0.1f;
    [SerializeField] private float MaxValue=0.1f;
    //プレーヤーへ向かう
    [SerializeField] private float moveZ = -0.2f;
    float movex;
    float movey;
    bool battlequit = false;
    private PlayerController player;
    bool battleAsset = false;
    float attackdelay = 1f;
    private float attackrange = 30;
    [SerializeField]
    int damageMultipler=1;
    // Start is called before the first frame update
    void Start()
    {
        randomMove = false;
        //ｘとｙ座標をランダムに決める
        movex = Random.Range(minValue, MaxValue);
        movey = Random.Range(minValue, MaxValue);
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    public override void Movement()
    {
        if (!randomMove)
        {
            base.Movement();
        }
        else
        {
            if (!battleAsset)
            {
                transform.Translate(movex, movey, moveZ);
                StartCoroutine(resetBattlePositionCo());
            }
            else
            {
                var disstancetoplayer = (transform.position - player.transform.position).sqrMagnitude;

                if (!battlequit)
                {
                    if (disstancetoplayer <= 500 && disstancetoplayer > attackrange)
                    {

                        this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, 0.2f);
                       // transform.LookAt(player.transform, Vector3.up);
                     // transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
                     }
                    if (disstancetoplayer <= attackrange)
                    {
                        battlequit = true;
                    }
                }
                else
                {
                    transform.Translate(0, 0, 0.2f);
                }
                   
                    
                  
                 
               
                attackdelay -= Time.deltaTime;
                if (attackdelay <= 0)
                {
                    attackdelay = 1f;
                    shot();
                    

                }
            }
            
        }
       
    }

    IEnumerator resetBattlePositionCo()
    {
        yield return new WaitForSeconds(1f);
        battleAsset = true;

    }

    public void shot()
    {
        StartCoroutine(shotCo());
    }
    IEnumerator shotCo()
    {
       EnemyBullet bullet= Instantiate(bulletPrefab, spawnpoint[0].transform.position, spawnpoint[0].transform.rotation);
        bullet.GetComponent<EnemyBullet>().damage *= damageMultipler;

        yield return new WaitForSeconds(0.5f);
        if (spawnpoint[1] != null)
        {
            EnemyBullet bulletTwo = Instantiate(bulletPrefab, spawnpoint[1].transform.position, spawnpoint[1].transform.rotation);
            bulletTwo.GetComponent<EnemyBullet>().damage *= damageMultipler;
        }
       

    }

}
