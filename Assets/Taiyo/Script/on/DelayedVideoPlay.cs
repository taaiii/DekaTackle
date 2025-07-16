using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class DelayedVideoPlay : MonoBehaviour
{
    public RawImage rawImage;
    public VideoPlayer videoPlayer;
    public RenderTexture renderTexture;
    public float delayTime = 60f;
    public float displayDuration = 2f;

    void Start()
    {
        rawImage.enabled = false;
        videoPlayer.targetTexture = renderTexture;
        Invoke(nameof(PlayVideo), delayTime);
    }

    void PlayVideo()
    {
        rawImage.enabled = true;
        videoPlayer.time = 0;
        videoPlayer.Play();
        Invoke(nameof(HideVideo), displayDuration);
    }

    void HideVideo()
    {
        videoPlayer.Stop();
        rawImage.enabled = false;
    }
}
