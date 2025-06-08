using UnityEngine;

public class SEPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip tackleSE; // çƒê∂ÇµÇΩÇ¢SE

    public void PlayTackleSE()
    {
        if (audioSource != null && tackleSE != null)
        {
            audioSource.PlayOneShot(tackleSE);
        }
        else
        {
            Debug.LogWarning("SE Ç‹ÇΩÇÕ AudioSource Ç™ê›íËÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅI");
        }
    }
}
