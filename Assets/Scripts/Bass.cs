using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bass : MonoBehaviour {

    public Transform PlopEffect;
    public float bassDropSpin = 4f;
    public float timeToPlop = 3f;
    public float killTime = 9f;
    public float plopTime = 0.8f;
    public float plopForce = 3f;
    private float plopCount = 0f;
    private float timeSteps = 0.1f;
    private Vector3 startPos;

    void Start()
    {
        StartCoroutine(startPlop());
        StartCoroutine(kill());
        startPos = transform.position;
        GetComponent<Rigidbody>().angularVelocity = generateRandomSpin();
    }

    private Vector3 generateRandomSpin()
    {
        return Random.onUnitSphere * bassDropSpin;
    }

    IEnumerator kill()
    {
        yield return new WaitForSeconds(killTime);
        Debug.Log("Bass Ded");
        Destroy(gameObject);
    }

    IEnumerator startPlop()
    {
        Debug.Log("Bass plop");
        yield return new WaitForSeconds(timeToPlop);
        Transform trans = Instantiate(PlopEffect, startPos, Quaternion.identity) as Transform;
        Plop plop = trans.gameObject.GetComponent<Plop>();
        plop.vscale = plopForce;
        plop.initialVScale = plopForce;
        plop.startDissipate(10f);
        
    }

    void OnTriggerStay(Collider other)
    {

        if (other.attachedRigidbody.tag == "Player")
        {
            Destroy(gameObject);
            Debug.Log("CAUGHT");
            GameObject.FindObjectOfType<HUD>().caughtFish();
            
        }
    }
}
