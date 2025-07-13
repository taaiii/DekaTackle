using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FirstBlackt : MonoBehaviour
{
    [SerializeField] private Image targetImage;

    void Start()
    {
        // ������ԁF���S�ȍ��A�s�����i�A���t�@255�j
        if (targetImage != null)
        {
            targetImage.color = new Color(0f, 0f, 0f, 1f); // RGB=0, A=1
            StartCoroutine(FadeSequence());
        }
        else
        {
            Debug.LogWarning("Image ���ݒ肳��Ă��܂���");
        }
    }

    private IEnumerator FadeSequence()
    {
        yield return new WaitForSeconds(2f); // 2�b�҂�

        // �������i0.5�b�j
        float t = 0f;
        while (t < 0.5f)
        {
            t += Time.deltaTime;
            float progress = t / 0.5f;
            Color color = Color.Lerp(Color.black, Color.white, progress); // �����x�͂��̂܂�
            color.a = 1f;
            targetImage.color = color;
            yield return null;
        }

        // ���������i0.5�b�j
        t = 0f;
        while (t < 0.5f)
        {
            t += Time.deltaTime;
            float progress = t / 0.5f;
            Color color = Color.white;
            color.a = Mathf.Lerp(1f, 0f, progress);
            targetImage.color = color;
            yield return null;
        }

        // �ŏI��ԁF����
        targetImage.color = new Color(1f, 1f, 1f, 0f);
    }
}
