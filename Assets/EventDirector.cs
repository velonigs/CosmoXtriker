using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDirector : MonoBehaviour {

    [SerializeField]
    private List<Transform> _transLists = new List<Transform>();

    [SerializeField]
    private float _speed = 1.0f;

    private int _selectListNum = 0;

    private Vector3 _startPos;
    private Vector3 _endPos;
    private Quaternion _startRotate;
    private Quaternion _endRotate;
    private float _time;
    private float _deltaTime;
    private float _angle = 0;
    
    void Start() {

    }

    public void StartAction() {
        // _selectListNum = 0;
        _startPos = transform.localPosition;
        _endPos = _transLists[_selectListNum].localPosition;
        _startRotate = transform.rotation;
        _endRotate = _transLists[_selectListNum].rotation;
        _deltaTime = 1.0f / 120.0f;
        StartCoroutine(StartActionCoroutine());
    }

    IEnumerator StartActionCoroutine() {
        while (_time < 1.0f) {
            _time += _deltaTime;

            if (_time >= 1.0f) {
                _time = 1.0f;
            }

            var x = Mathf.Lerp(_startPos.x, _endPos.x, _time);
            var y = Mathf.Lerp(_startPos.y, _endPos.y, _time);
            var z = Mathf.Lerp(_startPos.z, _endPos.z, _time);
            transform.localPosition = new Vector3(x, y, z);

            transform.rotation = Quaternion.Lerp(_startRotate, _endRotate, _time);
            yield return null;
        }

        _angle = 0;

        if (_selectListNum == 0) {
            yield return null;
        }

        _selectListNum++;

        if (_selectListNum < _transLists.Count) {
            _startPos = transform.localPosition;
            _endPos = _transLists[_selectListNum].localPosition;
            _time = 0;
            StartCoroutine(StartActionCoroutine());
        }
    }
}