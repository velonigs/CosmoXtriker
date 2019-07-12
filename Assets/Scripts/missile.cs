using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class missile : MonoBehaviour
{
    public _tmpEnemys nearestEnemy;
    private _tmpEnemys[] allaEnemyes;
    private IOrderedEnumerable<_tmpEnemys> enemiesbyDistance;


    private void Awake()
    {
        allaEnemyes = FindObjectsOfType<_tmpEnemys>();
        enemiesbyDistance=allaEnemyes.OrderBy(t=>Vector3.Distance(transform.position,t.transform.position));
        
    }
    private void OnEnable()
    {
        nearestEnemy = findNearestEnemy();
        int maxhp = allaEnemyes.Max(t => t.HP);
    }

    private _tmpEnemys findNearestEnemy()
    {
        return allaEnemyes.OrderBy(enemy => Vector3.Distance(transform.position, enemy.transform.position)).FirstOrDefault();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemiesbyDistance.FirstOrDefault();
        nearestEnemy = findNearestEnemy();
    }
}
