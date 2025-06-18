using UnityEngine;
using TMPro; // TextMeshPro ���g�����߂ɕK�v

public class FinishText : MonoBehaviour
{
    public GameObject textObject; // �\����������TextMeshPro�I�u�W�F�N�g
    public float showfinish = 70f; // �\���܂ł̑҂����ԁi�b�j

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
        yield return new WaitForSeconds(showfinish); // 70�b�҂�

        textObject.SetActive(true); // �\��
        Debug.Log("TextMeshPro �\���I");

        
    }
}
