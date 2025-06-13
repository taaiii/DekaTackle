using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string nextScene = "Title" ; // ‘JˆÚæ‚ÌƒV[ƒ“–¼

    public void Start()
    {
    }

    public void LoadNextScene()
    {
        if (PointCounter.Instance != null)
        {
            //‰Šú‰»
            PointCounter.Instance.Point = 0;
        }
        SceneManager.LoadScene(nextScene);
    }
}