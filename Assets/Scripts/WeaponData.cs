using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptabeOject/WeaponData")]
public class WeaponData : ScriptableObject
{
    public string Name;

    [Range(0, 100)]
    public int Impact;

    public float FireRate;

    // プレビュー用モデル
    public GameObject PreviewModel;
}
