using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissile : MonoBehaviour
{

    [SerializeField] GameObject explosion;
    [SerializeField] float velocity = 4f;
    [SerializeField] float lifetime = 5f;
    [SerializeField] int damage = 10;
    System.Action _callback = null;
    bool followPlayer;
    Vector3 newTarget;

    private void Start()
    {
        followPlayer = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (followPlayer)
        {
            if (PlayerController.instance != null)
            {
                //プレイヤーへ動く
                transform.position = Vector3.MoveTowards(transform.position, PlayerController.instance.transform.position, velocity);
            }
        }
        else
        {
            //flayrのため
            transform.position = Vector3.MoveTowards(transform.position, newTarget, velocity);
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
        if (other.tag == "Player")
        {
            other.GetComponent<HealthManager>().Takedamage(damage);
        }
        Destroy(gameObject);
        Instantiate(explosion, transform.position, transform.rotation);

    }
    //新しいtargetを作る
    public void giveATarget(Vector3 pos)
    {

        newTarget = pos;
        followPlayer = false;
    }
        
}
  
