using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialFadeOut : MonoBehaviour {

    [SerializeField]
    private TutorialButton _tutorialButton;

    float fadeSpeed = 0.01f;
    float red, green, blue, alfa;

    public bool isFadeOut = false;

    Image fadeImage;

    void Start() {
        fadeImage = GetComponent<Image>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alfa = fadeImage.color.a;
    }

    void Update() {
        if (_tutorialButton._endTutorialFlg) {
            isFadeOut = true;
        }

        if (isFadeOut) {
            StartFadeOut();
        }

    }

    public void StartFadeOut() {
        fadeImage.enabled = true;
        alfa += fadeSpeed;
        SetAlpha();
        if (alfa >= 1) {
            SceneManager.LoadScene("CosmoXtriker.ver0");
            isFadeOut = false;
        }
    }
    public void SetAlpha() {
        fadeImage.color = new Color(red, green, blue, alfa);
    }
}