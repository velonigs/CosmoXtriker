using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody _rb;
    public float moveSpeed = 11;
    public float moveForceMultiplier;
    float _HorizontalInput;
    float _VerticalInput;
    public static PlayerController instance;
    [SerializeField]
    GameObject flayr;

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
        _HorizontalInput = Input.GetAxis("Horizontal");
        _VerticalInput = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Fire2"))
        {
            for(int i=0; i < 6; i++)
            {
                Instantiate(flayr, transform.position, transform.rotation);
            }
        }
    }
    void FixedUpdate()
    {
        Vector3 moveVector = Vector3.zero;

        moveVector.x = moveSpeed * _HorizontalInput;
        moveVector.y = moveSpeed * _VerticalInput;
        _rb.AddForce(moveForceMultiplier * (moveVector - _rb.velocity));
    }
}