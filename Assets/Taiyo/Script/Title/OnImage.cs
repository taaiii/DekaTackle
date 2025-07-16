using UnityEngine;
using UnityEngine.UI;

public class TimedImageDisplay : MonoBehaviour
{
    [SerializeField] private Image targetImage;
    public AudioSource source;

    private float timer = 0f;
    private bool hasPlayed = false;

    public float ontime = 0.3f;  // 表示開始時間
    public float offtime = 0.7f; // 表示終了時間

    void Start()
    {
        source = GetComponent<AudioSource>();
        if (targetImage != null)
        {
            SetVisible(false); // 最初は非表示
        }
        else
        {
            Debug.LogWarning("Image が設定されていません");
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= ontime && timer < offtime)
        {
            SetVisible(true);  // 表示中
            if (!hasPlayed)
            {
                source.Play();   // 一度だけ再生
                hasPlayed = true;
            }
        }
        else
        {
            SetVisible(false);
        }
    }

    private void SetVisible(bool visible)
    {
        if (targetImage != null)
        {
            targetImage.enabled = visible;
        }
    }
}
