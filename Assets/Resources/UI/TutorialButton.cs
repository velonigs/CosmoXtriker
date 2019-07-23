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
    private GameObject _callWave;

    [SerializeField]
    private GameObject _waveobj;

    [SerializeField]
    private GameObject _tutorialMovieDirecter;

    public bool _departureFlg = false;

    public bool _movementFlg = false;

    void Update() {
        
    }

    public void TutorialButtonYes() {
        _tutorialCanvas.SetActive(false);
        _tutorialMovieDirecter.SetActive(true);
        // チュートリアルムービーの表示
        _tutorialMovie.StartTutorialMovie();
    }

    public void TutorialButtonNo() {  
        // Destroy(_tutorialCanvas);
        _movementFlg = true;
        _tutorialCanvas.SetActive(false);
        // _waveobj = Instantiate(_callWave, _waveobj.transform.position, Quaternion.identity);
        // _departureFlg = true;
    }

    public void BackWeaponSelecter() {
        _tutorialCanvas.SetActive(false);
        // 装備画面の再表示
        _backWeaponSelecter.BackToEquipment();
    }

    // IEnumerator WaveSpawn() {
        
    //     yield return new WaitForSeconds(3.0f);
    //     yield break;
    // }
}
