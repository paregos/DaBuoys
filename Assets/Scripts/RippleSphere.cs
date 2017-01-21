using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RippleSphere : MonoBehaviour {

    public Transform waveblock;
    private SphereCollider collider;
    public float speed = 3f;
	// Use this for initialization
	void Start () {
        collider = GetComponent<SphereCollider>();
	}
	
	// Update is called once per frame
	void Update () {
        collider.radius += speed * Time.deltaTime;
	}

    void OnTriggerEnter(Collider other) {
        Debug.Log("ENTERED");
        if (other.tag == "Rock")
        {
            Instantiate(waveblock, other.transform.position, Quaternion.identity);
        }
        
    }

}
