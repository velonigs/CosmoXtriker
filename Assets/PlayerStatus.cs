using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public int playerHP = 100;
    public int playerATK = 0;

    void Start()
    {

    }
    private void OnTriggerEnter(Collider collider)
    {
        playerHP -= 0;
    }
    void Update()
    {
        if (playerHP <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}