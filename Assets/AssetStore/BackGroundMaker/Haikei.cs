using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Haikei : MonoBehaviour
{
	public float ScrollSpeed = 0.1f;
	
	private MeshRenderer mr;


	float offset = 0f;

	// Use this for initialization
	void Start () {
		mr = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		offset　= Mathf.Repeat (Time.time * ScrollSpeed, 1f);
		offset = 1f - offset;
		mr.material.SetTextureOffset ("_MainTex", new Vector3 (0f, offset));
	}
}
