using UnityEngine;

[ExecuteInEditMode]
internal class ColliderScript : MonoBehaviour
{

    Mesh polymesh;
    PolygonCollider2D poly2d;
    Vector3[] vertices;
    Vector2[] vertices2d;

    void Start()
    {
        polymesh = gameObject.GetComponent<MeshFilter>().sharedMesh;
        vertices = polymesh.vertices;
        vertices2d = new Vector2[vertices.Length];

        for (var i = 0; i < vertices.Length; i++)
        {
            vertices2d[i] = new Vector2(vertices[i].x, vertices[i].y);
        }

        poly2d = gameObject.AddComponent<PolygonCollider2D>();
        poly2d.points = vertices2d;

        DestroyImmediate(this);
    }

}