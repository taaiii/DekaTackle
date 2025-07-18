using UnityEngine;

public class TutorialBGMManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip BGM;
    public AudioClip feverBGM;

    void Start()
    {
        audioSource.clip = BGM;
        audioSource.loop = true;
        audioSource.Play();
    }

    void Update()
    {

    }

    void ChangeBGM(AudioClip newClip)
    {
        audioSource.Stop();
        audioSource.clip = newClip;
        audioSource.Play();
    }
}
