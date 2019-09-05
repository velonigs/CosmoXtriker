using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flayr : MonoBehaviour
{
    GameObject[] missiles;
    float randx, randY;
    // Start is called before the first frame update
    void Start()
    {
        missiles = GameObject.FindGameObjectsWithTag("AIMissile");
        
        randx = Random.Range(-0.1f, 0.1f);
        randY = Random.Range(-0.1f, 0.1f);
    }
    private void Update()
    {
        foreach (var m in missiles)
        {
            if (m != null)
            {
                //ミサイルについてあるインタフェースにアクセスして
                IMissile<Vector3> i_miss = m.GetComponent<IMissile<Vector3>>();
                if (i_miss != null)
                {
                    //targetとして自分のポジションを入れる
                    i_miss.giveATarget(this.gameObject.transform.position);
                }
            }

        }
        transform.Translate(randx, randY, 0);
    }


}
