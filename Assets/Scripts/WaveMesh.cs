 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WaveMesh {
    private static int TRI_POINT_PER_DIV = 6;

    public static GameObject CreateWave(float width, float height, int divs) {
        GameObject obj = new GameObject("WaveMesh");
        MeshFilter filter = obj.AddComponent(typeof(MeshFilter)) as MeshFilter;
        MeshRenderer rend = obj.AddComponent(typeof(MeshRenderer)) as MeshRenderer;

        Mesh mesh = new Mesh();

        int[] tri_list = new int[TRI_POINT_PER_DIV * divs * divs];

        int index = 0;
        for (int i = 0; i < divs; i++)
        {
            for (int j = 0; j < divs; j++)
            {
                int corner = i * (divs + 1) + j;
                tri_list[index++] = corner;
                tri_list[index++] = corner + 4;
                tri_list[index++] = corner + 5;
                tri_list[index++] = corner;
                tri_list[index++] = corner + 5;
                tri_list[index++] = corner + 1;
                string str = "tri_list: ";
                for (var k = 0; k < tri_list.Length; k++)
                {
                    str = str + tri_list[k].ToString() + ",";
                }
                Debug.Log(str);
            }
        }

        Debug.Log(tri_list.ToString());

        mesh.vertices = new Vector3[]
        {
            new Vector3(0,0,0),
            new Vector3(width,0,0),
            new Vector3(width, height,0),
            new Vector3(0,height,0),
            new Vector3(width, height,0),
            new Vector3(0,height,0),
            new Vector3(2*width,0,0),
            new Vector3(2*width,height,0)
            
        };


        Vector2[] uvs = new Vector2[mesh.vertices.Length];

        for (int i = 0; i < uvs.Length; i++)
        {
            uvs[i] = new Vector2(mesh.vertices[i].x, mesh.vertices[i].z);
        }
        mesh.uv = uvs;

        mesh.triangles = tri_list;

        filter.mesh = mesh;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();

        return obj;
    }

}
