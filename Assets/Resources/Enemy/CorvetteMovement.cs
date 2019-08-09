using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorvetteMovement : MonoBehaviour
{
    [SerializeField] float Range = 0.03f;
    [SerializeField] float moveX;
    [SerializeField] float moveY;
    [SerializeField] float moveZ=-0.02f;
    float distanceToPlayer;
    //50以上必ず
    [SerializeField] float battleRange=50;
    [SerializeField] float moveSpeed=0.2f;
    [SerializeField] float changeMovementTimer = 3f;
    //100以上必ず
    [SerializeField] float maxDistance = 100f;
    float changeMovementCounter;
    [SerializeField]
    int changePhaseLimiter = 10;
    int phaseLimit;

    bool followPlayer;
    //動きの管理ため
    public enum moveBattlePhases { start=0,phase1,phase2,phase3}
    //現在
    public moveBattlePhases currentMovePhase;

    // Start is called before the first frame update
    void Start()
    {
        followPlayer = true;
        currentMovePhase = moveBattlePhases.start;
        //ランダム
        moveX = Random.Range(-Range, Range);
        moveY = Random.Range(-Range, Range);
        changeMovementCounter = changeMovementTimer;
        phaseLimit = changePhaseLimiter;

    }

    // Update is called once per frame
    void Update()
    {
        if (currentMovePhase==moveBattlePhases.start)
        {
            //プレーヤーへ向かって動く
            distanceToPlayer = (transform.position - PlayerController.instance.transform.position).sqrMagnitude;
            if (distanceToPlayer >= battleRange)
            {
                transform.position = Vector3.MoveTowards(transform.position, PlayerController.instance.transform.position,moveSpeed);
            }
            else
            {
                //近づいたら変更
                changePhase();
            }
         }
        if(currentMovePhase == moveBattlePhases.phase1)
        {
            changeMovementCounter -= Time.deltaTime;
            //時間がたったら、反対側へ動く、決めた回に繰り返す。カウンターゼロになったらphase変更
            if (changeMovementCounter <= 0)
            {
                ChangeMovementManagement();
            }
            
            transform.Translate(moveX, moveY,moveZ);
            if (changePhaseLimiter <= 0)
            {
                
                changePhase();
               
            }
        }
        if(currentMovePhase == moveBattlePhases.phase2)
        {
            changeMovementCounter -= Time.deltaTime;
            if (changeMovementCounter <= 0)
            {
                ChangeMovementManagement();
            }
            transform.Translate(moveX, moveY, moveZ);
            if (changePhaseLimiter <= 0)
            {
                changePhase();
            }
        }
        //三回目後ろへ動く、最高の距離までそのあと最初のphaseに戻る
        if (currentMovePhase == moveBattlePhases.phase3)
        {
            if (moveZ > 0)
            {
                moveZ = -moveZ;
            }
            
            distanceToPlayer = (transform.position-PlayerController.instance.transform.position).sqrMagnitude;
            if (distanceToPlayer <= maxDistance)
            {
                transform.Translate(0, 0, moveZ);
             }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(PlayerController.instance.transform.position.x,
                    PlayerController.instance.transform.position.y, transform.position.z), moveSpeed);
                //プレーヤーのｘとｙ座標と同じになる
                if (transform.position.x == PlayerController.instance.transform.position.x || transform.position.y == PlayerController.instance.transform.position.y)
                {
                    changePhase();
                }
                
            }
        }
}
  
    public void ChangeMovementManagement()
    {
        changeMovementCounter = changeMovementTimer;
        //+から-、-から+
        moveX *= -1;
        moveY *= -1;
        //カウンターを減らす
        changePhaseLimiter--;
    }
    public void changePhase()
    {
        currentMovePhase++;
       
        if (currentMovePhase >= moveBattlePhases.phase3)
        {
            //リセット
            currentMovePhase = 0;
        }
        //カウンターリセット
        changePhaseLimiter = phaseLimit;
        if (currentMovePhase != 0)
        {
            //ランダムの座標のリセット
            moveX = Random.Range(-Range, Range);
            moveY = Random.Range(-Range, Range);
            moveZ *= -1f;
        }
        
    }
}
