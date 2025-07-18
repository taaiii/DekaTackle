using UnityEngine;

public class StartBGM : MonoBehaviour
{
    [SerializeField] private AudioSource bgmSource;

    void Start()
    {
        if (bgmSource != null)
        {
            StartCoroutine(PlayBGMWithDelay());
        }
        else
        {
            Debug.LogWarning("AudioSource（bgmSource）が設定されていません");
        }
    }

    private System.Collections.IEnumerator PlayBGMWithDelay()
    {
        yield return new WaitForSeconds(2f);
        bgmSource.Play();
    }
}
