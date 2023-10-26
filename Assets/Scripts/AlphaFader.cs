using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaFader : MonoBehaviour
{
    public Material transparentMaterial;  // Material for fully transparent state
    public Material opaqueMaterial;      // Material for fully opaque state
    public float fadeSpeed = 1.0f;       // Adjust the speed of the fade
    private bool fadingIn = false;
    private bool fadingOut = false;

    void Start()
    {
        // Initialize with the opaque material
        GetComponent<Renderer>().material = opaqueMaterial;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            fadingOut = true;
            fadingIn = false;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            fadingIn = true;
            fadingOut = false;
        }

        if (fadingOut)
        {
            FadeOut();
        }
        else if (fadingIn)
        {
            FadeIn();
        }
    }

    void FadeOut()
    {
        GetComponent<Renderer>().material = transparentMaterial;
        fadingOut = false;
    }

    void FadeIn()
    {
        GetComponent<Renderer>().material = opaqueMaterial;
        fadingIn = false;
    }
}