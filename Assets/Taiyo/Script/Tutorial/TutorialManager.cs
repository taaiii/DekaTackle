using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager Instance { get; private set; }

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

        currentStep = TutorialStep.Step1;
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

        switch (currentStep)
        {
            case TutorialStep.Step1:
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    currentStep = TutorialStep.Step2;
                    ShowBalloon(currentStep);
                }
                break;

            case TutorialStep.Step2:
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    currentStep = TutorialStep.Step3;
                    ShowBalloon(currentStep);
                }
                break;

            case TutorialStep.Step3:
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    HideBalloon();
                    currentStep = TutorialStep.Complete;
                    ShowBalloon(currentStep);
                }
                break;

            case TutorialStep.Complete:
                if (Input.GetKeyDown(KeyCode.Return))
                {
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
