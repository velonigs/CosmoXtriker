using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackWeaponSelecter : MonoBehaviour {

    [SerializeField]
    private GameObject _weaponSelecter;

    public void BackToEquipment()
    {
        StartCoroutine(BackToWS());
    }

    IEnumerator BackToWS()
    {
        yield return new WaitForSeconds(0.5f);
        _weaponSelecter.SetActive(true);
    }

    //private AudioSource audioSource;

    //private void Start()
    //{
    //    audioSource = GetComponent<AudioSource>();
    //    audioSource.Play();

    //    StartCoroutine(Checking(() =>
    //    {
    //        Debug.Log("END");
    //    }));
    //}

    //public delegate void functionType();
    //private IEnumerator Checking(functionType callback)
    //{
    //    while (true)
    //    {
    //        yield return new WaitForFixedUpdate();
    //        if (!audioSource.isPlaying)
    //        {
    //            callback();
    //            break;
    //        }
    //    }
//}
}