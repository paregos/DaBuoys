using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boaty : MonoBehaviour {
    public float maxspeed = 15.0f;
    public float speed = 6.0F;
    public float rotationSpeed = 10.0f;
    private Vector3 moveDirection = Vector3.zero;
    private bool death = false;

	void Update () {
        if (Vector3.Dot(transform.up, Vector3.up) < 0.5 && !death)
        {
            sink();
            death = true;
        }


        moveDirection = Quaternion.Euler(0, 45, 0) * new Vector3(Input.GetAxis("P1-H"), 0, Input.GetAxis("P1-V"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;
        
        transform.Rotate(transform.up, Input.GetAxis("P1-H") * rotationSpeed * Time.deltaTime);
        transform.Rotate(new Vector3(Input.GetAxis("P1-H"), 0, 0), Input.GetAxis("P1-H") * rotationSpeed * Time.deltaTime);
        GetComponent<Rigidbody>().velocity += transform.right * speed * Input.GetAxis("P1-V") * Time.deltaTime;
        GetComponent<Rigidbody>().velocity = transform.right * 
            Mathf.Clamp(GetComponent<Rigidbody>().velocity.magnitude, 0, maxspeed);
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
        GameObject.FindObjectOfType<HUD>().PoseidonWins();
    }
}
