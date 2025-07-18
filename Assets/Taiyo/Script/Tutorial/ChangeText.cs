using UnityEngine;
using TMPro;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class ChangeText : MonoBehaviour
{
    public TextMeshProUGUI textA, textB, textC,textM;
    public RawImage imageA, imageB;
    public VideoPlayer videoA, videoB;
    public AudioSource audio;
    public Image image;


    private int cnt = 0;
    private int prevCnt = -1; // 前回のcntを保存

    private void Start()
    {
        image.gameObject.SetActive(false);
        audio = GetComponent<AudioSource>();
        textC.gameObject.SetActive(false);
        textM.gameObject.SetActive(false);
        UpdateView(); // 初期表示状態
        prevCnt = cnt;
    }

    void Update()
    {
        // cntを増やす入力処理
        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyUp(KeyCode.J))
        {
            cnt++;
        }

        // cntが変更されたときだけ表示・動画を切り替える
        if (cnt != prevCnt)
        {
            UpdateView();
            prevCnt = cnt;
        }

        // cntが1以上のとき、textCを表示しシーン遷移を受付
        if (cnt >= 1)
        {
            textC.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                LoadMainScene();
            }
        }
    }

    void UpdateView()
    {
        bool isEven = cnt % 2 == 0;

        textA.gameObject.SetActive(isEven);
        textB.gameObject.SetActive(!isEven);

        imageA.gameObject.SetActive(isEven);
        imageB.gameObject.SetActive(!isEven);

        // 動画の切り替えとリセット再生
        videoA.Stop();
        videoB.Stop();

        if (isEven)
        {
            videoA.time = 0;
            videoA.Play();
        }
        else
        {
            videoB.time = 0;
            videoB.Play();
        }
    }

    public void LoadMainScene()
    {
        StartCoroutine(waittackle());
    }

    IEnumerator waittackle()
    {
        videoA.Stop();
        videoB.Stop();
        image.gameObject.SetActive(true);
        textM.gameObject.SetActive(true);
        audio.Play();
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("test");
    }
}
