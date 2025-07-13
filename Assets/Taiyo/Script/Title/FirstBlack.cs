using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FirstBlackt : MonoBehaviour
{
    [SerializeField] private Image targetImage;

    void Start()
    {
        // 初期状態：完全な黒、不透明（アルファ255）
        if (targetImage != null)
        {
            targetImage.color = new Color(0f, 0f, 0f, 1f); // RGB=0, A=1
            StartCoroutine(FadeSequence());
        }
        else
        {
            Debug.LogWarning("Image が設定されていません");
        }
    }

    private IEnumerator FadeSequence()
    {
        yield return new WaitForSeconds(2f); // 2秒待つ

        // 黒→白（0.5秒）
        float t = 0f;
        while (t < 0.5f)
        {
            t += Time.deltaTime;
            float progress = t / 0.5f;
            Color color = Color.Lerp(Color.black, Color.white, progress); // 透明度はそのまま
            color.a = 1f;
            targetImage.color = color;
            yield return null;
        }

        // 白→透明（0.5秒）
        t = 0f;
        while (t < 0.5f)
        {
            t += Time.deltaTime;
            float progress = t / 0.5f;
            Color color = Color.white;
            color.a = Mathf.Lerp(1f, 0f, progress);
            targetImage.color = color;
            yield return null;
        }

        // 最終状態：透明
        targetImage.color = new Color(1f, 1f, 1f, 0f);
    }
}
