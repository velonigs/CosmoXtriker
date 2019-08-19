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

    }
}