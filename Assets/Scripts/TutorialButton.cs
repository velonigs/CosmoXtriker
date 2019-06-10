using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButton : MonoBehaviour {

    [SerializeField]
    private GameObject _tutorialMovie;

    [SerializeField]
    private GameObject _tutorialCanvas;

    [SerializeField]
    private GameObject _weaponSelecter;

    void Update() {
        
    }

    public void TutorialButtonYes() {
        _tutorialCanvas.SetActive(false);
        _tutorialMovie.SetActive(true);

    }

    public void TutorialButtonNo() {
        Destroy(_tutorialCanvas);
    }

    public void BackWeaponSelecter() {
        _tutorialCanvas.SetActive(false);
        _weaponSelecter.SetActive(true);
    }

}
