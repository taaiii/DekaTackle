using UnityEngine;
using TMPro; // TextMeshPro を使うために必要

public class FinishText : MonoBehaviour
{
    public GameObject textObject; // 表示させたいTextMeshProオブジェクト
    public float showfinish = 70f; // 表示までの待ち時間（秒）

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
        yield return new WaitForSeconds(showfinish); // 70秒待つ

        textObject.SetActive(true); // 表示
        Debug.Log("TextMeshPro 表示！");

        
    }
}
