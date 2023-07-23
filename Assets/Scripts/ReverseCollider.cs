using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ReverseCollider : MonoBehaviour {

    public bool removeExistingColliders = true;

    private void Start()
    {
        CircleCollider2D collider = GetComponent<CircleCollider2D>();
        //collider = collider.triangles.Reverse().ToArray();
    }

    public void CreateInvertedMeshCollider()
    {
        if (removeExistingColliders)
            RemoveExistingColliders();

        InvertMesh();

        gameObject.AddComponent<MeshCollider>();
    }

    private void RemoveExistingColliders()
    {
        Collider[] colliders = GetComponents<Collider>();
        for (int i = 0; i < colliders.Length; i++)
            DestroyImmediate(colliders[i]);
    }

    private void InvertMesh()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        mesh.triangles = mesh.triangles.Reverse().ToArray();
    }
}