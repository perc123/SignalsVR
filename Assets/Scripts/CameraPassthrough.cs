using UnityEngine;

public class CameraPassthrough : MonoBehaviour
{
    private WebCamTexture webcamTexture;
    private Texture2D lastFrame;

    // Desired frame rate (in frames per second)
    public int targetFPS = 30;
    // Desired lag time (in seconds)
    public float lagTime = 1.0f;
    private float lagTimer = 0.0f;

    // Reference to the second quad GameObject
    public GameObject secondQuad;

    void Start()
    {
        // Access the computer's camera
        webcamTexture = new WebCamTexture();

        // Set the desired frame rate
        webcamTexture.requestedFPS = targetFPS;

        // Start streaming the camera feed
        webcamTexture.Play();

        // Apply the camera feed to the first quad GameObject
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = webcamTexture;

        // Initialize lastFrame texture
        lastFrame = new Texture2D(webcamTexture.width, webcamTexture.height);

        // Ensure the secondQuad variable is set in the Inspector
        if (secondQuad == null)
        {
            Debug.LogError("Second quad GameObject reference is not set. Please assign it in the Inspector.");
        }
    }

    void Update()
    {
        // Update lag timer
        lagTimer += Time.deltaTime;

        // If enough time has passed, update lastFrame with current frame
        if (lagTimer >= lagTime)
        {
            lastFrame.SetPixels32(webcamTexture.GetPixels32());
            lastFrame.Apply();
            lagTimer = 0.0f;
        }
    }

    void LateUpdate()
    {
        // Render the lastFrame texture on the second quad GameObject
        if (lastFrame != null && secondQuad != null)
        {
            Renderer secondRenderer = secondQuad.GetComponent<Renderer>();
            secondRenderer.material.mainTexture = lastFrame;
        }
    }
}