using UnityEngine;
using TMPro; // TextMeshPro を使うために必要

public class UIDelete : MonoBehaviour
{
    public GameObject textObject; // 表示させたいTextMeshProオブジェクト
    public float deleteUi = 60f; // 表示までの待ち時間（秒）

    void Start()
    {
        if (textObject != null)
        {
            textObject.SetActive(true); // 最初は非表示にしておく
            StartCoroutine(ShowAndHideText());
        }
        else
        {
            Debug.LogWarning("textObject が設定されていません！");
        }
    }

    private System.Collections.IEnumerator ShowAndHideText()
    {
        yield return new WaitForSeconds(deleteUi); // 60秒待つ

        textObject.SetActive(false); // 非表示


    }
}
