using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public SEPlayer sePlayer;
    public string nextScene = "Main Scene 2";
    public FadeManager fadeManager; // �� �ǉ�

    private bool isLoading = false;

    private void Update()
    {
        if ((Input.GetKeyDown("d") || Input.GetKeyDown("a")) && !isLoading)
        {
            isLoading = true;

            if (nextScene == "test")
            {
                if (sePlayer != null) sePlayer.PlayTackleSE();
                StartCoroutine(ToMain());
            }
            else
            {
                LoadNextScene();
            }
        }
    }

    public void LoadNextScene()
    {
        if (PointCounter.Instance != null)
        {
            PointCounter.Instance.Point = 0;
        }

        SceneManager.LoadScene(nextScene);
    }

    private IEnumerator ToMain()
    {
        if (fadeManager != null)
        {
            yield return fadeManager.FadeIn(2f); // �� �����Ńt�F�[�h�C��
        }
        else
        {
            Debug.LogWarning("FadeManager���ݒ肳��Ă��܂���");
            yield return new WaitForSeconds(2f);
        }

        LoadNextScene();
    }
}
