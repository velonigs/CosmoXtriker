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

    void Update() {
        
    }

    public void TutorialButtonYes() {
        _tutorialCanvas.SetActive(false);
<<<<<<< HEAD:Assets/Scripts/TutorialButton.cs
        _tutorialMovie.SetActive(true);

=======
        // チュートリアルムービーの表示
        _tutorialMovie.StartTutorialMovie();
>>>>>>> 269631059e91e80b892c67eeae03162747195085:Assets/AL_Title/TutorialButton.cs
    }

    public void TutorialButtonNo() {
        Destroy(_tutorialCanvas);
    }

    public void BackWeaponSelecter() {
        _tutorialCanvas.SetActive(false);
        // 装備画面の再表示
        _backWeaponSelecter.BackToEquipment();
    }
}
