using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDirector : MonoBehaviour {
    
    [SerializeField]
    private GameObject _hangerHatchUp;

    [SerializeField]
    private GameObject _hangerHatchDown;

    [SerializeField]
    private List<Transform> _transLists = new List<Transform>();

    [SerializeField]
    private float _speed = 1.0f;

    private int _selectListNum = 0;

    private bool _hatchFlg = false;   

    private bool _departureFlg = false;

    void Update() {
        if (_selectListNum == 5) {
            _hatchFlg = true;
        }

        if (_hatchFlg) {
            StartCoroutine(OpenHatch());
        }

    }

    IEnumerator OpenHatch() {
        _hangerHatchUp.transform.position += new Vector3(0, 0.1f, 0);
        _hangerHatchDown.transform.position += new Vector3(0, -0.1f, -0);
        yield return new WaitForSeconds(6.5f);
        _hangerHatchUp.SetActive(false);
        _hangerHatchDown.SetActive(false);
        _departureFlg = true;
    }
 
    public void StartAction(VehicleController.VehicleControlStatus action) {
        _selectListNum = 0;
        StartCoroutine(StartActionCoroutine());
    }

    IEnumerator StartActionCoroutine() {
        // 移動
        float elapsedTime = 0.0f;
        // 開始時点での座標と回転
        Vector3 fromPos = transform.position;
        Quaternion fromRot = transform.rotation;

        while (elapsedTime < _speed) {
            if (elapsedTime > _speed) {
                elapsedTime = _speed;
            }
            var normalizedTime = Mathf.InverseLerp(0, _speed, elapsedTime);
            transform.localPosition = Vector3.Lerp(fromPos, _transLists[_selectListNum].position, normalizedTime);
            transform.localRotation = Quaternion.Lerp(fromRot, _transLists[_selectListNum].rotation, normalizedTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        _selectListNum++;

        if (_selectListNum < _transLists.Count) {
            StartCoroutine(StartActionCoroutine());
        }
    }
}