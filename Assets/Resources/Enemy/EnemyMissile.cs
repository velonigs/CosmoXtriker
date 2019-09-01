using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissile : MonoBehaviour
{

    [SerializeField] GameObject explosion;
    [SerializeField] float velocity = 4f,rotateSpeed=1;
    [SerializeField] float lifetime = 5f;
    [SerializeField] int damage = 10;
    [SerializeField]
    float veloctyTimeFactor = 100f;
    System.Action _callback = null;
    bool followPlayer;
    Transform player;
    Vector3 newTarget;

    private void Start()
    {
        followPlayer = true;
        if(PlayerController.instance!=null)
        player = PlayerController.instance.transform;

        
    }
    // Update is called once per frame
    void Update()
    {
        if (followPlayer)
        {
            if (PlayerController.instance != null)
            {
                //プレイヤーへ動く
                transform.position = Vector3.MoveTowards(transform.position, player.position, velocity*(Time.deltaTime*veloctyTimeFactor));
                transform.position.Normalize();
                Vector3 dir = player.position - transform.position;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), rotateSpeed * Time.deltaTime);
            }
        }
        else
        {
            //flayrのため
        
            transform.position = Vector3.MoveTowards(transform.position, newTarget, velocity * (Time.deltaTime * veloctyTimeFactor));
            transform.position.Normalize();
        }
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            //時間が経ったら爆発する、callbackで敵シップにメッセージを送る
            if (_callback != null)
                _callback();
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }

    //callback
    public void Init(System.Action callback)
    {
        _callback = callback;
    }

    //削除
    private void OnTriggerEnter(Collider other)
    {
        if (_callback != null)
            _callback();
        if (other.tag == "Player"|| other.name == "KillZone")
        {
            
            
            if (other.tag == "Player")
            {
                other.GetComponent<HealthManager>().Takedamage(damage);
                Instantiate(explosion, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
       

    }
    //新しいtargetを作る
    public void giveATarget(Vector3 pos)
    {

        newTarget = pos;
        followPlayer = false;
    }
        
}
  
