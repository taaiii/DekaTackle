using UnityEngine;
using System.Collections;

public class ScoreRank : MonoBehaviour
{
    public GameObject RainbowScore1;
    public GameObject RainbowScore2;
    public GameObject GoldScore1;
    public GameObject GoldScore2;
    public GameObject SilverScore1;
    public GameObject SilverScore2;
    public GameObject BronzeScore1;
    public GameObject BronzeScore2;

    public int GoldPoint;
    public int SilverPoint;
    public int BronzePoint;

    private int lastRank = -1;

    void Update()
    {
        int rank = EvaluateRank(PointCounter.Instance.Point);
        if (rank != lastRank)
        {
            lastRank = rank;
            ShowRank(rank);
        }
    }

    int EvaluateRank(int score)
    {
        if (score > GoldPoint) return 1;
        if (score <= GoldPoint && score > SilverPoint) return 2;
        if (score <= SilverPoint && score > BronzePoint) return 3;
        if (score <= BronzePoint && score > 0) return 4;
        return 0;
    }

    void ShowRank(int rank)
    {
        // 一旦すべて非表示
        RainbowScore1.SetActive(false); RainbowScore2.SetActive(false);
        GoldScore1.SetActive(false); GoldScore2.SetActive(false);
        SilverScore1.SetActive(false); SilverScore2.SetActive(false);
        BronzeScore1.SetActive(false); BronzeScore2.SetActive(false);

        // 対応する画像を段階的に表示
        StartCoroutine(ShowRankWithDelay(rank));
    }

    IEnumerator ShowRankWithDelay(int rank)
    {
        yield return new WaitForSeconds(0.7f); // 最初の表示まで待つ

        switch (rank)
        {
            case 1:
                RainbowScore1.SetActive(true);
                break;
            case 2:
                GoldScore1.SetActive(true);
                break;
            case 3:
                SilverScore1.SetActive(true);
                break;
            case 4:
                BronzeScore1.SetActive(true);
                break;
        }

        yield return new WaitForSeconds(0.7f); // 次の表示まで待つ

        switch (rank)
        {
            case 1:
                RainbowScore2.SetActive(true);
                break;
            case 2:
                GoldScore2.SetActive(true);
                break;
            case 3:
                SilverScore2.SetActive(true);
                break;
            case 4:
                BronzeScore2.SetActive(true);
                break;
        }
    }

}
