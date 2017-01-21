using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockGenerator : MonoBehaviour {

	public GameObject rock;
	public GameObject target;
	public float dropHeight;

	Ray ray;
	RaycastHit hit;
	GameObject obj;
	GameObject targ;

	// Use this for initialization
	void Start () {
		ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		obj = Instantiate (rock, new Vector3 (hit.point.x, hit.point.y + dropHeight, hit.point.z), Quaternion.identity) as GameObject;
		targ = Instantiate (target, new Vector3 (hit.point.x, hit.point.y, hit.point.z), Quaternion.identity) as GameObject;
	}

    public Plane plan;
	// Update is called once per frame
	void Update () {
        /*ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (ray, out hit)) {
			if (Input.GetMouseButtonUp(0)) {
				GameObject targ = Instantiate (rock, new Vector3 (hit.point.x, hit.point.y + dropHeight, hit.point.z), Quaternion.identity) as GameObject;
			}
		}*/
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        int layer_mask = LayerMask.GetMask("NoObjectCollision");
        if (Physics.Raycast(ray, out hit, 100.0f, layer_mask))
        {
            Debug.Log(hit.point);
        }

        /*
        Vector3 temp = Input.mousePosition;
		temp.z = 12f;
		targ.transform.position = Camera.main.ScreenToWorldPoint (temp);
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 dropPosition = targ.transform.position + Vector3.up * dropHeight;
            Instantiate(rock, dropPosition, Quaternion.identity);
        }
        */
        //targ.transform.position = Camera.main.ScreenToWorldPoint (new Vector3 (hit.point.x, 0f, hit.point.z));
    }
}
