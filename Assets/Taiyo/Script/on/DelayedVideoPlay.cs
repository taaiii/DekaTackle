using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;

public class DelayedVideoPlay : MonoBehaviour
{
    public RawImage rawImage;
    public VideoPlayer videoPlayer;
    public RenderTexture renderTexture;
    public TextMeshProUGUI text;
    public float delayTime = 60f;
    public float displayDuration = 2f;

    void Start()
    {
        rawImage.enabled = false;
        text.gameObject.SetActive(false);
        videoPlayer.targetTexture = renderTexture;
        Invoke(nameof(PlayVideo), delayTime);
    }

    void PlayVideo()
    {
        text.gameObject.SetActive(true);
        rawImage.enabled = true;
        videoPlayer.time = 0;
        videoPlayer.Play();
        Invoke(nameof(HideVideo), displayDuration);
    }

    void HideVideo()
    {
        videoPlayer.Stop();
        rawImage.enabled = false;
        text?.gameObject.SetActive(false);
    }
}
