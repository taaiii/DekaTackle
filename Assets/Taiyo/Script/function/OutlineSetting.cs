using TMPro;
using UnityEngine;

public class OutlineSetter : MonoBehaviour
{
    public TextMeshProUGUI text;

    void Start()
    {
        // 縁の色を黒にして、太さを設定
        text.fontMaterial.SetColor("_OutlineColor", Color.black);
        text.fontMaterial.SetFloat("_OutlineWidth", 0.4f);
    }
}
