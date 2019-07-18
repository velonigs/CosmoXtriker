using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMovie : MonoBehaviour {

    [SerializeField]
    private GameObject _tutorialMovie;

    public void StartTutorialMovie() {
        StartCoroutine(PlayTutorialMovie());
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Return)) {
            // チュートリアルムービーを閉じる
            _tutorialMovie.SetActive(false);
        }
    }

    IEnumerator PlayTutorialMovie() {
        yield return new WaitForSeconds(0.5f);
        _tutorialMovie.SetActive(true);
    }
}