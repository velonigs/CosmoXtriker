using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour {

    [SerializeField]
    private GameObject _text;

    float fadeSpeed = 0.01f;
    float red, green, blue, alfa;

    private bool isFadeOut = false;

    Image fadeImage;
    
    void Start () {
        fadeImage = GetComponent<Image>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alfa = fadeImage.color.a;
    }
    
    void Update () {
        if (Input.anyKeyDown) {
            isFadeOut = true;
            _text.SetActive(false);
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
            SceneManager.LoadScene("CosmoTutorial");
            isFadeOut = false;
        }
    }
    void SetAlpha() {
        fadeImage.color = new Color(red, green, blue, alfa);
    }
}