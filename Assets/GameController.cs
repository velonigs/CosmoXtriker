using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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