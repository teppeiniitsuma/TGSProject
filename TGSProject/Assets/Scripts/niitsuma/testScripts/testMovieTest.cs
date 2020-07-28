using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage), typeof(VideoPlayer), typeof(AudioSource))]
public class testMovieTest : MonoBehaviour
{
    RawImage image;
    VideoPlayer player;
    void Awake()
    {
        image = GetComponent<RawImage>();
        player = GetComponent<VideoPlayer>();
        var source = GetComponent<AudioSource>();
        player.EnableAudioTrack(0, true);
        player.SetTargetAudioSource(0, source);
    }
    void Update()
    {
        if (player.isPrepared)
        {
            image.texture = player.texture;
        }
    }
}
