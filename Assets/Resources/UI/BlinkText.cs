using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkText : MonoBehaviour {

    [SerializeField]
    private GameObject _text;

    private float _nextTime;
    public float _interval = 0.8f;
    
    void Start () {
        _nextTime = Time.time;
    }

    
    void Update () {
        if (Time.time > _nextTime) {
            float alpha = _text.GetComponent<CanvasRenderer>().GetAlpha();
            if (alpha == 1.0f) {
                _text.GetComponent<CanvasRenderer>().SetAlpha(0.0f);
            } else {
                _text.GetComponent<CanvasRenderer>().SetAlpha(1.0f);
            }
            _nextTime += _interval;
        }
    }
}