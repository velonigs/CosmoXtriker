using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private GameObject _tutorialMovieDirecter;

    void Start() {
        
    }

    void Update() {
        
    }

    public void TutorialButtonYes() {
        _tutorialCanvas.SetActive(false);
        _tutorialMovieDirecter.SetActive(true);
        // チュートリアルムービーの表示
        SceneManager.LoadScene("CosmoTutorial");
    }

    public void TutorialButtonNo() {
        _tutorialCanvas.SetActive(false);
    }

    public void BackWeaponSelecter() {
        _tutorialCanvas.SetActive(false);
        // 装備画面の再表示
        _backWeaponSelecter.BackToEquipment();
    }
}
