using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotater : MonoBehaviour {

    private WeaponSelecter _weaponSelecter;

    void Start(){
        _weaponSelecter = GetComponent<WeaponSelecter>();
    }
    void Update() {
        // 装備が選択済みでなかったら回転する
        // if (_weaponSelecter.IsSelected != true) {
            transform.Rotate(Vector3.up * 0.1f, Space.Self);
        // }
    }
}
