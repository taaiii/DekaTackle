using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;

public class Counttext : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI; // TextMeshProオブジェクトへの参照
                                            // カウンター
    public GameObject RainbowScore1;
    public GameObject GoldScore1;
    public GameObject SilverScore1;
    public GameObject BronzeScore1;
    public GameObject RainbowScore2;
    public GameObject GoldScore2;
    public GameObject SilverScore2;
    public GameObject BronzeScore2;
    public int RainbowPoint;
    public int GoldPoint;
    public int SilverPoint;
    public int BronzePoint;
    private int minScore;



    void Start()
    {
        minScore = 0;
        //UpdateText(); // 初期表示
        UpdateText();
        ScoreEvaluation();
    }

    void Update()
    {
        //UpdateText();
        UpdateText();
        ScoreEvaluation();
    }

    // テキスト更新用のメソッド
    void UpdateText()
    {
        textMeshProUGUI.text = /*"Point: " + */PointCounter.Instance.Point.ToString();
    }

    private int ScoreEvaluation()
    {
        int currentPoint = PointCounter.Instance.Point;

        // すべて非表示にする
        RainbowScore1.SetActive(false); RainbowScore2.SetActive(false);
        GoldScore1.SetActive(false); GoldScore2.SetActive(false);
        SilverScore1.SetActive(false); SilverScore2.SetActive(false);
        BronzeScore1.SetActive(false); BronzeScore2.SetActive(false);

        // 各ランクの範囲に応じて2枚セットを表示
        if (currentPoint <= RainbowPoint && currentPoint > GoldPoint)
        {
            RainbowScore1.SetActive(true);
            RainbowScore2.SetActive(true);
            return 1;
        }
        else if (currentPoint <= GoldPoint && currentPoint > SilverPoint)
        {
            GoldScore1.SetActive(true);
            GoldScore2.SetActive(true);
            return 2;
        }
        else if (currentPoint <= SilverPoint && currentPoint > BronzePoint)
        {
            SilverScore1.SetActive(true);
            SilverScore2.SetActive(true);
            return 3;
        }
        else if (currentPoint <= BronzePoint && currentPoint > minScore)
        {
            BronzeScore1.SetActive(true);
            BronzeScore2.SetActive(true);
            return 4;
        }
        else
        {
            Debug.LogWarning("評価できないポイント値です");
            return 0;
        }
    }

}
