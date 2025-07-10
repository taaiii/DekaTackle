using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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

    private bool IsSpown = false;

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
        // ScriptableObjectから変換
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
        //チュートリアルイベント制御
        //各テキストで起きるイベント
        switch (currentStep)
        {
            case TutorialStep.Step1_1:
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
                SpwawnEnemyByState1();
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

                NextText();
                IsSpown = false;    //次の作成のためfalseに


                break;
            case TutorialStep.Step1_12:

                SerectNextText(TutorialStep.Step2_1);
                ShowBalloon(currentStep);
                AttackObserver.SetIsAttack(false);

                break;
            case TutorialStep.Step1_13_Fail_1:
                NextText(); 
                break;
            case TutorialStep.Step1_14_Fail_2:

                AttackObserver.SetIsAttack(false);
                SerectNextText(TutorialStep.Step1_10_Tackle);
                break;
            case TutorialStep.Step2_1:

                SpwawnEnemyByState2();
                MoveL.AddLifeCount();
                //こうげきOK 
                AttackObserver.SetOkAttack(true);

                //攻撃されたか？
                if (AttackObserver.GetIsAttack())
                {
                    //攻撃は成功したか？
                    if (AttackObserver.GetSuccess())
                    {
                        AutoSerectNextText(TutorialStep.Step2_2_Success);
                        AttackObserver.SetOkAttack(false);
                        ShowBalloon(currentStep);
                    }
                    else
                    {
                        AutoSerectNextText(TutorialStep.Step2_3_Fail_1);
                        AttackObserver.SetOkAttack(false);
                        ShowBalloon(currentStep);
                    }
                }

                //行き過ぎ処理
                if (MoveL.GetIsMiss())
                {
                    AutoSerectNextText(TutorialStep.Step2_3_Fail_1);
                }
                break;

            case TutorialStep.Step2_2_Success:

                SerectNextText(TutorialStep.Step3_1);
                break;
            case TutorialStep.Step2_3_Fail_1:
                NextText();
                break;
            case TutorialStep.Step2_4_Fail_2:

                IsSpown = false;
                AttackObserver.SetIsAttack(false);
                MoveL.SetIsMiss(false);
                MoveL.ResetLifeCount();
                SerectNextText(TutorialStep.Step2_1);

                break;
            case TutorialStep.Step3_1:
                NextText();
                break;
            case TutorialStep.Step3_2_FadeIn:
                AttackObserver.SetIsDogeza(true);
                NextText();
                break;

            case TutorialStep.Step3_3:
            case TutorialStep.Step3_4:
            case TutorialStep.Step3_5:
                NextText();
                break;
            case TutorialStep.Step3_6_FadeOut:
                    AttackObserver.SetHowDogeza(true);
                if(AttackObserver.GetIsClearDogeza())
                {
                    AutoSerectNextText(TutorialStep.Step3_7);
                }
                break;
            case TutorialStep.Step3_7:
            case TutorialStep.Step3_8:
            case TutorialStep.Step3_9:
            case TutorialStep.Step3_10:
            case TutorialStep.StepComplate:

                NextText();
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
    void SpwawnEnemyByState1()
    {
        //動かない
        MoveL.SetMove(false);
        if(currentStep == TutorialStep.Step1_10_Tackle)
        MoveR.SetMove(false);

        //すでにスポーンしているか
        if (!IsSpown)
        {
            IsSpown = true;
            EnemyManager.SpawnState1();
        }
    }

    //チュートリアル2の敵を作成
    void SpwawnEnemyByState2()
    {
        //動く
        MoveL.SetMove(true);
        MoveR.SetMove(true);
        //すでにスポーンしているか
        if (!IsSpown)
        {
            IsSpown = true;
            EnemyManager.SpawnState2();
        }
    }

}
