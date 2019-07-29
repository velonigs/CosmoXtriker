using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EventDirector))]
public class VehicleController : MonoBehaviour {

    public enum VehicleControlStatus {
        Idle,
        Action,
        End
    };

    private EventDirector _eventAction;

    private VehicleControlStatus _isAction = VehicleControlStatus.Idle;

    public VehicleControlStatus IsAction {
        set {
            _isAction = value;
            if (VehicleControlStatus.Action == _isAction) {
                _eventAction.StartAction();
            }
        }
        get {
            return _isAction;
        }
    }

    void Start () {
        _eventAction = GetComponent<EventDirector>();
    }

    void Update () {
    }
}