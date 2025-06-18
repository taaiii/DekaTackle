using UnityEngine;
using TMPro; // TextMeshPro ���g�����߂ɕK�v

public class UIDelete : MonoBehaviour
{
    public GameObject textObject; // �\����������TextMeshPro�I�u�W�F�N�g
    public float deleteUi = 60f; // �\���܂ł̑҂����ԁi�b�j

    void Start()
    {
        if (textObject != null)
        {
            textObject.SetActive(true); // �ŏ��͔�\���ɂ��Ă���
            StartCoroutine(ShowAndHideText());
        }
        else
        {
            Debug.LogWarning("textObject ���ݒ肳��Ă��܂���I");
        }
    }

    private System.Collections.IEnumerator ShowAndHideText()
    {
        yield return new WaitForSeconds(deleteUi); // 60�b�҂�

        textObject.SetActive(false); // ��\��


    }
}
