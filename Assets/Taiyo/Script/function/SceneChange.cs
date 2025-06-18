using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string nextScene = "Main Scene 2"; // ‘JˆÚæ‚ÌƒV[ƒ“–¼

    private void Update()
    {
        if (Input.GetKeyDown("d") || Input.GetKeyDown("a"))
        {
            SceneManager.LoadScene(nextScene);
        }
    }

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