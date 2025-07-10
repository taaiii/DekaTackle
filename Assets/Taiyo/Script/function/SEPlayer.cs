// SEPlayer.cs（あなたが提示したスクリプト）
using UnityEngine;

public class SEPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip tackleSE;
    [SerializeField] private AudioClip sippaiSE;
    [SerializeField] private bool useOneShot = true;

    public void PlayTackleSE()
    {
        if (audioSource != null && tackleSE != null)
        {
            if (useOneShot)
                audioSource.PlayOneShot(tackleSE);
            else
            {
                audioSource.clip = tackleSE;
                audioSource.Play();
            }
        }
    }
    public void PlaysippaiSE()
    {
        if (audioSource != null && sippaiSE != null)
        {
            if (useOneShot)
                audioSource.PlayOneShot(sippaiSE);
            else
            {
                audioSource.clip = sippaiSE;
                audioSource.Play();
            }
        }
    }

    public void StopSE()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }

    public void SetUseOneShot(bool value)
    {
        useOneShot = value;
    }
}
