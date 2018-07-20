using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGeneration : MonoBehaviour
{
    

    public float perlinScale = 10f;
    public float waveSpeed = 0f;
    public float waveHeight = 2f;
    private Mesh mesh;

    void Start(){
        perlinScale = Random.Range(0f, 9f);
    }



    void Update()
    {
        AnimateMesh();
    }

    void AnimateMesh()
    {
        
      
        if (!mesh)
            mesh = GetComponent<MeshFilter>().mesh;

        Vector3[] vertices = mesh.vertices;

        //simple perlin noise plane generation
        for (int i = 0; i < vertices.Length; i++)
        {
            float pX = (vertices[i].x * perlinScale) + (Time.timeSinceLevelLoad * waveSpeed);
            float pZ = (vertices[i].z * perlinScale) + (Time.timeSinceLevelLoad * waveSpeed);

            vertices[i].y = (Mathf.PerlinNoise(pX, pZ) - 0.5f) * waveHeight;
        }

        mesh.vertices = vertices;
    }
}