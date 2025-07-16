using TMPro;
using UnityEngine;

public class OutLineWhite : MonoBehaviour
{
    public TextMeshProUGUI text;

    void Start()
    {
        // ‰‚ÌF‚ğ•‚É‚µ‚ÄA‘¾‚³‚ğİ’è
        text.fontMaterial.SetColor("_OutlineColor", Color.white);
        text.fontMaterial.SetFloat("_OutlineWidth", 0.4f);
    }
}
