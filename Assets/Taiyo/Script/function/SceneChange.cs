using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using static LockManager; // ← buttonlock enum をインポート

public class SceneChange : MonoBehaviour
{
    public SEPlayer sePlayer;
    public string nextScene = "Main Scene 2";
    public FadeManager fadeManager;

    private bool isLoading = false;

    private void Update()
    {
        if ((Input.GetKeyDown("d") || Input.GetKeyDown("a")) && !isLoading)
        {
            // LockManager の state をチェック
            if (LockManager.state == buttonlock.OPEN)
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
            yield return fadeManager.FadeIn(2f);
        }
        else
        {
            Debug.LogWarning("FadeManagerが設定されていません");
            yield return new WaitForSeconds(2f);
        }

        LoadNextScene();
    }
}
