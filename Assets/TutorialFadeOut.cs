using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialFadeOut : MonoBehaviour {

    float fadeSpeed = 0.01f;
    float red, green, blue, alfa;

    private bool isFadeOut = false;

    Image fadeImage;

    void Start() {
        fadeImage = GetComponent<Image>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alfa = fadeImage.color.a;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.P)) {
            isFadeOut = true;
        }

        if (isFadeOut) {
            StartFadeOut();
        }

    }

    void StartFadeOut() {
        fadeImage.enabled = true;
        alfa += fadeSpeed;
        SetAlpha();
        if (alfa >= 1) {
            SceneManager.LoadScene("CosmoXtriker.ver0");
            isFadeOut = false;
        }
    }
    void SetAlpha() {
        fadeImage.color = new Color(red, green, blue, alfa);
    }
}