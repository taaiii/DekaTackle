using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;

public class Counttext : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI; // TextMeshProオブジェクトへの参照
                                            // カウンター
    public GameObject RainbowScore;
    public GameObject GoldScore;
    public GameObject SilverScore;
    public GameObject BronzeScore;
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
        if (currentPoint <= RainbowPoint && currentPoint>GoldPoint)
        {
            RainbowScore.SetActive(true);
            UpdateText(); 
            return 1;
        }
        if (currentPoint <= GoldPoint && currentPoint>SilverPoint)
        {
            GoldScore.SetActive(true);
            UpdateText(); 
            return 2;
        }
        if (currentPoint <= SilverPoint && currentPoint > BronzePoint)
        {
            SilverScore.SetActive(true);
            UpdateText(); 
            return 3;
        }
        if (currentPoint <= BronzePoint && currentPoint > minScore)
        {
            BronzeScore.SetActive(true);
            UpdateText(); 
            return 4;
        }else
        {
            Debug.Log("エラーですよ");
            return 0;
        }
    }
}
