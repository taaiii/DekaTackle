using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    public Image fadeImage;

    public IEnumerator FadeIn(float duration)
    {
        float time = 0f;
        Color color = fadeImage.color;
        color.a = 0f;
        fadeImage.color = color;

        while (time < duration)
        {
            time += Time.deltaTime;
            color.a = Mathf.Clamp01(time / duration);
            fadeImage.color = color;
            yield return null;
        }

        // Š®‘S‚É•s“§–¾‚É
        color.a = 1f;
        fadeImage.color = color;
    }
}
