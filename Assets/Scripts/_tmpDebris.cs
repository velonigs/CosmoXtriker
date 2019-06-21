using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _tmpDebris : MonoBehaviour
{
    public GameObject Explode;
    [SerializeField] private float DebrisLifeTime = 10.0f;
    [SerializeField] private ushort HP = 20;
    private float _timeElapsed = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider collision){
        HP -= 10;
        Debug.Log(HP);
    }
    void Update()
    {
        _timeElapsed += Time.deltaTime;
        if(_timeElapsed >= DebrisLifeTime){
            _timeElapsed = 0.0f;
            Destroy(this.gameObject);
        }
        if(HP <= 0){
            Destroy(this.gameObject);
            Instantiate (Explode, transform.position, transform.rotation);
        }
    }
}
