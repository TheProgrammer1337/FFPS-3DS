// Attach this script to a camera that renders the top screen
using UnityEngine;

public class ScreenMirror : MonoBehaviour
{
    public Camera topScreenCamera;
    public RenderTexture renderTexture;

    void Start()
    {
        // Create a RenderTexture with the dimensions of the top screen
        renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
        topScreenCamera.targetTexture = renderTexture;

        // Assign the RenderTexture to a UI RawImage element that covers the bottom screen
        // You can do this in the inspector or via script
    }

    void Update()
    {
        // Update the RenderTexture if necessary
        // This will automatically update the UI element displaying it
    }
}