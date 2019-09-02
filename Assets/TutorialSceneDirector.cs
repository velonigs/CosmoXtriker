using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialSceneDirector : MonoBehaviour {
    
    void Start() {
        
    }

    
    void Update() {
        if (Input.GetKeyDown(KeyCode.Return)) {
            SceneManager.LoadScene("CosmoXtriker.ver0");
        }
    }
}
