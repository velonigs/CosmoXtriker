using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _tmpDebris : MonoBehaviour
{
    [SerializeField] private float DebrisLifeTime = 10.0f;
    [SerializeField] private ushort HP = 20;
    private float _timeElapsed = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider collision){
        HP -= 10;
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
        }
    }
}
