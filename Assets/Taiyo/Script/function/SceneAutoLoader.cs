using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneAutoLoader : MonoBehaviour
{
    public string nextSceneName = "ResultScene"; // ‘JˆÚæ‚ÌƒV[ƒ“–¼
    public float delay = 70f; // •b”

    void Start()
    {
        Invoke("LoadNextScene", delay);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
