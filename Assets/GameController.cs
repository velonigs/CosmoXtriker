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
    private GameObject _tutorialCanvas;

    private bool _tutorialCanvasFlg = false;
    
    void Start () {
        _tutorialCanvasFlg = _tutorialCanvas.activeSelf;
    }

    
    void Update () {
        if (_tutorialCanvas.activeSelf == false && _tutorialCanvasFlg != _tutorialCanvas.activeSelf) {
            _vehicle.IsAction = VehicleController.VehicleControlStatus.Action;
        }

        _tutorialCanvasFlg = _tutorialCanvas.activeSelf;
    }
}