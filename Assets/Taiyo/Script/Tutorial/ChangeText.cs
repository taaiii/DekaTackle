using UnityEngine;
using TMPro;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class ChangeText : MonoBehaviour
{
    public TextMeshProUGUI textA, textB, textC;
    public RawImage imageA, imageB;
    public VideoPlayer videoA, videoB;
    public AudioSource audio;

    private int cnt = 0;
    private int prevCnt = -1; // �O���cnt��ۑ�

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        textC.gameObject.SetActive(false);
        UpdateView(); // �����\�����
        prevCnt = cnt;
    }

    void Update()
    {
        // cnt�𑝂₷���͏���
        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyUp(KeyCode.J))
        {
            cnt++;
        }

        // cnt���ύX���ꂽ�Ƃ������\���E�����؂�ւ���
        if (cnt != prevCnt)
        {
            UpdateView();
            prevCnt = cnt;
        }

        // cnt��1�ȏ�̂Ƃ��AtextC��\�����V�[���J�ڂ���t
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

        // ����̐؂�ւ��ƃ��Z�b�g�Đ�
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
        audio.Play();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("test");
    }
}
