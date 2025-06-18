using UnityEngine;
using TMPro; // TextMeshPro ���g�����߂ɕK�v

public class FeverText : MonoBehaviour
{
    public GameObject textObject; // �\����������TextMeshPro�I�u�W�F�N�g
    public float showDelay = 60f; // �\���܂ł̑҂����ԁi�b�j
    public float displayDuration = 10f; // �\�����Ă������ԁi�b�j

    void Start()
    {
        if (textObject != null)
        {
            textObject.SetActive(false); // �ŏ��͔�\���ɂ��Ă���
            StartCoroutine(ShowAndHideText());
        }
        else
        {
            Debug.LogWarning("textObject ���ݒ肳��Ă��܂���I");
        }
    }

    private System.Collections.IEnumerator ShowAndHideText()
    {
        yield return new WaitForSeconds(showDelay); // 60�b�҂�

        textObject.SetActive(true); // �\��
        Debug.Log("TextMeshPro �\���I");

        yield return new WaitForSeconds(displayDuration); // 10�b�҂�

        textObject.SetActive(false); // ��\��
        Debug.Log("TextMeshPro ��\���I");
    }
}
