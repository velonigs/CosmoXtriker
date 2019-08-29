using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {

    float fadeSpeed = 0.005f;
    float red, green, blue, alfa;

    private bool isFadeIn = false;

    Image fadeImage;
    
    void Start () {
        isFadeIn = true;
        fadeImage = GetComponent<Image>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alfa = fadeImage.color.a;
    }
    
    void Update () {
        if (isFadeIn) {
            StartFadeIn();
        }
    }

    void StartFadeIn() {
        alfa -= fadeSpeed;
        SetAlpha();
        if (alfa <= 0) {
            isFadeIn = false;
            fadeImage.enabled = false;
        }
    }

    void SetAlpha() {
        fadeImage.color = new Color(red, green, blue, alfa);
    }
}