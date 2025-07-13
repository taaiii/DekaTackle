using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ChangeText : MonoBehaviour
{
    public TextMeshProUGUI textA;
    public TextMeshProUGUI textB;
    public TextMeshProUGUI textC;

    public int cnt = 0;

    private void Start()
    {
        textC.gameObject.SetActive(false);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) || Input.GetKeyUp(KeyCode.J))
        {
            cnt++;
        }
        if (cnt % 2 == 0)
        {
            textA.gameObject.SetActive(true);
            textB.gameObject.SetActive(false);
        }
        else if (cnt % 2 == 1)
        {
            textA.gameObject.SetActive(false);
            textB.gameObject.SetActive(true);
        }
        if(cnt >= 1)
        {
            textC.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                LoadMainScene();
            }
        }
    }
    public void LoadMainScene()
    {
        SceneManager.LoadScene("test");
    }
}
