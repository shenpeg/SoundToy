using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TVController : MonoBehaviour
{

    public VideoClip[] channels; // Assign video clips in Inspector
    public KeyCode channelChangeKey = KeyCode.Q; // Default key
    private VideoPlayer videoPlayer;
    private int currentChannel = 0;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        PlayChannel(currentChannel);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(channelChangeKey))
        {
            SwitchChannel();
        }
    }

        void SwitchChannel()
    {
        // Stop current video
        videoPlayer.Stop();

        // Switch to the next channel
        currentChannel = (currentChannel + 1) % channels.Length;

        // Play new video
        PlayChannel(currentChannel);
    }

    void PlayChannel(int channelIndex)
    {
        videoPlayer.clip = channels[channelIndex];
        videoPlayer.Play();
    }

}
