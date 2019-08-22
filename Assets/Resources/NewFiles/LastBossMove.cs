using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastBossMove : MonoBehaviour
{
    public static LastBossMove instance;
    Transform player;
    [SerializeField] float rotatespeed = 2;
    public bool loockPlayer;

    private void Awake()
    {
        instance = this; 
    }
    // Start is called before the first frame update
    void Start()
    {
        loockPlayer = true;
        player = PlayerController.instance.transform;
        LastBossHealth.instance.healthIsLess += dontLoockPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        if (loockPlayer)
        {
            transform.LookAt(player, Vector3.up);
            transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
        }
     
    }

    public void dontLoockPlayer(int num)
    {
        if (num == 1)
        {
            loockPlayer = false;
        }
        
    }
    private void OnDisable()
    {
        LastBossHealth.instance.healthIsLess -= dontLoockPlayer;
    }
}
