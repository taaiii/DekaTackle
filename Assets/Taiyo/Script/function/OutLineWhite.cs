using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class OutLineWhite : MonoBehaviour
{
    public TextMeshProUGUI text;

    void Start()
    {
        // ���̐F�����ɂ��āA������ݒ�
        text.fontMaterial.SetColor("_OutlineColor", Color.white);
        text.fontMaterial.SetFloat("_OutlineWidth", 0.4f);
    }

    void Update()
    {
        text.enabled = DrawUiObserver.Instance.GetIsView();
    }
}
