using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour {

    private static int WAVE_VERT_WIDTH;

    public float scale = 0.1f;
    public float speed = 1.0f;

    public List<GameObject> bobbers;
    private Mesh mesh;

    public float noiseStrength = 1f;
    float noiseWalk = 0.3f;

    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        mesh.MarkDynamic();
    }

    void Update()
    {
        Vector3[] vertices = mesh.vertices;
        float[] totalDistortions = new float[mesh.vertices.Length];
        foreach (GameObject obj in bobbers) {
            float[] distorts = obj.GetComponent<Plop>().getDistortions();
            for (int j = 0; j < totalDistortions.Length; j++) {
                totalDistortions[j] += distorts[j];
            }
        }
        for (int i = 0; i < totalDistortions.Length; i++) {
            Vector3 vertex = vertices[i];
            vertex.y = totalDistortions[i];
            vertex.y += Mathf.PerlinNoise(vertex.x + noiseWalk + Mathf.Sin(0.7f*Time.time), vertex.z + Mathf.Sin(0.7f*Time.time)) * noiseStrength - 0.5f;
            vertices[i] = vertex;  
        }
        mesh.vertices = vertices;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
    }

    void OnApplicationQuit() {
        Vector3[] vertices = mesh.vertices;
        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 vertex = vertices[i];
            vertex.y = 0;
            vertices[i] = vertex;
        }
        mesh.vertices = vertices;
        mesh.RecalculateNormals();
   
    }

    public void fadeOutMusic()
    {
        AudioSource audio = GetComponent<AudioSource>();
    }

    public float GetWaterHeightAtLocation(float x, float z) {
		float totalDistortion = 0f;
		foreach (GameObject obj in bobbers) {
			totalDistortion += obj.GetComponent<Plop>().getDistortionForPoint (x, z);
		}
		return totalDistortion;
    }

	public float GetWaterNormalAtLocation(float x, float z) {
		return 0f;
	}
}
