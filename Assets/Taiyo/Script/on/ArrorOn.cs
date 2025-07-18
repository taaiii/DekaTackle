using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class DualImageScaler : MonoBehaviour
{
    public Image imageA;
    public Image imageB;
    public TextMeshProUGUI text; // ’Ç‰Á

    private void Start()
    {
        imageA.gameObject.SetActive(false);
        imageB.gameObject.SetActive(false);
        text.gameObject.SetActive(false); // ’Ç‰Á
        StartCoroutine(StartDelayedScaling());
    }

    IEnumerator StartDelayedScaling()
    {
        yield return new WaitForSeconds(63f);

        imageA.gameObject.SetActive(true);
        imageB.gameObject.SetActive(true);
        text.gameObject.SetActive(true); // ’Ç‰Á

        StartCoroutine(ScaleLoop(imageA.rectTransform, imageB.rectTransform, 10f));

        yield return new WaitForSeconds(10f);

        imageA.gameObject.SetActive(false);
        imageB.gameObject.SetActive(false);
        text.gameObject.SetActive(false); // ’Ç‰Á
    }

    IEnumerator ScaleLoop(RectTransform rectA, RectTransform rectB, float totalDuration)
    {
        float elapsed = 0f;

        Vector3 scale1 = new Vector3(0.8f, 0.8f, 1f);
        Vector3 scale2 = new Vector3(0.7f, 0.7f, 1f);
        float duration = 0.5f;

        while (elapsed < totalDuration)
        {
            yield return StartCoroutine(ScaleBoth(rectA, rectB, scale1, duration));
            elapsed += duration;
            if (elapsed >= totalDuration) break;

            yield return StartCoroutine(ScaleBoth(rectA, rectB, scale2, duration));
            elapsed += duration;
        }
    }

    IEnumerator ScaleBoth(RectTransform rectA, RectTransform rectB, Vector3 targetScale, float time)
    {
        Vector3 startScaleA = rectA.localScale;
        Vector3 startScaleB = rectB.localScale;
        float elapsed = 0f;

        while (elapsed < time)
        {
            float t = elapsed / time;
            rectA.localScale = Vector3.Lerp(startScaleA, targetScale, t);
            rectB.localScale = Vector3.Lerp(startScaleB, targetScale, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        rectA.localScale = targetScale;
        rectB.localScale = targetScale;
    }
}
