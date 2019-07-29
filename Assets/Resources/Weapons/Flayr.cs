using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flayr : MonoBehaviour
{
    EnemyMissile[] missiles;
    float randx, randY;
    // Start is called before the first frame update
    void Start()
    {
        missiles = FindObjectsOfType<EnemyMissile>();
        
        randx = Random.Range(-0.1f, 0.1f);
        randY = Random.Range(-0.1f, 0.1f);
    }
    private void Update()
    {
        foreach (var m in missiles)
        {
            if (m != null)
            {
                m.GetComponent<EnemyMissile>().giveATarget(this.transform.position);
            }

        }
        transform.Translate(randx, randY, 0);
    }


}
