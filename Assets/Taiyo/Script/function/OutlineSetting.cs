using TMPro;
using UnityEngine;

public class OutlineSetter : MonoBehaviour
{
    public TextMeshProUGUI text;

    void Start()
    {
        // ‰‚ÌF‚ğ•‚É‚µ‚ÄA‘¾‚³‚ğİ’è
        text.fontMaterial.SetColor("_OutlineColor", Color.black);
        text.fontMaterial.SetFloat("_OutlineWidth", 0.4f);
    }
}
