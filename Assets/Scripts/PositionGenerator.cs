using UnityEngine;

public class PositionGenerator : MonoBehaviour
{
    public Vector3 GetRandomPointInBounds(GameObject geo)
    {
        // Get geometry mesh
        Renderer renderer = geo.GetComponent<Renderer>();

        // Generate limits
        Bounds bounds = renderer.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        float z = Random.Range(bounds.min.z, bounds.max.z);

        // Return generate point
        return new Vector3(x, y, z);
    }
}
