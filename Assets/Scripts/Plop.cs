using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plop : MonoBehaviour {

	float xPos;
	float zPos;
	Vector3[] vertices;
	float[] distortions;
	public Mesh mesh;
	public float scale = 1f;
	float startTime = 0f;

    private WaveController controller;

	public static Mesh originalMesh;

    private Vector3[] baseHeight;

	// Use this for initialization
	void Start () {
        Debug.Log("START");
        controller = GameObject.FindObjectOfType<WaveController>();
        controller.bobbers.Add(gameObject);
       
        vertices = mesh.vertices;
        Vector3 pos = transform.position;
		this.xPos = pos.x;
		this.zPos = pos.z;
	}

	public float[] getDistortions() {
		distortions = new float[vertices.Length];
		startTime += Time.deltaTime;

        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 vertex = vertices[i];
            distortions[i] = scale * Mathf.Cos(scale * 0.5f * Mathf.Sqrt(Mathf.Pow(vertex.x - xPos,2f) + Mathf.Pow(vertex.z - zPos, 2f)) - 6f * startTime)
                                 / (scale * 0.5f * (Mathf.Pow(vertex.x - xPos,2f)  + Mathf.Pow(vertex.z - zPos, 2)) + 1f + 2f * startTime);
        }
        return distortions;
	}
}
