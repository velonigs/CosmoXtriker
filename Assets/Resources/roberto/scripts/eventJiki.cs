using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventJiki : MonoBehaviour
{
    float firetime = 1;
    [SerializeField] EventBullet bullet;

   
   public  Transform enemy;
    Vector3 target;

    float bulletSpeed = 0.2f;
    private void Start()
    {
        target = enemy.position;
    }
    // Update is called once per frame
    void Update()
    {
        firetime -= Time.deltaTime;

        if (firetime <= 0)
        {
            firetime= 1;
            if (enemy != null)
            {
                EventBullet newBullet = Instantiate(bullet, transform.position, transform.rotation) as EventBullet;
                newBullet.givetarget(target);
            }
            

        }
        
       
    }
}
