using UnityEngine;
using TMPro; // TextMeshPro を使うために必要

public class FeverText : MonoBehaviour
{
    public GameObject textObject; // 表示させたいTextMeshProオブジェクト
    public float showDelay = 60f; // 表示までの待ち時間（秒）
    public float displayDuration = 10f; // 表示しておく時間（秒）

    void Start()
    {
        if (textObject != null)
        {
            textObject.SetActive(false); // 最初は非表示にしておく
            StartCoroutine(ShowAndHideText());
        }
        else
        {
            Debug.LogWarning("textObject が設定されていません！");
        }
    }

    private System.Collections.IEnumerator ShowAndHideText()
    {
        yield return new WaitForSeconds(showDelay); // 60秒待つ

        textObject.SetActive(true); // 表示
        Debug.Log("TextMeshPro 表示！");

        yield return new WaitForSeconds(displayDuration); // 10秒待つ

        textObject.SetActive(false); // 非表示
        Debug.Log("TextMeshPro 非表示！");
    }
}
