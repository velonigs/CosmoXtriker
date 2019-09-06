﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDefault : MonoBehaviour {

    [SerializeField]
    private GameObject _striker;
    
    [SerializeField]
    private TutorialCore _tutorialCore;

    [SerializeField]
    private GameObject _defaultPosition;

    [SerializeField]
    private float _returnSpeed = 10.0f;

    private Rigidbody _rigidbody;

    private bool _endReturnMove = false;
    public bool EndReturnMove {
        get {
            return _endReturnMove;
        }
    }

    void Start() {
        _rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }

    void Update() {
        float _time = _returnSpeed * Time.deltaTime;

        if (_tutorialCore.ReturnDefault) {
            _striker.GetComponent<Rigidbody>().Sleep();
            _striker.GetComponent<PlayerController>().enabled = false;
            _striker.transform.position = Vector3.MoveTowards(transform.position, _defaultPosition.transform.position, _time);
        }

        if (_striker.transform.position == _defaultPosition.transform.position) {
            _striker.GetComponent<Rigidbody>().WakeUp();
            _striker.GetComponent<PlayerController>().enabled = true;
            Vector3 playerpos=_striker.transform.position;
            Vector3 defaultPos=_defaultPosition.transform.position;
            Debug.Log("player"+ playerpos+"/"+"defaultpos"+defaultPos);
            _endReturnMove = true;
           
        }
    }
}
