using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewVisualize : MonoBehaviour
{
    //Visualize the view of the fish
    [SerializeField] FloatVariable _viewRadius;
    [SerializeField] int _meshResolution; //vertices count on circle edge

    //this game object component
    MeshFilter _meshFilter;

    Mesh _viewMesh;




    private void Start()
    {
        _viewMesh = new Mesh();
        _meshFilter = GetComponent<MeshFilter>();
        _meshFilter.mesh = _viewMesh;

    }

    private void Update()
    {
        DrawViewSpace();
    }

    void DrawViewSpace()
    {
        int triangleCount = _meshResolution;
        int vertexCount = _meshResolution + 1;
        int[] triangles = new int[triangleCount * 3];
        Vector3[] vertices = new Vector3[vertexCount];

        //setup triangles
        for (int i = 0; i < triangleCount; i++)
        {
            triangles[3 * i] = 0;
            triangles[3 * i + 1] = i + 1;
            triangles[3 * i + 2] = i + 2;
        }
        triangles[3 * triangleCount - 1] = 1;


        //setup vertices
        vertices[0] = Vector3.zero;
        for (int i = 1; i < vertexCount; i++)
        {
            float stepSize = 360 / (float)_meshResolution;
            float xPos = Mathf.Cos(stepSize * (i - 1) * Mathf.Deg2Rad);
            float xyPos = Mathf.Sin(stepSize * (i - 1) * Mathf.Deg2Rad);
            Vector3 dir = new Vector3(xPos, xyPos, 0);
            vertices[i] = dir * _viewRadius.Value;
        }


        _viewMesh.Clear();
        _viewMesh.vertices = vertices;
        _viewMesh.triangles = triangles;
        _viewMesh.RecalculateNormals();

    }

}
