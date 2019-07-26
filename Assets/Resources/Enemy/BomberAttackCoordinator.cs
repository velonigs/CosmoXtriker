using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberAttackCoordinator : MonoBehaviour
{
     
    private float attackDelay=1f;
    private float attackTimer;
    [SerializeField]Transform[] attackPoints;
    [SerializeField] Bomber[] enemyes;
    [SerializeField]
    LeaderMissile _leadermissile;
    int missilenumbers = 0;
    int currentship = 0;
    Corvette[] corvettes = null;

    // Start is called before the first frame update
    void Start()
    {
        missilenumbers = 0;
        attackTimer = attackDelay;
        corvettes = FindObjectsOfType<Corvette>();
        if (corvettes != null)
        {
            for (int i = 0; i < corvettes.Length; i++)
            {
                corvettes[i].changeFase("bullet");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer -= Time.deltaTime;
        if (attackTimer <= 0)
        {
            attackTimer = attackDelay;
            if (enemyes[currentship] != null)
            {
                enemyes[currentship].shot();
            }
            
            currentship++;
            if (currentship >= enemyes.Length)
            {
                currentship = 0;
            }
            if (canAttack)
            {
                for(int i = 0; i < attackPoints.Length; i++)
                {
                    
                    var obj = Instantiate(_leadermissile, attackPoints[i].position, attackPoints[i].rotation);
                    obj.GetComponent<LeaderMissile>().Init(DestroyMissile);
                    missilenumbers++;
                }
                
            }

        }
    }

    private void DestroyMissile()
    {
       missilenumbers--;
    }

    public bool canAttack
    {
       get { return missilenumbers == 0; }
    }

}
