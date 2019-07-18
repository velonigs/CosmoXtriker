using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tekikihon : MonoBehaviour
{
  // 移動スピード
  public float speed;

  // 弾を撃つ間隔
  public float shotDelay;

  // 弾のPrefab
  public GameObject bullet;

  // 弾の作成
  public void Shot (Transform origin)
  {
    Instantiate (bullet, origin.position, origin.rotation);
  }

  // 機体の移動
  public void Move (Vector3 direction)
  {
    GetComponent<Rigidbody>().velocity = direction * speed;
  }
}