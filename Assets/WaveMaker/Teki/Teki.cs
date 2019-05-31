
using UnityEngine;
using System.Collections;

public class Teki : MonoBehaviour
{
  // tekikihonコンポーネント
  Tekikihon tekikihon;

  void Start ()
  {

    // tekikihonコンポーネントを取得
    tekikihon = GetComponent<Tekikihon> ();

    // ローカル座標のY軸のマイナス方向に移動する
    tekikihon.Move (transform.forward);
  }
}