using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : CorvetteMovement
{

    [SerializeField]
    GameObject bullet;
    [SerializeField] float fireDelay=2f;
    float fireCounter;
    [SerializeField] Transform spawnpoint;

    private void Start()
    {
        Initialize();
        fireCounter = fireDelay;
    }
    private void Update()
    {
        Move();
        fireCounter -= Time.deltaTime;
        if (fireCounter <= 0)
        {
            fireCounter = fireDelay;
            Instantiate(bullet, spawnpoint.position, spawnpoint.rotation);
        }
    }

}
