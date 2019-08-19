using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerHead :_tmpEnemys
{
    [SerializeField] float fireRate = 2f;
    public static DestroyerHead instance;
    [SerializeField]
    DestroyerCannon[] cannons;
    int currentAttack;
    float fireCounter;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        fireCounter = fireRate;
        cannons = FindObjectsOfType<DestroyerCannon>();
    }
    private void Update()
    {
        fireCounter -= Time.deltaTime;
        if (fireCounter <= 0)
        {
            fireCounter = fireRate;
            
            for(; ; )
            {
                if (cannons[currentAttack] != null)
                {
                    cannons[currentAttack].fire();
                    currentAttack++;
                    if (currentAttack >= cannons.Length) { currentAttack = 0; }
                    break;
                }
            }
        }
    }

}
