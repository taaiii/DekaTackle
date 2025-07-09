using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip BGM;
    public AudioClip feverBGM;

    private float timer = 0f;

    void Start()
    {
        audioSource.clip = BGM;
        audioSource.loop = true;
        audioSource.Play();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 60f && audioSource.clip != feverBGM)
        {
            ChangeBGM(feverBGM);
        }

        if (timer >= 70f)
        {
            audioSource.Stop();
        }
    }

    void ChangeBGM(AudioClip newClip)
    {
        audioSource.Stop();
        audioSource.clip = newClip;
        audioSource.Play();
    }
}
