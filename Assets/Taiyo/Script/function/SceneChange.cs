using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string nextScene = "Title" ; // �J�ڐ�̃V�[����

    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}