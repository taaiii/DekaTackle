using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class OutLineWhite : MonoBehaviour
{
    public TextMeshProUGUI text;

    void Start()
    {
        // 縁の色を黒にして、太さを設定
        text.fontMaterial.SetColor("_OutlineColor", Color.white);
        text.fontMaterial.SetFloat("_OutlineWidth", 0.4f);
    }
}
