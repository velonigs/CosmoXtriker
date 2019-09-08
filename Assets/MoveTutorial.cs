using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTutorial : MonoBehaviour {

    [SerializeField]
    private GameObject _moveTutorialCollision;

    private bool _battleTutorialFlg = false;
    public bool BattleTutorialFlg {
        get {
            return _battleTutorialFlg;
        }
    }
    
    void Start() {
        
    }

    
    void Update() {
        
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            _battleTutorialFlg = true;
            Destroy(_moveTutorialCollision);
        }
    }

    
}
