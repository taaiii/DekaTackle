using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class FeverRawImage : MonoBehaviour
{
    [SerializeField] private List<RawImage> rawImages = new List<RawImage>();

    public float showDelay = 60f;
    public float displayDuration = 10f;

    void Awake()
    {
        // 必要に応じて名前で取得（例: シーン内に"RawImage1", "RawImage2"がある想定）
        if (rawImages.Count == 0)
        {
            RawImage img1 = GameObject.Find("RawImage1")?.GetComponent<RawImage>();
            RawImage img2 = GameObject.Find("RawImage2")?.GetComponent<RawImage>();

            if (img1 != null) rawImages.Add(img1);
            if (img2 != null) rawImages.Add(img2);

            if (rawImages.Count == 0)
            {
                Debug.LogWarning("AwakeでRawImage取得失敗");
            }
        }
    }

    void OnEnable()
    {
        if (rawImages.Count == 0)
        {
            Debug.LogWarning("rawImages が設定されていません！");
            return;
        }

        // 初期状態で非表示
        foreach (var img in rawImages)
        {
            img.enabled = false;
        }

        StartCoroutine(ShowAndHideRawImages());
    }

    private IEnumerator ShowAndHideRawImages()
    {
        yield return new WaitForSeconds(showDelay);

        foreach (var img in rawImages)
        {
            img.enabled = true;
        }
        Debug.Log("RawImages 表示！");

        yield return new WaitForSeconds(displayDuration);

        foreach (var img in rawImages)
        {
            img.enabled = false;
        }
        Debug.Log("RawImages 非表示！");
    }
}
