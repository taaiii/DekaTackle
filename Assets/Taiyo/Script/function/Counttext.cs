using UnityEngine;
using TMPro;

public class Counttext : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI; // TextMeshProオブジェクトへの参照
     // カウンター

    void Start()
    {
        UpdateText(); // 初期表示
    }

    void Update()
    {
        UpdateText();
    }

    // テキスト更新用のメソッド
    void UpdateText()
    {
        textMeshProUGUI.text = "Point: " + PointCounter.Instance.Point.ToString();
    }
}
