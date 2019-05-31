using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _tmpWeapon : MonoBehaviour{
    public GameObject Bullet;
    public Transform RightMuzzle;
    public Transform LeftMuzzle;
    [SerializeField]private ushort Damage = 1;
    [SerializeField]private ushort RPM = 120;
    [SerializeField]private ushort speed = 1000;

    private float _tmpfire = 0;
    private float _lastfired = 0;
    Vector3 force;

    void Start(){
        _tmpfire = RPM / 60.0f;
    }
    void shot(){
        GameObject Bullets = Instantiate(Bullet) as GameObject;
        force = this.gameObject.transform.forward * speed;
        Bullets.GetComponent<Rigidbody>().AddForce(force);
        Bullets.transform.position = RightMuzzle.position;

        Bullets = Instantiate(Bullet) as GameObject;
        force = this.gameObject.transform.forward * speed;
        Bullets.GetComponent<Rigidbody>().AddForce(force);
        Bullets.transform.position = LeftMuzzle.position;
    }

    void Update(){
        if (Input.GetKey(KeyCode.Z) && Time.time - _lastfired > 1 / _tmpfire){
            _lastfired = Time.time;
            shot();
        }
    }
}