using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockGenerator : MonoBehaviour {

	public GameObject rock;
	public GameObject target;
	public float y;

	Ray ray;
	RaycastHit hit;
	GameObject obj;
	GameObject targ;

	// Use this for initialization
	void Start () {
		ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		obj = Instantiate (rock, new Vector3 (hit.point.x, hit.point.y + y, hit.point.z), Quaternion.identity) as GameObject;
		targ = Instantiate (target, new Vector3 (hit.point.x, hit.point.y, hit.point.z), Quaternion.identity) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (ray, out hit)) {
			if (Input.GetMouseButtonUp(0)) {
				GameObject targ = Instantiate (rock, new Vector3 (hit.point.x, hit.point.y + y, hit.point.z), Quaternion.identity) as GameObject;
			}
		}
		Vector3 temp = Input.mousePosition;
		temp.z = 12f;
		targ.transform.position = Camera.main.ScreenToWorldPoint (temp);
		//targ.transform.position = Camera.main.ScreenToWorldPoint (new Vector3 (hit.point.x, 0f, hit.point.z));
	}
}
