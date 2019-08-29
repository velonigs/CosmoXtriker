using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _crosshairController : MonoBehaviour
{
    private Vector3 _angle = Vector3.zero; //ジョイコン入力
    [SerializeField] private float Sensitivity = 0.1f; //感度
    void Start()
    {
    }

    void Update()
    {
        _angle.x = Input.GetAxis("Mouse Y") * Sensitivity; //後でGetAxisの中身をジョイコンの操作のやつにする
        _angle.y = Input.GetAxis("Mouse X") * Sensitivity;

        this.gameObject.transform.localEulerAngles += _angle; //クロスヘアの角度をジョイコンの入力で += する

        //弾がレティクルの中心に飛ぶようにするにはカメラの位置と、Crosshairの座標が等しい必要がある。
        //理由は弾道のベクトル計算にメインカメラの座標を用いているためである。
        //VR化する際は、Updateの中で CameraRig座標 == Crosshair座標 とすればいいと思われる。
    }
}
