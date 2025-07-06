using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager Instance { get; private set; }
    public TutorialEnemyManager tutorialEnemyManager;

    public GameObject balloonUI;
    public TextMeshProUGUI tutorialText;

    public TutorialStep currentStep;
    private Dictionary<TutorialStep, string> stepTextMap;

    [Header("テキストデータ（ScriptableObject）")]
    public TutorialTextData textData;

    private bool inputLocked = false;
    private float inputLockTimer = 0f;
    private float inputLockDuration = 0.2f;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        // ScriptableObjectから辞書に変換
        stepTextMap = new Dictionary<TutorialStep, string>();
        foreach (var entry in textData.tutorialSteps)
        {
            if (!stepTextMap.ContainsKey(entry.step))
                stepTextMap[entry.step] = entry.text;
        }

        currentStep = TutorialStep.Step1_1;
        ShowBalloon(currentStep);
    }

    void Update()
    {
        if (inputLocked)
        {
            inputLockTimer += Time.deltaTime;
            if (inputLockTimer >= inputLockDuration)
            {
                inputLocked = false;
            }
            return;
        }

        //ほんとごめんなさい。。。。。
        //各テキストで起きるイベント
        switch (currentStep)
        {
            case TutorialStep.Step1_1:
            case TutorialStep.Step1_2:
            case TutorialStep.Step1_3:
            case TutorialStep.Step1_4:
            case TutorialStep.Step1_5:
            case TutorialStep.Step1_6:
            case TutorialStep.Step1_7:
            case TutorialStep.Step1_8:

                tutorialEnemyManager.SpawnState1();


                if (Input.GetKeyDown(KeyCode.Return))
                {
                    currentStep++;
                    ShowBalloon(currentStep);
                }

                break;
            case TutorialStep.Step1_9:
            case TutorialStep.Step1_10_Tackle:
            case TutorialStep.Step1_11_Success:
            case TutorialStep.Step1_12:
            case TutorialStep.Step1_13_Fail_1:
            case TutorialStep.Step1_14_Fail_2:
            case TutorialStep.Step2_1:
            case TutorialStep.Step2_2_Success:
            case TutorialStep.Step2_3_Fail_1:
            case TutorialStep.Step2_4_Fail_2:
            case TutorialStep.Step3_1:
            case TutorialStep.Step3_2_FadeIn:
            case TutorialStep.Step3_3:
            case TutorialStep.Step3_4:
            case TutorialStep.Step3_5:
            case TutorialStep.Step3_6_FadeOut:
            case TutorialStep.Step3_7:
            case TutorialStep.Step3_8:
            case TutorialStep.Step3_9:
            case TutorialStep.Step3_10:
            case TutorialStep.StepComplate:

                if (Input.GetKeyDown(KeyCode.Return))
                {
                    currentStep++;
                    ShowBalloon(currentStep);
                }
                break;
        }
    }

    //文字表示(吹き出し表示)
    void ShowBalloon(TutorialStep step)
    {
        if (stepTextMap.TryGetValue(step, out string message))
        {
            balloonUI.SetActive(true);
            tutorialText.text = message;
        }
    }

    //吹き出し削除
    void HideBalloon()
    {
        balloonUI.SetActive(false);
    }
}
