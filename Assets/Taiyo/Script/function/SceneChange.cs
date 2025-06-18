using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string nextScene = "Main Scene 2"; // �J�ڐ�̃V�[����

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
            //������
            PointCounter.Instance.Point = 0;
        }
        SceneManager.LoadScene(nextScene);
    }
}