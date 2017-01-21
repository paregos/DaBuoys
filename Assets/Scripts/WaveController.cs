using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour {

    private static int WAVE_VERT_WIDTH;

    public float scale = 0.1f;
    public float speed = 1.0f;
    public float noiseStrength = 1f;
    float noiseWalk = 1f;

    private Vector3[] baseHeight;
    private Mesh mesh;

    void Update()
    {
        mesh = GetComponent<MeshFilter>().mesh;

        if (baseHeight == null)
            baseHeight = mesh.vertices;

        Vector3[] vertices = new Vector3[baseHeight.Length];
        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 vertex = baseHeight[i];
            // vertex.y += Mathf.Sin(Time.time * speed + baseHeight[i].x + baseHeight[i].y + baseHeight[i].z) * scale;
            vertex.y +=  Mathf.Cos(scale * 0.5f * Mathf.Sqrt(baseHeight[i].x * baseHeight[i].x + baseHeight[i].z * baseHeight[i].z) - 6 * Time.time) 
                                 / (scale * 0.5f * (baseHeight[i].x * baseHeight[i].x + baseHeight[i].z * baseHeight[i].z) + 1 + 2 * Time.time);
            // vertex.y += Mathf.PerlinNoise(baseHeight[i].x + noiseWalk, baseHeight[i].y + Mathf.Sin(Time.time * 0.1f)) * noiseStrength;
            vertices[i] = vertex;
        }
        mesh.vertices = vertices;
        mesh.RecalculateNormals();
    }

    public Vector3[,] getVerticeMap()
    {
        Vector3[,] v_map = new Vector3[WAVE_VERT_WIDTH,WAVE_VERT_WIDTH];
        int j = 0;
        int k = 0;
        for (int i = 0; i < mesh.vertices.Length; i++)
        {
            if (j < WAVE_VERT_WIDTH)
            {
                v_map[j, k] = mesh.vertices[i];
                j++;
            }
            else
            {
                j = 0;
                k++;
            }
        }
        return v_map;
    }

    public void setVertices(Vector3[,] vert_map)
    {
        Vector3[] vert_list = new Vector3[WAVE_VERT_WIDTH * WAVE_VERT_WIDTH];
        int i = 0;
        for (int j = 0; j < WAVE_VERT_WIDTH; j++)
        {
            for (int k = 0; k < WAVE_VERT_WIDTH; k++)
            {
                vert_list[i] = vert_map[j, k];
            }
        }
        mesh.vertices = vert_list;
    }

}
