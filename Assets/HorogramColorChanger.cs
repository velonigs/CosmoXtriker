using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorogramColorChanger : HealthManager {

    void Start () {

    }

    void Update () {
        if (health > startingHealth / 2) {
            GetComponent<Renderer>().material.color = new Color32(0, 255, 0, 100);
        } else if (health > startingHealth / 5) {
            GetComponent<Renderer>().material.color = new Color32(255, 255, 0, 100);
        } else if (health < startingHealth / 5) {
            GetComponent<Renderer>().material.color = new Color32(255, 0, 0, 100);
        }
    }
}