using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerHead :_tmpEnemys
{
    [SerializeField] float chageAttackTimer = 10f;
    float changeAttackCounte;
    [SerializeField] float fireRate = 2f;
    public static DestroyerHead instance;
    [SerializeField]
    bomberMissile missiles;
    [SerializeField]
    Transform[] missileSpawnPoints;
    [SerializeField]
    DestroyerCannonAttack[] cannons;
    int currentAttack;
    float fireCounter;
    string attackType = "";
    bool missilesAttack { get { return attackType == "misile"; } } 
        
    bool bulletAttack { get { return attackType == "bullet"; } }
    private void Awake()
    {
        instance = this;
        attackType = "bullet";
    }

    private void Start()
    {
        fireCounter = fireRate;
        cannons = FindObjectsOfType<DestroyerCannonAttack>();
    }
    private void Update()
    {
        changeAttackCounte -= Time.deltaTime;
        if (changeAttackCounte <= 0)
        {
            changeAttackCounte = chageAttackTimer;
            if (attackType == "missile") { attackType = "bullet"; }
           else if (attackType == "bullet") { attackType = "missile"; }
            
            
        }
        fireCounter -= Time.deltaTime;
        if (fireCounter <= 0)
        {
            fireCounter = fireRate;
            if (bulletAttack)
            {
                for (; ; )
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
            if (missilesAttack)
            {

                Instantiate(missiles, missileSpawnPoints[currentAttack].position, missileSpawnPoints[currentAttack].rotation);
                currentAttack++;
                if (currentAttack >= missileSpawnPoints.Length) { currentAttack = 0; }

            }
        }
        
    }

}
