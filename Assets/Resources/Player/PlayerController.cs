using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody _rb;
    public float moveSpeed = 11;
    public float moveForceMultiplier;
    public float boostCT;
    [SerializeField]
    float boostForceMultiplier;
    float _HorizontalInput;
    float _VerticalInput;
    public static PlayerController instance;
    public static float verticalFactor;
    private float _time;
    Vector3 moveVector = Vector3.zero;
    /// <summary>
    /// missile no tame
    /// </summary>
    [SerializeField]
    TargetMissile missile;
    [SerializeField]
    Transform missileSpawnPoint;
    [SerializeField]
    GameObject LastBoss;
    [SerializeField]
    GameObject LastBosspivot;

    [SerializeField]
    GameObject flayr;

    [SerializeField]
    float flayerDealay = 10f;

    float flayerTimer = 10f;
    bool flayerActive;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        _time = boostCT;
        _rb = GetComponent<Rigidbody>();
        flayerActive = true;
    }
    void Update()
    {
        _time += Time.deltaTime;
        _HorizontalInput = Input.GetAxis("Horizontal");
        _VerticalInput = Input.GetAxis("Vertical");
        moveVector = Vector3.zero;
        moveVector.x = moveSpeed * _HorizontalInput;
        moveVector.y = moveSpeed * _VerticalInput;
            if(LastBoss.transform.GetComponent<BossHealth>().enabled == true) //後で書き直し
        {
            transform.LookAt(LastBosspivot.transform);
                if(transform.position.y <= -30 && transform.position.y >= 30)
            {
                moveVector.y = -moveVector.y * 10;
            }
        }
        _rb.AddForce(moveForceMultiplier * (moveVector - _rb.velocity));
        verticalFactor = moveVector.y;

        if(Input.GetButtonDown("Boost") && _time >= boostCT){
            _time = 0.0f;
            _rb.AddForce(boostForceMultiplier * moveVector, ForceMode.Impulse);
        }


        if (!flayerActive)
        {
            flayerDealay -= Time.deltaTime;
            if (flayerDealay <= 0)
            {
                flayerActive = true;
                flayerDealay = flayerTimer;
            }
        }
        else
        {

            if (Input.GetButtonDown("Fire2"))
            {
                for (int i = 0; i < 6; i++)
                {
                    Instantiate(flayr, transform.position, transform.rotation);
                }
                flayerActive = false;
            }



        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit, Mathf.Infinity))
            {
                Transform target = hit.transform;
                ITakeDamage targetdmg = hit.transform.GetComponent<ITakeDamage>();
               
                if (targetdmg != null)
                {
                    TargetMissile newMissile = Instantiate(missile, missileSpawnPoint.position, missileSpawnPoint.rotation)as TargetMissile;
                    newMissile.GetComponent<TargetMissile>().giveTarget(target);
                }
            }
           

        }
    }
}