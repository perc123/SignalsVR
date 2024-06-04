using UnityEngine;

public class ImageSpawner : MonoBehaviour
{
    public GameObject[] imagePrefabs; // Array of image prefabs
    public Timer timer; // Reference to the Timer script
    public float spawnInterval = 1f; // Interval between image spawns
    public float startTime = 10f; // Time to start spawning images
    public float endTime = 20f; // Time to stop spawning images

    private bool isSpawning = false; // Flag to control spawning

    void Start()
    {
        // Start spawning images after the specified start time
        Invoke("StartSpawning", startTime);
    }

    void Update()
    {
        // Check if it's time to stop spawning images
        if (timer.GetElapsedTime() >= endTime)
        {
            StopSpawning();
        }
    }

    void StartSpawning()
    {
        isSpawning = true;
        InvokeRepeating("SpawnImage", 0f, spawnInterval);
    }

    void StopSpawning()
    {
        isSpawning = false;
        CancelInvoke("SpawnImage");
    }

    void SpawnImage()
    {
        if (isSpawning)
        {
            GameObject selectedImagePrefab = imagePrefabs[Random.Range(0, imagePrefabs.Length)];

            // Instantiate the image at a random position on the screen
            Vector3 randomPosition = new Vector3(Random.Range(0f, Screen.width), Random.Range(0f, Screen.height), Random.Range(6f, 9f));
            Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(randomPosition);
            Instantiate(selectedImagePrefab, spawnPosition, Quaternion.identity);
        }
    }
}