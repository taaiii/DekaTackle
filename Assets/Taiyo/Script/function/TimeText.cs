using TMPro;
using UnityEngine;

public class TimeText : MonoBehaviour
{
    public TMP_Text timerText;   // TextMeshProのテキスト
    public float startTime = 60f; // 開始時間（秒）

    private float remainingTime;
    private int displayedSeconds;

    void Start()
    {
        remainingTime = startTime;
        displayedSeconds = Mathf.CeilToInt(remainingTime);
        UpdateTimerText(displayedSeconds);
    }

    void Update()
    {
        if (remainingTime > 0f)
        {
            remainingTime -= Time.deltaTime;
            int currentSeconds = Mathf.CeilToInt(remainingTime);

            if (currentSeconds != displayedSeconds)
            {
                displayedSeconds = currentSeconds;
                UpdateTimerText(displayedSeconds);
            }
        }
        else
        {
            UpdateTimerText(0);
        }
    }

    void UpdateTimerText(int seconds)
    {
        timerText.text = seconds.ToString(""); // "05" のように表示
    }
}
