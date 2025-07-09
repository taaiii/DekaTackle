using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager Instance { get; private set; }
    public TutorialEnemyManager EnemyManager;
    public TutorialMoveR MoveR;
    public TutorialMoveL MoveL;
    public JudgeAttackObserver AttackObserver;

    public GameObject balloonUI;
    public TextMeshProUGUI tutorialText;

    public TutorialStep currentStep;
    private Dictionary<TutorialStep, string> stepTextMap;

    [Header("テキストデータ（ScriptableObject）")]
    public TutorialTextData textData;

    private bool inputLocked = false;
    private float inputLockTimer = 0f;
    private float inputLockDuration = 0.2f;
    private bool IsSpownR = false;
    private bool IsSpownL = false;
    private bool isGogeza = false;

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
                //if(!isGogeza)
                //{
                //    AttackObserver.SetIsDogeza(true);
                //    isGogeza = true;
                //}
                NextText();

                break;
            case TutorialStep.Step1_2:
            case TutorialStep.Step1_3:
            case TutorialStep.Step1_4:
            case TutorialStep.Step1_5:
            case TutorialStep.Step1_6:
                NextText();
                break;
            case TutorialStep.Step1_7:

                //チュートリアル1の敵を作成
                SpwawnEnemyByDontMove();
                NextText();

                break;

            case TutorialStep.Step1_8:
            case TutorialStep.Step1_9:
                NextText();
                break;

            case TutorialStep.Step1_10_Tackle:

                //こうげきOK 
                AttackObserver.SetOkAttack(true);

                //攻撃されたか？
                if (AttackObserver.GetIsAttack())
                {
                    //攻撃は成功したか？
                    if (AttackObserver.GetSuccess())
                    {
                        AutoSerectNextText(TutorialStep.Step1_11_Success);
                        AttackObserver.SetOkAttack(false);
                        ShowBalloon(currentStep);
                    }
                    else
                    {
                        AutoSerectNextText(TutorialStep.Step1_13_Fail_1);
                        AttackObserver.SetOkAttack(false);
                        ShowBalloon(currentStep);
                    }
                }
                break;
            case TutorialStep.Step1_11_Success:
                NextText(); break;
            case TutorialStep.Step1_12:

                SerectNextText(TutorialStep.Step2_1);
                ShowBalloon(currentStep);

                break;
            case TutorialStep.Step1_13_Fail_1:
                NextText(); 
                break;
            case TutorialStep.Step1_14_Fail_2:

                AttackObserver.SetIsAttack(false);
                AttackObserver.SetOkAttack(true);
                SerectNextText(TutorialStep.Step1_10_Tackle);
                break;
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

    //テキスト送り
    void NextText()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            currentStep++;
            ShowBalloon(currentStep);
        }
    }

    void AutoSerectNextText(TutorialStep step)
    {
        currentStep = step;
        ShowBalloon(currentStep);
    }

    void SerectNextText(TutorialStep step)
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            currentStep = step;
            ShowBalloon(currentStep);
        }
    }


    //チュートリアルに合わせ止まっている敵を作成
    void SpwawnEnemyByDontMove()
    {
        //動かない
        MoveL.SetMove(false);
        MoveR.SetMove(false);

        //すでにスポーンしているか
        if (!IsSpownL)
        {
            IsSpownL = true;
            EnemyManager.SpawnState1();
        }
    }
}
