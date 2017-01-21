using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boaty : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
        if ( Mathf.Abs(transform.rotation.x) > 90f || Mathf.Abs(transform.rotation.y) > 90f || Mathf.Abs(transform.rotation.z) > 90f)
        {

        }
	}

    private void kill()
    {
        Debug.Log("RIP McBoaty :(");
        Destroy(gameObject);
    }
}
