using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMovement : MonoBehaviour {

	bool hold;

	// Use this for initialization
	void Start () {
		hold = true;
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if (Input.GetMouseButtonDown(0)) {
			Release ();
		}
		if (hold) {
			Vector3 temp = Input.mousePosition;
			temp.z = 10f;
			this.transform.position = Camera.main.ScreenToWorldPoint (temp);
		}*/

	}

	public void Release(){
		hold = false;
	}
}
