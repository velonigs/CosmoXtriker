using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fighter : _tmpEnemys
{
    public bool randomMove;
    //最小と最大の値を決める
    [SerializeField] private float minValue=-0.1f;
    [SerializeField] private float MaxValue=0.1f;
    //プレーヤーへ向かう
    [SerializeField] private float moveZ = -0.2f;
    float movex;
    float movey;
    // Start is called before the first frame update
    void Start()
    {
        randomMove = false;
        //ｘとｙ座標をランダムに決める
        movex = Random.Range(minValue, MaxValue);
        movey = Random.Range(minValue, MaxValue);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    public override void Movement()
    {
        if (!randomMove)
        {
            base.Movement();
        }
        else
        {
            transform.Translate(movex, movey, moveZ);
        }
       
    }

}
