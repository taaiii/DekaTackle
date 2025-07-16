using UnityEngine;

public class bgmbgm : MonoBehaviour
{
    public AudioSource mainAudioSource;     // BGM �Đ��p
    public AudioSource subAudioSource;      // bgmBGM �Đ��p

    public AudioClip BGM;       // ���C��BGM
    public AudioClip bgmBGM;    // �����Đ��pBGM
    public AudioClip feverBGM;  // �t�B�[�o�[BGM

    private float timer = 0f;
    private bool hasStartedBGM = false;
    private bool hasChangedToFever = false;

    void Start()
    {
        // �ŏ��͍Đ����Ȃ��i���ԂōĐ��j
    }

    void Update()
    {
        timer += Time.deltaTime;

        // 0�b��BGM��bgmBGM�𓯎��Đ��i�܂��͔C�ӂ̃^�C�~���O�j
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

        // 63�b�Ń��C��BGM�� feverBGM �ɐ؂�ւ�
        if (!hasChangedToFever && timer >= 63f)
        {
            ChangeMainBGM(feverBGM);
            hasChangedToFever = true;
        }

        // 73�b�ŗ�����~
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
