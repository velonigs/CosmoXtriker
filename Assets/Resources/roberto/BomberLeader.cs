using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberLeader : _tmpEnemys
{



    Bomber[] allEnemyes;


    public override void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "Bullet")
        {
            ushort _dmg = collision.gameObject.GetComponent<_tmpBullet>().Damage;
            HP -= _dmg;
            if (HP <= 0)
            {

                allEnemyes = FindObjectsOfType<Bomber>();
                for (int i = 0; i < allEnemyes.Length; i++)
                {
                    allEnemyes[i].randomMove = true;
                }
                Instantiate(Explode, transform.position, transform.rotation); //現在位置にエフェクト生成
                                                                              //ゴミを作る
                spawnDebrids(3);
                gameObject.SetActive(false); //HP無くなったらDestroy

            }


        }
        if (collision.gameObject.name == "KillZone")
        {
            gameObject.SetActive(false); //KZ入ったらDestroy
        }
    }
}
