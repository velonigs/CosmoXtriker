﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    [SerializeField]
    private GameObject _equipment;

    [SerializeField]
    private GameObject _titleCanvas;

    [SerializeField]
    private GameObject _weaponSelecter;

    private bool _equipmentFlg = false;

    private bool _spawnPanel = false;

    void Start() {
        StartCoroutine(WaitAction());
    }
    void Update() {

        if (_spawnPanel && _equipmentFlg == false) {
            Destroy(_titleCanvas);
            StartCoroutine(EquipmentPanel());
        }
    }

    IEnumerator WaitAction() {
        yield return new WaitForSeconds(4.0f);
        _spawnPanel = true;

    }

    IEnumerator EquipmentPanel() {
        _equipmentFlg = true;
        yield return new WaitForSeconds(0.5f);
        //_equipment.SetActive(true);
        _weaponSelecter.SetActive(true);
    }
}
