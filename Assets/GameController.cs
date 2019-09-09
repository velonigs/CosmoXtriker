using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Video;

/// <summary>
/// ゲーム内のイベントなどを起動させる
/// </summary>
public class GameController : MonoBehaviour {

    [SerializeField]
    private VehicleController _vehicle;

    [SerializeField]
    private GameObject _equipmentCanvas;

    //[SerializeField]
    //private GameObject Credit_Manager;

    private bool _equipmentCanvasFlg = false;

    private bool _departureFlg = false;
    private bool _flg1 = false;

    void Start() {

        
        StartCoroutine(WaitTime());

    }


    void Update() {

        //if (Credit_Manager.activeSelf == false)
        //{
        //    _flg1 = true;
        //}

        if (_departureFlg) {
            _vehicle.IsAction = VehicleController.VehicleControlStatus.Action;
            //Credit_Manager.SetActive(true);
            _flg1 = false;
        }

        

    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(17.0f);
        _departureFlg = true;
    }
}