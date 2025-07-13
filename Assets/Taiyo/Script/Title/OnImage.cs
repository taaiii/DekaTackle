using UnityEngine;
using UnityEngine.UI;

public class TimedImageDisplay : MonoBehaviour
{
    [SerializeField] private Image targetImage;

    private float timer = 0f;

    public float ontime = 0f;
    public float offtime = 0f;
    void Start()
    {
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
            SetVisible(true);  // 0.3〜0.7秒の間は表示
        }
        else
        {
            SetVisible(false); // それ以外は非表示
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
