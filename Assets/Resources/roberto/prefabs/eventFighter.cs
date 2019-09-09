using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventFighter : MonoBehaviour
{

    [SerializeField]
    eventJiki jiki;


    float firetime = 1;
    [SerializeField] EventBullet bullet;

    
    Vector3 target;

    float bulletSpeed = 0.2f;

    private void Start()
    {
        target = jiki.transform.position;
            
     }
    // Update is called once per frame
    void Update()
    {
        firetime -= Time.deltaTime;

        if (firetime <= 0)
        {
            firetime = 1;
            if (jiki != null)
            {
                EventBullet newBullet = Instantiate(bullet, transform.position, transform.rotation) as EventBullet;
                newBullet.givetarget(target);
            }


        }
    }

    private void OnDestroy()
    {
        jiki.GetComponent<eventJiki>().enemy = null;
    }
    private void OnDisable()
    {
        jiki.GetComponent<eventJiki>().enemy = null;
    }
}
