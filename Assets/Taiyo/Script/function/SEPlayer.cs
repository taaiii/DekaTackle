using UnityEngine;

public class SEPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip tackleSE; // �Đ�������SE

    public void PlayTackleSE()
    {
        if (audioSource != null && tackleSE != null)
        {
            audioSource.PlayOneShot(tackleSE);
        }
        else
        {
            Debug.LogWarning("SE �܂��� AudioSource ���ݒ肳��Ă��܂���I");
        }
    }
}
