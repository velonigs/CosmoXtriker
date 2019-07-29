using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _crosshairController : MonoBehaviour
{
    private Vector3 _angle = new Vector3(0, 0, 0); //ジョイコン入力
    [SerializeField] private float Sensitivity = 0.1f; //感度
    void Start()
    {
    }

    void Update()
    {
        _angle.x = Input.GetAxis("Mouse Y") * Sensitivity; //後でGetAxisの中身をジョイコンの操作のやつにする
        _angle.y = Input.GetAxis("Mouse X") * Sensitivity;
        this.gameObject.transform.localEulerAngles += _angle; //クロスヘアの角度をジョイコンの入力で += する
    }
}
