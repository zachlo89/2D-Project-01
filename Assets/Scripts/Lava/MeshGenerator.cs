using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// attribute asure always a mesh filter on same obj as this script so as not to add a mesh to nothing
[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    Mesh _mesh;

    Vector3[] _verticies;
    int[] _triangles;

    public int xSize = 20;
    public int zSize = 20;



    void Start()
    {
        _mesh = new Mesh();

        GetComponent<MeshFilter>().mesh = _mesh;

        CreateShape();
    }

    private void Update()
    {
        UpdateMesh();
    }

    void CreateShape()
    {
        /* QUAD
        // def verticies and triangles; points to create triangle
        _verticies = new Vector3[]
        {
            // pt starts at origin
            new Vector3 (0,0,0),
            new Vector3 (0,0,1),
            new Vector3 (1,0,0),
            new Vector3 (1, 0, 1) // make quad
        };

        _triangles = new int[]
        { 
            0, 1, 2,
            1, 3, 2// make quad
        };
        */

        // GRID
        _verticies = new Vector3[(xSize + 1) * (zSize + 1)]; // len of arr

        // nn index to access verticies and change it
        // int i = 0;
        // loop over ea verticies and assign a pos on grid
        for (int i = 0, z = 0; z <= zSize; z++) // loop over verticies squares on z
        {
            for (int x = 0; x <= xSize; x++) // loop over verticies squares on x
            {
                float _y = Mathf.PerlinNoise(x * 0.3f, z * 0.3f) * 2f;
                _verticies[i] = new Vector3(x, _y, z); // creates grid w/ all verticies
                i++;
            }
        }


        _triangles = new int[xSize * zSize * 6]; // 3 points // 6 points
        int _vert = 0; // trks vertex curr looking at
        int _tri = 0; // trks triangles

        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {
                _triangles[_tri + 0] = _vert + 0;
                _triangles[_tri + 1] = _vert + xSize + 1;
                _triangles[_tri + 2] = _vert + 1;
                // add three more vertices
                _triangles[_tri + 3] = _vert + 1;
                _triangles[_tri + 4] = _vert + xSize + 1;
                _triangles[_tri + 5] = _vert + xSize + 2;

                _vert++;
                _tri += 6;
            }

            // increment vert by 1 ea time looping over a row
            _vert++;
        }
    }

    void UpdateMesh()
    {
        // clear any lingering mesh data
        _mesh.Clear();

        // input vertex and triangle array
        _mesh.vertices = _verticies;
        _mesh.triangles = _triangles;

        // for lighting
        _mesh.RecalculateNormals();
    }

    //private void OnDrawGizmos()
    //{
    //    if (_verticies == null)
    //        return;

    //    for (int i = 0; i < _verticies.Length; i++)
    //    {
    //        Gizmos.DrawSphere(_verticies[i], 0.1f);
    //    }
    //}
}
