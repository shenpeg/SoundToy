using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TVAutoPlayer : MonoBehaviour
{
    public VideoClip[] channels; // Assign your video clips in the Inspector
    public float frequencyThreshold = 0.5f; // Adjust this threshold for automatic change
    private VideoPlayer videoPlayer;
    public float[] spectrum = new float[256]; // Adjust the size as needed
    
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.playOnAwake = false;
        PlayChannel(0); // Start with the first video clip
    }
    void Update()
    {
        // Analyze audio frequencies
        float[] spectrum = new float[256];
        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Blackman);
        float sum = 0f;

        // Calculate the sum of frequencies
        for (int i = 0; i < spectrum.Length; i++)
        {
            sum += spectrum[i];
        }

        // Check if the sum of frequencies exceeds the threshold
        if (sum > frequencyThreshold)
        {
            SwitchChannel();
        }
    }

    void SwitchChannel()
    {
        // Stop the current video
        videoPlayer.Stop();

        // Switch to the next channel
        int currentChannel = (int)videoPlayer.GetDirectAudioVolume(0);
        currentChannel = (currentChannel + 1) % channels.Length;
        // Play the new video channel
        PlayChannel(currentChannel);
    }

    void PlayChannel(int channelIndex)
    {
        videoPlayer.clip = channels[channelIndex];
        videoPlayer.Play();
    }

}
