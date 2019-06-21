using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackWeaponSelecter : MonoBehaviour {

    [SerializeField]
    private GameObject _weaponSelecter;
    
    public void BackToEquipment() {
        StartCoroutine(BackToWS());
    }

    IEnumerator BackToWS() {
        yield return new WaitForSeconds(0.5f);
        _weaponSelecter.SetActive(true);
    }
}