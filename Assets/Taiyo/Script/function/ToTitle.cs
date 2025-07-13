using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToTitle : MonoBehaviour
{
    // Start is called before the first frame updat
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R) && Input.GetKey(KeyCode.U))
        {
            LoadTitleScene();
        }
    }

    public void LoadTitleScene()
    {
        if (PointCounter.Instance != null)
        {
            PointCounter.Instance.Point = 0;
        }

        SceneManager.LoadScene("Title");
    }
}
