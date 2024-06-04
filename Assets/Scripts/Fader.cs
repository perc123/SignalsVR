using UnityEngine;
using System.Collections;

public class Fader : MonoBehaviour
{
    public Material passThroughMaterial;
    public Material skyboxMaterial;
    public Timer timer; // Reference to the Timer script
    public float fadeDuration = 10f; // Duration of fade effects

    private bool isFading = false;

    void Start()
    {
        StartCoroutine(PerformFade());
    }

    IEnumerator PerformFade()
    {
        // Wait until the 10th second
        while (timer.GetElapsedTime() < 10f)
        {
            yield return null;
        }
        
        isFading = true;
        float startTime = Time.time;

        // Fade out pass-through view
        while (Time.time - startTime < fadeDuration)
        {
            float normalizedTime = (Time.time - startTime) / fadeDuration;
            float alpha = 1f - normalizedTime;
            passThroughMaterial.color = new Color(passThroughMaterial.color.r, passThroughMaterial.color.g, passThroughMaterial.color.b, alpha);
            yield return null;
        }

        passThroughMaterial.color = new Color(passThroughMaterial.color.r, passThroughMaterial.color.g, passThroughMaterial.color.b, 0f);

        // Wait until the 20th second
        while (timer.GetElapsedTime() < 20f)
        {
            yield return null;
        }

        startTime = Time.time;

        // Fade in skybox view
        while (Time.time - startTime < fadeDuration)
        {
            float normalizedTime = (Time.time - startTime) / fadeDuration;
            float alpha = normalizedTime;
            skyboxMaterial.color = new Color(skyboxMaterial.color.r, skyboxMaterial.color.g, skyboxMaterial.color.b, alpha);
            yield return null;
        }

        skyboxMaterial.color = new Color(skyboxMaterial.color.r, skyboxMaterial.color.g, skyboxMaterial.color.b, 1f);
    }
}