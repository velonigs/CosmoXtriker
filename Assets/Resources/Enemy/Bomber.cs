using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : fighter
    
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        base.Movement();
    } 
    public override void shot()
    {
        EnemyBullet bullet = Instantiate(bulletPrefab, spawnpoint[0].transform.position, spawnpoint[0].rotation);
        bullet.GetComponent<EnemyBullet>().damage *= damageMultipler;
    }

} 
