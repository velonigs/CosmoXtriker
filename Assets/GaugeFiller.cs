using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeFiller : MonoBehaviour
{
    TuyoCannon script;
    Image image;
    private float offset;

    void Start()
    {
        image = this.gameObject.GetComponent<Image>();
        image.fillAmount = 0.0f;
        script = GameObject.Find("Jiki").GetComponent<TuyoCannon>();
    }

    void Update()
    {
        offset = script._tmpfire / 0.45f;
        image.fillAmount = script._lastfired / offset;
    }
}
