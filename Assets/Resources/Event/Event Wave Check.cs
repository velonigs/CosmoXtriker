using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventWaveCheck : MonoBehaviour
{
    [SerializeField]
    GameObject C3;
    [SerializeField]
    GameObject C6;

    GameObject WaveCon;

    Wave3 script;
    // Start is called before the first frame update
    void Start()
    {
        this.WaveCon = GameObject.Find("WaveCon(clone)");

        script = WaveCon.GetComponent<Wave3>();
    }

    // Update is called once per frame
    void Update()
    {
        /*int WaveC = script.currentWave;

        if (WaveC == 2)
        {
            C3.SetActive(true);
        }*/
    }


}
