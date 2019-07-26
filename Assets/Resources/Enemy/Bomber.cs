using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : fighter
    
{
    
    // Update is called once per frame
    void Update()
    {
        base.Movement();
    } 
    //オバーライドで関数の中身が変更できる
    public override void shot()
    {
        EnemyBullet bullet = Instantiate(bulletPrefab, spawnpoint[0].transform.position, spawnpoint[0].rotation);
        //バレットのダメージをかけ２
        bullet.GetComponent<EnemyBullet>().damage *= damageMultipler;
    }

} 
