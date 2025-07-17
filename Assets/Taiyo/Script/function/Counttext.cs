using TMPro;
using UnityEngine;

public class ScoreDisplayText : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI;

    private int lastScore = -1;

    void Update()
    {
        int currentScore = PointCounter.Instance.Point;

        // スコアが変わったときだけ更新
        if (currentScore != lastScore)
        {
            lastScore = currentScore;
            textMeshProUGUI.text = currentScore.ToString();
        }

        textMeshProUGUI.enabled = DrawUiObserver.Instance.GetIsView();
    }
}
