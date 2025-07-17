using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TutorialSceneTransition : MonoBehaviour
{
    public Image fadeImage;         // 黒いImage（Canvasに置く）
    public GameObject toneImage;
    public float fadeDuration = 1f; // フェード時間（秒）
    public float TornDuration = 0.5f; // トーン時間（秒）
    public float waitOnBlack = 1f;  // 黒画面での待機時間

    void Start()
    {
        // シーンが始まったらフェードインする
        StartCoroutine(FadeIn());
    }

    public void FadeAndLoadScene(string sceneName)
    {
        StartCoroutine(FadeOutAndLoadScene(sceneName));
    }

    private IEnumerator FadeOutAndLoadScene(string sceneName)
    {
        // フェードアウト（透明→黒）
        yield return StartCoroutine(Fade(0f, 1f));

        // 黒画面で少し待機
        yield return new WaitForSeconds(waitOnBlack);

        // シーンを読み込み
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // 読み込み完了を待つ
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // フェードイン（黒→透明）
        yield return StartCoroutine(Fade(1f, 0f));
    }

    private IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float timer = 0f;
        Color color = fadeImage.color;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float t = Mathf.Clamp01(timer / fadeDuration);
            color.a = Mathf.Lerp(startAlpha, endAlpha, t);
            fadeImage.color = color;
            yield return null;
        }

        color.a = endAlpha;
        fadeImage.color = color;
    }

    private IEnumerator FadeIn()
    {
        fadeImage.color = new Color(0f, 0f, 0f, 1f); // 黒で始める
        yield return StartCoroutine(Fade(1f, 0f));    // 黒→透明
    }


    public void ToneDown()
    {
        StartCoroutine(Fadetone(0f, 0.9f));
    }

    public void ToneUp()
    {
        StartCoroutine(Fadetone(0.9f, 0f));
    }

    private IEnumerator Fadetone(float startAlpha, float endAlpha)
    {
        float timer = 0f;
        SpriteRenderer spriteRenderer = toneImage.GetComponent<SpriteRenderer>();
        Color color = spriteRenderer.color;

        while (timer < TornDuration)
        {
            timer += Time.deltaTime;
            float t = Mathf.Clamp01(timer / fadeDuration);
            color.a = Mathf.Lerp(startAlpha, endAlpha, t);
            spriteRenderer.color = color;
            yield return null;
        }

        color.a = endAlpha;
        spriteRenderer.color = color;
    }
}

