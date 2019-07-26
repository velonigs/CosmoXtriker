using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderMissile : MonoBehaviour
{
    [SerializeField] float maxDistance=200;
    [SerializeField] GameObject explosion;
    [SerializeField] float velocity = 4f;
    [SerializeField] float lifetime = 5f;
    PlayerController player;
    System.Action _callback = null;

    private Vector3 startPos;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        startPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, velocity);
        }
       
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            if (_callback != null)
                _callback();
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }

    public void Init(System.Action callback)
    {
        _callback = callback;
    }
    

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
