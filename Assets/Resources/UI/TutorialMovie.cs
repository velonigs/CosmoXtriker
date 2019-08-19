using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMovie : MonoBehaviour {

    [SerializeField]
    private GameObject _tutorialMovie;

    [SerializeField]
    private GameObject _tutorialMovieDirecter;

    public bool _movementFlg = false;

    public void StartTutorialMovie() {
        StartCoroutine(PlayTutorialMovie());
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Return)) {
            // チュートリアルムービーを閉じる
            _tutorialMovie.SetActive(false);
            _movementFlg = true;
        }
    }

    IEnumerator PlayTutorialMovie() {
        yield return new WaitForSeconds(0.5f);
        _tutorialMovie.SetActive(true);
    }
}