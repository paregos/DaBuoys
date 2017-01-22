using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plop : MonoBehaviour {

	float xPos;
	float zPos;
	Vector3[] vertices;
	float[] distortions;
	public Mesh mesh;

    private WaveController controller;
	public float vscale = 5f;
	public float hscale = 1f;
	public float startTime = 0f;
	public float period = 1f;

    public float initialVScale;

    public bool dissipate = false;
    public float dissipateTime = 10f;
    private float dissipateCounter = 0f;

    private Vector3[] baseHeight;

	// Use this for initialization
	void Start () {

        Debug.Log("START");
        controller = GameObject.FindObjectOfType<WaveController>();
        controller.bobbers.Add(gameObject);
       
		this.vertices = mesh.vertices;
		this.hscale = 1/this.hscale;
		Vector3 pos = transform.position;

		this.xPos = pos.x;
		this.zPos = pos.z;
        initialVScale = vscale;
        StartCoroutine(trigger());
    }

    void Update ()
    {
        if (dissipate)
        {
            if (dissipateCounter > dissipateTime)
            {
                controller.bobbers.Remove(gameObject);
                Destroy(gameObject);
                return;
            }
            vscale = Mathf.Lerp(initialVScale, 0f, dissipateCounter / dissipateTime);
            dissipateCounter += Time.deltaTime;
        }
    }

    public void startDissipate(float time)
    {
        dissipate = true;
        dissipateTime = time;
        dissipateCounter = 0f;
    }

    public void startDissipate()
    {
        dissipate = true;
    }

	public float[] getDistortions() {
		distortions = new float[vertices.Length];
		startTime += Time.deltaTime;

        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 vertex = vertices[i];
            distortions[i] = vscale * Mathf.Cos((1/period) * 0.5f * Mathf.Sqrt(Mathf.Pow(hscale * (vertex.x - xPos),2f) + Mathf.Pow(hscale * (vertex.z - zPos), 2f)) - 6f * startTime)
                                 / (0.5f * (Mathf.Pow(hscale * (vertex.x - xPos),2f)  + Mathf.Pow(hscale * (vertex.z - zPos), 2)) + 1f + 2f * startTime);
        }
        return distortions;
	}

	public float getDistortionForPoint(float x, float z) {
		return vscale * Mathf.Cos(0.5f * Mathf.Sqrt(Mathf.Pow(hscale * (x - xPos),2f) + Mathf.Pow(hscale * (z - zPos), 2f)) - 6f * startTime)
                                 / (0.5f * (Mathf.Pow(hscale * (x - xPos),2f)  + Mathf.Pow(hscale * (z - zPos), 2)) + 1f + 2f * startTime);
	}

    void OnTriggerStay(Collider other)
    {
        
        if (other.attachedRigidbody)
        {
            if (wavePush)
            {
                other.attachedRigidbody.AddForce(Vector3.up * vscale * 1000);
                Vector3 vel = other.attachedRigidbody.velocity;
                vel.y = -Mathf.Abs(vel.y);
                other.attachedRigidbody.velocity = vel;
            }
            else
            {
                other.attachedRigidbody.AddForce(Vector3.down * vscale * 1000);
                Vector3 vel = other.attachedRigidbody.velocity;
                vel.y = -Mathf.Abs(vel.y);
                other.attachedRigidbody.velocity = vel;
            }
        }
       
            
    }

    private bool wavePush = false;
    IEnumerator trigger()
    {
        while (dissipate) {
            yield return new WaitForSeconds(period);
            wavePush = true;
        }

    }
}
