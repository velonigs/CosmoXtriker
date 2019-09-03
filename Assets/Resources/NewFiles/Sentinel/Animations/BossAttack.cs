using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public enum State { Attacka = 1, Attackb, Attackc, Attackd }
    public State currentState;
    Animator anim;
    public static int changeCounter;
    State attackMemory;
    BossBulletsSpawner bulletSpawner;
    bool canAttack;
    float missileTime = 3,missileCounter;

    public enum phase {  phase1=1,  phase2 , phase3 }
   public phase currentphase = phase.phase1;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        bulletSpawner = GetComponent<BossBulletsSpawner>();
        changeCounter = 3;
        currentState = State.Attacka;
        LastBossHealth.instance.healthIsLess += healtISLess;

    }

    // Update is called once per frame
    void Update()
    {

        switch (currentState)
        {
            case State.Attacka: anim.SetInteger("atk", 1); break;
            case State.Attackb: anim.SetInteger("atk", 2); break;
            case State.Attackc: anim.SetInteger("atk", 3); break;
            case State.Attackd: missileSpawn();break;

        }
        

    }

    private void missileSpawn()
    {
        missileCounter -= Time.deltaTime;
        if (missileCounter <= 0)
        {
            missileCounter = missileTime;
            bulletSpawner.MissileAttack();
            goToIdle();
        }

        
    }

    public void goToIdle()
    {
        changeCounter--;

        if (changeCounter <= 0)
        {
            changeCounter = 3;
            currentState++;
            switch (currentphase)
            {
                case phase.phase1:
                    if (currentState > State.Attackb)
                    {
                        currentState = State.Attacka;
                    }
                    break;

                case phase.phase2:
                    if (currentState > State.Attackc)
                    {
                        currentState = State.Attackc;
                    }
                    break;
                case phase.phase3:
                    if (currentState > State.Attackd)
                    {
                        currentState = State.Attacka;
                    }
                    break;


            }

        }
        if (currentState != State.Attacka) {
            BossBulletsSpawner.canAttack = false;
                }

    }


    public void healtISLess(int num)
    {
        if (num == 2)
        {
            currentState = State.Attackc;
            currentphase = phase.phase2;
        }
        else if (num == 3)
        {
            currentState = State.Attackd;
            currentphase = phase.phase3;
        }
    }
}

