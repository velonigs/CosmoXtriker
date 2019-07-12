﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class missile : MonoBehaviour
{
    private _tmpEnemys nearestEnemy;
    private _tmpEnemys[] allaEnemyes;
    private IOrderedEnumerable<_tmpEnemys> enemiesbyDistance;
    [SerializeField]
    private float missileVelocity = 0.4f;

    private void Awake()
    {
        allaEnemyes = FindObjectsOfType<_tmpEnemys>();
        enemiesbyDistance=allaEnemyes.OrderBy(t=>Vector3.Distance(this.transform.position,t.transform.position));
        
    }
    private void OnEnable()
    {
        nearestEnemy = findNearestEnemy();
       
   }

    private _tmpEnemys findNearestEnemy()
    {
        return allaEnemyes.OrderBy(enemy => Vector3.Distance(this.transform.position, enemy.transform.position)).FirstOrDefault();
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
        this.transform.position = Vector3.MoveTowards(transform.position, nearestEnemy.transform.position, missileVelocity);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("Hit");
        }
        Destroy(gameObject);
    }
}
