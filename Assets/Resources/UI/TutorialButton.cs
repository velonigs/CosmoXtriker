using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(TutorialFadeOut))]
public class TutorialButton : MonoBehaviour {

    [SerializeField]
    private GameObject _tutorialCanvas;

    public bool _endTutorialFlg = false;
    public bool _beginTutorial = false;

    void Start() {
        
    }

    void Update() {
        
    }

    public void TutorialButtonYes() {
        _tutorialCanvas.SetActive(false);
        _beginTutorial = true;
    }

    public void TutorialButtonNo() {
        _tutorialCanvas.SetActive(false);
        _endTutorialFlg = true;
    }
}
