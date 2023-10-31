using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoMaterialToggle : MonoBehaviour
{
    public GameObject[] targetObjects; // Assign your objects in the Unity Inspector
    private VideoPlayer[] videoPlayers;
    private Renderer[] objectRenderers;
    private Material[] originalMaterials;

    void Start()
    {
        // Initialize arrays to store VideoPlayers, Renderers, and original materials for each object
        videoPlayers = new VideoPlayer[targetObjects.Length];
        objectRenderers = new Renderer[targetObjects.Length];
        originalMaterials = new Material[targetObjects.Length];

        // Disable all VideoPlayers and store original materials
        for (int i = 0; i < targetObjects.Length; i++)
        {
            videoPlayers[i] = targetObjects[i].AddComponent<VideoPlayer>();
            videoPlayers[i].enabled = false;

            objectRenderers[i] = targetObjects[i].GetComponent<Renderer>();
            originalMaterials[i] = objectRenderers[i].material;
        }
    }

    void Update()
    {
        // Check for key presses (1-9, 0) and toggle VideoPlayer for the corresponding object
        for (int i = 0; i < targetObjects.Length; i++)
        {
            if (Input.GetKeyDown((i + 1).ToString()) && i < videoPlayers.Length)
            {
                ToggleVideoPlayer(i);
            }
        }
    }

    void ToggleVideoPlayer(int objectIndex)
    {
        if (videoPlayers[objectIndex].enabled)
        {
            // Remove the VideoPlayer component and restore the original material
            Destroy(videoPlayers[objectIndex]);
            objectRenderers[objectIndex].material = originalMaterials[objectIndex];
        }
        else
        {
            // Add the VideoPlayer component, set the video clip, and play it
            videoPlayers[objectIndex] = targetObjects[objectIndex].AddComponent<VideoPlayer>();
            videoPlayers[objectIndex].enabled = true;
            videoPlayers[objectIndex].url = "Assets/YourVideoPath" + objectIndex + ".mp4"; // Update the path for each object
            videoPlayers[objectIndex].targetMaterialRenderer = objectRenderers[objectIndex];
            videoPlayers[objectIndex].targetMaterialProperty = "_MainTex";
            videoPlayers[objectIndex].Play();
        }
    }
}
