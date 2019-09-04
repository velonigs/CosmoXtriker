using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialSceneDirector : MonoBehaviour {

    [SerializeField]
    private GameObject _tutorialCanvas;

    [SerializeField]    
    private GameObject _doingTutorial;
    
    void Start() {
        StartCoroutine(ConfirmWindow());
    }

    
    void Update() {
        if (Input.GetKeyDown(KeyCode.Return)) {
            SceneManager.LoadScene("CosmoXtriker.ver0");
        }
    }

    IEnumerator ConfirmWindow() {
        yield return new WaitForSeconds(4.0f);
        _tutorialCanvas.SetActive(true);
        _doingTutorial.SetActive(true);
    }
}
