using TMPro;
using UnityEngine;

public class OutlineSetter : MonoBehaviour
{
    public TextMeshProUGUI text;

    void Start()
    {
        // ���̐F�����ɂ��āA������ݒ�
        text.fontMaterial.SetColor("_OutlineColor", Color.black);
        text.fontMaterial.SetFloat("_OutlineWidth", 0.4f);
    }
}
