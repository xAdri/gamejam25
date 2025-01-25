using UnityEngine;
using UnityEngine.UI;

public class CamViewer : MonoBehaviour
{
    public RawImage rawImage;
    public Camera targetCamera;

    void Start()
    {
        RenderTexture renderTexture = new RenderTexture(Screen.width, Screen.height, 16);
        targetCamera.targetTexture = renderTexture;
        rawImage.texture = renderTexture;
    }
}
