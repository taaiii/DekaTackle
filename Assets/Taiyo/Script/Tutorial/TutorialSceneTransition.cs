//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
//using System.Collections;

//public class TutorialSceneTransition : MonoBehaviour
//{
//    public Image fadeImage;
//    public float fadeDuration = 1.0f;

//    public void FadeAndChangeScene(string sceneName)
//    {
//        StartCoroutine(FadeOutAndLoadScene(sceneName));
//    }

//    // �t�F�[�h�C������
//    private IEnumerator FadeOutAndLoadScene(string sceneName)
//    {
//       //���l���Z�p
//        float timer = 0f;
//        Color color = fadeImage.color;

//        while (timer < fadeDuration)
//        {
//            timer += Time.deltaTime;
//            color.a = Mathf.Lerp(0, 1, timer / fadeDuration);   //timer��1�𒴂��Ȃ��悤�Ɋ���Z�ł���
//            color.a = Mathf.Clamp01(color.a);   //1�𒴂���ƂP�ɒ���
//            fadeImage.color = color;
//            yield return null;
//        }

//        //1�b�ҋ@�i���S�ɍ�����ԁj
//        yield return new WaitForSeconds(1f);

//        // �V�[���؂�ւ�
//        SceneManager.LoadScene(sceneName);
//    }
//}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TutorialSceneTransition : MonoBehaviour
{
    public Image fadeImage;         // ����Image�iCanvas�ɒu���j
    public float fadeDuration = 1f; // �t�F�[�h���ԁi�b�j
    public float waitOnBlack = 1f;  // ����ʂł̑ҋ@����

    void Start()
    {
        // �V�[�����n�܂�����t�F�[�h�C������
        StartCoroutine(FadeIn());
    }

    public void FadeAndLoadScene(string sceneName)
    {
        StartCoroutine(FadeOutAndLoadScene(sceneName));
    }

    private IEnumerator FadeOutAndLoadScene(string sceneName)
    {
        // �t�F�[�h�A�E�g�i���������j
        yield return StartCoroutine(Fade(0f, 1f));

        // ����ʂŏ����ҋ@
        yield return new WaitForSeconds(waitOnBlack);

        // �V�[����񓯊��œǂݍ���
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // �ǂݍ��݊�����҂�
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // �t�F�[�h�C���i���������j
        yield return StartCoroutine(Fade(1f, 0f));
    }

    private IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float timer = 0f;
        Color color = fadeImage.color;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float t = Mathf.Clamp01(timer / fadeDuration);
            color.a = Mathf.Lerp(startAlpha, endAlpha, t);
            fadeImage.color = color;
            yield return null;
        }

        color.a = endAlpha;
        fadeImage.color = color;
    }

    private IEnumerator FadeIn()
    {
        fadeImage.color = new Color(0f, 0f, 0f, 1f); // ���Ŏn�߂�
        yield return StartCoroutine(Fade(1f, 0f));    // ��������
    }
}

