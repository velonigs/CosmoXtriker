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
        _rb = GetComponent<Rigidbody>();
        flayerActive = true;
    }
    void Update()
    {
        _HorizontalInput = Input.GetAxis("Horizontal");
        _VerticalInput = Input.GetAxis("Vertical");

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
    void FixedUpdate()
    {
        Vector3 moveVector = Vector3.zero;

        moveVector.x = moveSpeed * _HorizontalInput;
        moveVector.y = moveSpeed * _VerticalInput;
        _rb.AddForce(moveForceMultiplier * (moveVector - _rb.velocity));

    }
}