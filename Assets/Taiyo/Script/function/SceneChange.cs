using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string nextScene = "Title" ; // ‘JˆÚæ‚ÌƒV[ƒ“–¼

    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}