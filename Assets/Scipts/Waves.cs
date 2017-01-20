using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Waves : MonoBehaviour {

	public float waveHeight = 10.0f;
	public float speed = 1.0f;
	public float waveLength = 1.0f;
	public float noiseStrength = 4.0f;
	public float noiseWalk = 1.0f;
	public float randomHeight = 0.2f;
	public float randomSpeed = 5.0f;

	private Vector3[] baseHeight;
	private Vector3[] vertices;
	private List<float> perVertexRandoms = new List<float>();
	private Mesh mesh;

	void Awake() {
		mesh = GetComponent<MeshFilter>().mesh;
		if (baseHeight == null) {
			baseHeight = mesh.vertices;
		}

		for(int i=0; i < baseHeight.Length; i++) {
			perVertexRandoms.Add(Random.value * randomHeight);
		}
	}

	void Update () {
		if (vertices == null) {
			vertices = new Vector3[baseHeight.Length];
		}

		for (int i=0;i<vertices.Length;i++) {
			Vector3 vertex = baseHeight[i];
			Random.seed = (int)(vertex.x * vertex.x + vertex.z * vertex.z);
			vertex.y += Mathf.Sin(Time.time * speed + baseHeight[i].x * waveLength + baseHeight[i].y * waveLength) * waveHeight;
			vertex.y += Mathf.Sin(Mathf.Cos(Random.value * 1.0f) * randomHeight * Mathf.Cos (Time.time * randomSpeed * Mathf.Sin(Random.value * 1.0f)));
			vertex.y += Mathf.PerlinNoise(baseHeight[i].x + Mathf.Cos(Time.time * 0.1f) + noiseWalk, baseHeight[i].y + Mathf.Sin(Time.time * 0.1f)) * noiseStrength;
			vertices[i] = vertex;
		}
		mesh.vertices = vertices;
		mesh.RecalculateNormals();
	}
}
