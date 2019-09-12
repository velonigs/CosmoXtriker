using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerHead :MonoBehaviour
{
    [SerializeField] float chageAttackTimer = 10f;
    [SerializeField]
    float changeAttackCounte;
    [SerializeField] float fireRate = 2f;
    public static DestroyerHead instance;
    [SerializeField]
    bomberMissile missiles;
    [SerializeField]
    Transform[] missileSpawnPoints;
    [SerializeField]
    DestroyerCannonAttack[] cannons;
    int bulletCount,missileCount;
    float fireCounter;
    Corvette[] allcorvette;
    GameObject planet;
    public enum attackType { bullet,missile}
    public attackType Type;

    private void Awake()
    {
        instance = this;
        Type = attackType.bullet;
    }

    private void Start()
    {
        planet = GameObject.Find("PlanetScalePivot").gameObject;
        fireCounter = fireRate;
        cannons = FindObjectsOfType<DestroyerCannonAttack>();
        allcorvette = FindObjectsOfType<Corvette>();
        if (allcorvette != null)
        {
            foreach(var cor in allcorvette)
            {
                cor.GetComponent<Animator>().SetTrigger("end");
            }

        }
    }
    private void Update()
    {
        changeAttackCounte -= Time.deltaTime;
        if (changeAttackCounte <= 0)
        {
            changeAttackCounte = chageAttackTimer;
            switch (Type)
            {
                case attackType.bullet:Type = attackType.missile; break;
                case attackType.missile:Type = attackType.bullet; break;
            }
        }
        fireCounter -= Time.deltaTime;
        if (fireCounter <= 0)
        {
            fireCounter = fireRate;
            if (Type==attackType.bullet)
            {
                
                for (int i=0;i<cannons.Length;i++)
                {
                    
                    if (cannons[bulletCount] != null)
                    {
                        cannons[bulletCount].fire();
                        bulletCount++;
                        if (bulletCount >= cannons.Length) { bulletCount = 0; }
                        break;
                    }
                    else { continue; }
                }
            }
            else
            {
                Instantiate(missiles, missileSpawnPoints[missileCount].position, missileSpawnPoints[missileCount].rotation);
                missileCount++;
                if (missileCount >= missileSpawnPoints.Length) { missileCount = 0; }

            }
        }
        
    }

    private void OnDisable()
    {

        planet.GetComponent<AudioSource>().Play();
        planet.GetComponent<Animator>().SetBool("planettrigger",false);
        PlayerController.instance.Bossbattle = true;
    }

}
