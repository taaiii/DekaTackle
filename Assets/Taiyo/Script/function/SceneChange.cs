using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string nextScene = "Title" ; // �J�ڐ�̃V�[����

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