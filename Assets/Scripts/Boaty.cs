﻿using System.Collections;
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
        Rigidbody rb = GetComponent<Rigidbody>();

        moveDirection = Quaternion.Euler(0, 45, 0) * new Vector3(Input.GetAxis("P1-H"), 0, Input.GetAxis("P1-V"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;
        Debug.Log(Input.GetAxis("P1-V"));
        transform.Rotate(transform.up, Input.GetAxis("P1-H") * rotationSpeed * Time.deltaTime);
        transform.Rotate(new Vector3(Input.GetAxis("P1-H"), 0, 0), Input.GetAxis("P1-H") * rotationSpeed * Time.deltaTime);
     
        rb.velocity += Input.GetAxis("P1-V") * transform.right * speed * Time.deltaTime;
        rb.velocity = rb.velocity.normalized * Mathf.Clamp(rb.velocity.magnitude, -maxspeed, maxspeed);
        GetComponent<AudioSource>().volume = Mathf.Clamp01(0.7f + 2f * rb.velocity.magnitude / maxspeed);
    }

    private void sink()
    {
        Debug.Log("RIP McBoaty :(");
        GetComponent<Rigidbody>().mass = 1.87f;
        StartCoroutine(kill());
    }
    public AudioClip sinking;

    IEnumerator kill()
    {
        AudioSource audio =  GetComponent<AudioSource>();
        yield return new WaitForSeconds(3);
        audio.PlayOneShot(sinking, 1f);
        Destroy(gameObject);
        GameObject.FindObjectOfType<HUD>().PoseidonWins();
    }
}
