using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorogramBlinker : MonoBehaviour {

    [SerializeField]
    private GameObject _strikerHorogram;

    public float _blinkInterval = 0.1f;
    public float _endBlinkTime = 2.0f;

    private bool _blinkFlg = false;
    private float _elapsedTime;
    private float _sumTime;

    void Start() {
        
    }

    void Update() {
        if (_strikerHorogram.activeSelf) {
            StartCoroutine(Blink());
            _blinkFlg = true;
        }
    }

    IEnumerator Blink() {
        _sumTime += Time.deltaTime;
        _elapsedTime += Time.deltaTime;
        var renderComponent = GetComponent<MeshRenderer>();
        if (_elapsedTime >= _blinkInterval && _blinkFlg) {
            _elapsedTime = 0.0f;
            renderComponent.enabled = !renderComponent.enabled;
            if (_sumTime >= _endBlinkTime) {
                _blinkFlg = false;
            }
        }
        yield return new WaitForSeconds(_endBlinkTime);
        _blinkFlg = false;
        if (!renderComponent.enabled) {
            renderComponent.enabled = true;
        }
    }
}
