using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {
	public float _value;
	// Use this for initialization
	void Start () {
		_value = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (_value < 1) {
			_value += Time.deltaTime / 5;
		} 
		GetComponent<MeshRenderer> ().material.color = new Color(GetComponent<MeshRenderer> ().material.color.r,GetComponent<MeshRenderer> ().material.color.g,GetComponent<MeshRenderer> ().material.color.b,_value);
	}
}
