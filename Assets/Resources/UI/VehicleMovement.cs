using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour {

    [SerializeField]
    private GameObject _vehicle;

    [SerializeField]
    private TutorialButton _tutorialButton;
    
    void Start() {
        
    }

    
    void Update() {
        if (_tutorialButton._movementFlg) {
            Debug.Log("aaa");
            _vehicle.transform.localPosition += new Vector3(0, 0, 1);

        }
    }
}
