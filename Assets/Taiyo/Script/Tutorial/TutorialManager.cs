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
    public TutorialSceneTransition tutorialSceneTransition;

    public GameObject balloonUI;
    public TextMeshProUGUI tutorialText;

    public TutorialStep currentStep;
    private Dictionary<TutorialStep, string> stepTextMap;

    [Header("�e�L�X�g�f�[�^�iScriptableObject�j")]
    public TutorialTextData textData;

    private bool IsSpown = false;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        // ScriptableObject����ϊ�
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
        //�`���[�g���A���C�x���g����
        //�e�e�L�X�g�ŋN����C�x���g
        switch (currentStep)
        {
            case TutorialStep.Step1_1:
                NextText();
                break;
            case TutorialStep.Step1_2:
                NextText();
                tutorialSceneTransition.FadeAndLoadScene("Main Scene 2");
                break;

            case TutorialStep.Step1_3:
            case TutorialStep.Step1_4:
            case TutorialStep.Step1_5:
            case TutorialStep.Step1_6:
                NextText();
                break;

            case TutorialStep.Step1_7:

                //�`���[�g���A��1�̓G���쐬
                SpwawnEnemyByState1();
                NextText();

                break;

            case TutorialStep.Step1_8:
            case TutorialStep.Step1_9:
                NextText();
                break;

            case TutorialStep.Step1_10_Tackle:

                //��������OK 
                AttackObserver.SetOkAttack(true);

                //�U���������H
                if (AttackObserver.GetIsAttack())
                {
                    //�U���̐��돈��
                    AttackState_1Result();
                }
                break;

            case TutorialStep.Step1_11_Success:

                NextText();
                IsSpown = false;    //���̍쐬�̂���false��

                break;
            case TutorialStep.Step1_12:

                SerectNextText(TutorialStep.Step2_1);
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
                //��������OK 
                AttackObserver.SetOkAttack(true);

                //�U���������H
                if (AttackObserver.GetIsAttack())
                {
                    AttackState_2Result();
                }

                //�s���߂����m�F
                AttackState_2PassEnemy();
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
                NextText();
                break;
            case TutorialStep.StepComplate:

                break;
        }
    }

    //�����\��(�����o���\��)
    void ShowBalloon(TutorialStep step)
    {
        if (stepTextMap.TryGetValue(step, out string message))
        {
            balloonUI.SetActive(true);
            tutorialText.text = message;
        }
    }

    //�����o���폜
    void HideBalloon()
    {
        balloonUI.SetActive(false);
    }

    //�e�L�X�g����
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


    //�`���[�g���A���ɍ��킹�~�܂��Ă���G���쐬
    void SpwawnEnemyByState1()
    {
        //�����Ȃ�
        MoveL.SetMove(false);
        if(currentStep == TutorialStep.Step1_10_Tackle)
        MoveR.SetMove(false);

        //���łɃX�|�[�����Ă��邩
        if (!IsSpown)
        {
            IsSpown = true;
            EnemyManager.SpawnState1();
        }
    }

    //�`���[�g���A��2�̓G���쐬
    void SpwawnEnemyByState2()
    {
        //����
        MoveL.SetMove(true);
        MoveR.SetMove(true);
        //���łɃX�|�[�����Ă��邩
        if (!IsSpown)
        {
            IsSpown = true;
            EnemyManager.SpawnState2();
        }
    }

    void AttackState_1Result()
    {
        //�U���͐����������H
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
    void AttackState_2Result()
    {
        //�U���͐����������H
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
    void AttackState_2PassEnemy()
    {
        if (MoveL.GetIsMiss())
        {
            AutoSerectNextText(TutorialStep.Step2_3_Fail_1);
        }
    }

}
