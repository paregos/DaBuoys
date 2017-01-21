using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoseidonController : MonoBehaviour {

    public Vector3 spawnPosition = new Vector3(0, 10, 0);
    public float lightRange = 10f;
    public float dropDistanceBelowPoseidon = 3f;

    private float offLightRange = 0f;
    private float onLightRange = 40f;
    private float startAngle = 179f;
    private float endAngle = 10f;

    // Select which prefab should be dropped from ingame GUI
    public Transform prefab;

	// Use this for initialization
	void Start () {
        transform.position = spawnPosition;
        GetComponentInChildren<Light>().range = spawnPosition.y + lightRange;
    }

    public float speed = 6.0F;
    private Vector3 moveDirection = Vector3.zero;

    public float chargeTime = 5.0f;
    private float chargeCount = 0f;
    private bool charged = false;
    void Update()
    {
        chargeCount += Time.deltaTime;
        CharacterController controller = GetComponent<CharacterController>();
 
        moveDirection = Quaternion.Euler(0, 45, 0) * new Vector3(Input.GetAxis("P2-H"), 0, Input.GetAxis("P2-V"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;
        controller.Move(moveDirection * Time.deltaTime);

        chargeShot(chargeCount);
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Hit");
            if (charged)
            {
                drop(prefab);
                chargeCount = 0f;
                charged = false;
            }
        }   
    }

    private void drop(Transform prefabToDrop)
    {
        Instantiate(prefabToDrop, transform.position + Vector3.down * dropDistanceBelowPoseidon, Quaternion.identity);
    }


    /**
        Called everyframe to focus the shot beam.
    */
    private void chargeShot(float chargeCount)
    {
        float clamped = Mathf.Clamp01(chargeCount / chargeTime);
        float spotLightAngle = Mathf.Lerp(startAngle, endAngle, clamped);
        Light spotLight = GetComponentInChildren<Light>();
        spotLight.spotAngle = spotLightAngle;
        if (clamped == 1 && !charged)
        {
            shotCharged();
        }
    }
    /**
        Called to initiate the shot charged animation.
    */
    private void shotCharged()
    {
        charged = true;
        StartCoroutine(flash());
    }

    
    IEnumerator flash()
    {
        Light spotLight = GetComponentInChildren<Light>();
        float initialRange = spotLight.range;
        spotLight.range = 10f;
        yield return new WaitForSeconds(0.1f);
        spotLight.range = 50f;
        yield return new WaitForSeconds(0.1f);
        spotLight.range = 10f;
        yield return new WaitForSeconds(0.1f);
        spotLight.range = 50f;
        yield return new WaitForSeconds(0.1f);
        spotLight.range = 10f;
        yield return new WaitForSeconds(0.1f);
        spotLight.range = 50f;
        yield return new WaitForSeconds(0.1f);
        spotLight.range = initialRange;
    }
}
