using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitTitle : MonoBehaviour
{
    public string nextScene = "Main Scene2"; // 遷移先のシーン名

    private void Update()
    {
        if (Input.GetKeyDown("d") || Input.GetKeyDown("a"))
        {
            SceneManager.LoadScene(nextScene);
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}