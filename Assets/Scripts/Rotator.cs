using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rot;
    void Update()
    {
        transform.Rotate(0, rot * Time.deltaTime, 0);
    }
}
