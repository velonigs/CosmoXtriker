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
        foreach(var m in missiles)
        {
            if (m != null)
            {
                m.GetComponent<EnemyMissile>().giveATarget(this.transform.position);
            }
            
        }
        randx = Random.Range(-0.4f, 0.4f);
        randY = Random.Range(-0.4f, 0.4f);
    }
    private void Update()
    {
        transform.Translate(randx, randY, 0);
    }


}
