using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _tmpBullet : MonoBehaviour{
    [SerializeField] private float BulletLifeTime = 3.0f;
    private float _timeElapsed = 0.0f;

    void Start(){
        
    }

    // Update is called once per frame
    void Update()
    {
        _timeElapsed += Time.deltaTime;
        if(_timeElapsed >= BulletLifeTime){
            _timeElapsed = 0.0f;
            Destroy(this.gameObject);
        }
    }
}
