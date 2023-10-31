using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainController : MonoBehaviour
{
    public GameObject rainEffectPrefab;  // Reference to your "RainEffect" prefab
    public float fadeDuration = 2.0f;    // Duration in seconds for the fading effect
    public bool isRaining = false;       // Flag to control rain state
    public Vector3 rainSpawnPosition = new Vector3(0.0f, 5.0f, 0.0f);  // Spawn position for the rain

    private ParticleSystem rainParticleSystem;
    private float targetEmissionRate = 0.0f;

    void Start()
    {
        // Instantiate the "RainEffect" prefab with the specified spawn position
        GameObject rainEffectObject = Instantiate(rainEffectPrefab, rainSpawnPosition, Quaternion.identity, transform);

        // Get the ParticleSystem component of "Rain"
        rainParticleSystem = rainEffectObject.transform.Find("Rain").GetComponent<ParticleSystem>();

        // Ensure the rain doesn't play on awake
        rainParticleSystem.Stop();

        // Set the initial state of the rain
        SetRainActive(isRaining);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            // Toggle the rain state and start/stop the fading
            isRaining = !isRaining;
            targetEmissionRate = isRaining ? 10.0f : 0.0f;  // Adjust emission rate as needed
            StartCoroutine(FadeRain());
        }
    }

    IEnumerator FadeRain()
    {
        float elapsedTime = 0.0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float currentEmissionRate = Mathf.Lerp(isRaining ? 0.0f : 10.0f, targetEmissionRate, elapsedTime / fadeDuration);
            SetRainActive(currentEmissionRate > 0.0f);
            yield return null;
        }
    }

    void SetRainActive(bool active)
    {
        if (active)
        {
            rainParticleSystem.Play();
        }
        else
        {
            rainParticleSystem.Stop();
        }
    }
}
