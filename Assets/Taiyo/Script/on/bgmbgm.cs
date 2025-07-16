using UnityEngine;

public class bgmbgm : MonoBehaviour
{
    public AudioSource mainAudioSource;     // BGM 再生用
    public AudioSource subAudioSource;      // bgmBGM 再生用

    public AudioClip BGM;       // メインBGM
    public AudioClip bgmBGM;    // 同時再生用BGM
    public AudioClip feverBGM;  // フィーバーBGM

    private float timer = 0f;
    private bool hasStartedBGM = false;
    private bool hasChangedToFever = false;

    void Start()
    {
        // 最初は再生しない（時間で再生）
    }

    void Update()
    {
        timer += Time.deltaTime;

        // 0秒でBGMとbgmBGMを同時再生（または任意のタイミング）
        if (!hasStartedBGM && timer >= 0f)
        {
            mainAudioSource.clip = BGM;
            mainAudioSource.loop = true;
            mainAudioSource.Play();

            subAudioSource.clip = bgmBGM;
            subAudioSource.loop = true;
            subAudioSource.Play();

            hasStartedBGM = true;
        }

        // 63秒でメインBGMを feverBGM に切り替え
        if (!hasChangedToFever && timer >= 63f)
        {
            ChangeMainBGM(feverBGM);
            hasChangedToFever = true;
        }

        // 73秒で両方停止
        if (timer >= 73f)
        {
            mainAudioSource.Stop();
            subAudioSource.Stop();
        }
    }

    void ChangeMainBGM(AudioClip newClip)
    {
        mainAudioSource.Stop();
        mainAudioSource.clip = newClip;
        mainAudioSource.loop = true;
        mainAudioSource.Play();
    }
}
