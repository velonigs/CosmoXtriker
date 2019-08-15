using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject MIA;
    [SerializeField]
    private float fadetime = 3.0f;
    private float _alpha = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.activeSelf == true){
            Image imagef = gameObject.GetComponent<Image>();
            _alpha += Time.deltaTime;
            imagef.color = new Color(0.0f, 0.0f, 0.0f, _alpha/fadetime);
            if(_alpha >= fadetime){
                MIA.SetActive(true);
            }
        }
    }
}
