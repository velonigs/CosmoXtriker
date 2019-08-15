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
    private float _time = 3.0f;
    public static PlayerController instance;
    Vector3 moveVector = Vector3.zero;
   

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
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
            if(Input.GetButtonDown("Boost") && _time >= boostCT){
                _time = 0.0f;
                _rb.AddForce(boostForceMultiplier * moveVector, ForceMode.Impulse);
            }

    }
}