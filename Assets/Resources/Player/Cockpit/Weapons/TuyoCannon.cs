﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuyoCannon : _tmpWeapon{
    AudioSource pew;
    void tuyoStart(){
        base.Start();
        pew = this.gameObject.GetComponent<AudioSource>();
    }
    void tuyoshot(){
        base.shot();
        pew.Play();
    }
}
