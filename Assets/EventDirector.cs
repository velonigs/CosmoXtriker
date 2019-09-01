using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDirector : MonoBehaviour {

    [SerializeField]
    private GameObject _striker;
    
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

    [SerializeField]
    private GameObject _waveController;

    [SerializeField]
    private GameObject _waveSpawn;

    [SerializeField]
    private GameObject _hanger;

    [SerializeField]
    private GameObject _DummyLeftCannon;

    [SerializeField]
    private GameObject _DummyRightCannon;

    [SerializeField]
    private GameObject _dlCannonPos;

    [SerializeField]
    private GameObject _drCannonPos;

    [SerializeField]
    private GameObject _LeftCannon;

    [SerializeField]
    private GameObject _RightCannon;

    [SerializeField]
    private GameObject _strikerHorogram;

    void Start() {
        
    }

    void Update() {
        if (_selectListNum == 5)
        {
            _DummyLeftCannon.SetActive(true);
            _DummyRightCannon.SetActive(true);
            float moveSpeed = 10.0f;
            float step = moveSpeed * Time.deltaTime;
            _DummyLeftCannon.transform.position = Vector3.MoveTowards(_DummyLeftCannon.transform.position, _dlCannonPos.transform.position, step);
            _DummyRightCannon.transform.position = Vector3.MoveTowards(_DummyRightCannon.transform.position, _drCannonPos.transform.position, step);
            _hatchFlg = true;
        }

        if (_DummyLeftCannon.transform.position == _dlCannonPos.transform.position && _DummyRightCannon.transform.position == _drCannonPos.transform.position) {
            _DummyLeftCannon.SetActive(false);
            _DummyRightCannon.SetActive(false);
            _LeftCannon.SetActive(true);
            _RightCannon.SetActive(true);
            _strikerHorogram.SetActive(true);
        }
    }

    IEnumerator OpenHatch() {
        float departureTime = 10.0f;
        float elapsedTime = 0.0f;
        while (departureTime > elapsedTime) {
            elapsedTime += Time.deltaTime;
            _hangerHatchUp.transform.position += new Vector3(0, 0.05f, 0);
            _hangerHatchDown.transform.position += new Vector3(0, -0.05f, 0);
            yield return null;
        }

        Destroy(_hangerHatchUp);
        Destroy(_hangerHatchDown);
        _hatchFlg = false;

        if (departureTime < elapsedTime) {
            StartCoroutine(StartActionCoroutine());
        }
        
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

        if (_selectListNum == 2) {
            _speed = 7.0f;
        }

        if (_selectListNum == 3) {
            _speed = 6.0f;
        }

        if (_selectListNum == 6) {
            _speed = 2.0f;
        }

        if (_selectListNum == 7) {
            _striker.GetComponent<PlayerController>().enabled = true;
            _striker.GetComponentInChildren<TuyoCannon>().enabled = true;
        }

        if (_selectListNum == 8) {
            /*_waveSpawn = Instantiate(_waveController, _waveSpawn.transform.position, Quaternion.identity);*/
            _waveController.SetActive(true);
            Destroy(_hanger);
        }

        if (_selectListNum < _transLists.Count) {
            if (_hatchFlg) {
                StartCoroutine(OpenHatch());
            } else {
                StartCoroutine(StartActionCoroutine());
            }
        }
    }

   /*void EquipWeapon() {
        if (BeamWeapon) {

        } else if (MissilePod) {

        }
    }*/
}