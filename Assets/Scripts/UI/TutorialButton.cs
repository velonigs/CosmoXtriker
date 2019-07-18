using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButton : MonoBehaviour {

    [SerializeField]
    private GameObject _tutorialCanvas;

    [SerializeField]
    private GameObject _weaponSelecter;

    [SerializeField]
    private TutorialMovie _tutorialMovie;

    [SerializeField]
    private BackWeaponSelecter _backWeaponSelecter;

    [SerializeField]
    private Wave3 _wave3;

    void Update() {
        
    }

    public void TutorialButtonYes() {
        _tutorialCanvas.SetActive(false);
        // チュートリアルムービーの表示
        _tutorialMovie.StartTutorialMovie();
    }

    public void TutorialButtonNo() {
        Destroy(_tutorialCanvas);
        _wave3.startCor();
    }

    public void BackWeaponSelecter() {
        _tutorialCanvas.SetActive(false);
        // 装備画面の再表示
        _backWeaponSelecter.BackToEquipment();
    }
}
