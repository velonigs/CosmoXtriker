using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EventDirector))]
public class VehicleController : MonoBehaviour {

    public enum VehicleControlStatus {
        Idle,
        Action,
        Move,
        End
    };

    private EventDirector _eventAction;

    private VehicleControlStatus _isAction = VehicleControlStatus.Idle;

    public VehicleControlStatus IsAction {
        set {
            _isAction = value;
            _eventAction.StartAction(value);
        }
    }

    void Start () {
        _eventAction = GetComponent<EventDirector>();
    }
}