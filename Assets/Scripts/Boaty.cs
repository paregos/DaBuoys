using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boaty : MonoBehaviour {

    private bool death = false;
	// Update is called once per frame
	void Update () {
        if (Vector3.Dot(transform.up, Vector3.up) < 0.5 && !death)
        {
            sink();
            death = true;
        }
    }

    private void sink()
    {
        Debug.Log("RIP McBoaty :(");
        GetComponent<Rigidbody>().mass = 1.87f;
        StartCoroutine(kill());
    }

    IEnumerator kill()
    {
        yield return new WaitForSeconds(3);
        Debug.Log("Ded");
        Destroy(gameObject);
    }
}
