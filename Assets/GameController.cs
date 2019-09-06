using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲーム内のイベントなどを起動させる
/// </summary>
public class GameController : MonoBehaviour {

    [SerializeField]
    private VehicleController _vehicle;

    [SerializeField]
    private GameObject _equipmentCanvas;

    [SerializeField]
    private GameObject Credit_Manager;

    private bool _equipmentCanvasFlg = false;

    void Start () {
        _equipmentCanvasFlg = _equipmentCanvas.activeSelf;
    }

    
    void Update () {


        if (_equipmentCanvas.activeSelf == false && _equipmentCanvasFlg != _equipmentCanvas.activeSelf) {
            _vehicle.IsAction = VehicleController.VehicleControlStatus.Action;
            Credit_Manager.SetActive(true);
            }

        _equipmentCanvasFlg = _equipmentCanvas.activeSelf;

    }
}