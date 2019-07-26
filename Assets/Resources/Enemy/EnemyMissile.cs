using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissile : MonoBehaviour
{
    
    [SerializeField] GameObject explosion;
    [SerializeField] float velocity = 4f;
    [SerializeField] float lifetime = 5f;
   
    System.Action _callback = null;



   // Update is called once per frame
    void Update()
    {
        if (PlayerController.instance != null)
        {
            //プレイヤーへ動く
            transform.position = Vector3.MoveTowards(transform.position, PlayerController.instance.transform.position, velocity);
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
        Destroy(gameObject);
        Instantiate(explosion, transform.position, transform.rotation);
       
    }
  
}
/*  var posDiff = (startPos - transform.localPosition).magnitude;
        if(posDiff > maxDistance)
        {
            if (_callback != null)
                _callback();
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }*/
