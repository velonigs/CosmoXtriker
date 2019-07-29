using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class _reverseMesh : MonoBehaviour
{
    public bool removeExistingColliders = true;

    void Start()
    {
        Collider[] colliders = GetComponents<Collider>();
        for (int i = 0; i < colliders.Length; i++) {
            DestroyImmediate(colliders[i]);
        }
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        mesh.triangles = mesh.triangles.Reverse().ToArray();
        gameObject.AddComponent<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
