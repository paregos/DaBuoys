using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform follow;
    Vector3 offset;
    void Start ()
    {
        offset = follow.position - transform.position;
    }
	// Update is called once per frame
	void Update () {
        transform.position = follow.position + offset;
	}
}
