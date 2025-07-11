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

    public GameObject fuki1;
    public GameObject fuki2;
    public GameObject muse1;
    public GameObject muse2;

    public GameObject balloonUI;
    public TextMeshProUGUI tutorialText;

    public TutorialStep currentStep;
    private Dictionary<TutorialStep, string> stepTextMap;

    [Header("�e�L�X�g�f�[�^�iScriptableObject�j")]
    public TutorialTextData textData;

    private bool IsSpown = false;
    private float textCount = 0;

    public float TextInterval = 3f;
    public float switchInterval = 0.5f;     // �؂�ւ��Ԋu�i�b�j

    const float DelayToneTime = 1f;
    float ToneCount = 0f;

    private bool isViewText = false;
    private bool showFirst = true;

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
        // �����\���̐ݒ�
        fuki1.SetActive(true);
        fuki2.SetActive(false);
        muse1.SetActive(true);
        muse2.SetActive(false);
        // �w�莞�Ԃ��Ƃɐ؂�ւ�
        InvokeRepeating("SwitchObjects", switchInterval, switchInterval);

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
            case TutorialStep.Step1_2:
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
                AttackObserver.SetIsDogeza(true);

                ToneCount += Time.deltaTime;
                if(ToneCount > DelayToneTime)
                {
                    tutorialSceneTransition.ToneDown();
                }

                NextText();
                break;
            case TutorialStep.Step3_2_FadeIn:
                NextText();
                break;

            case TutorialStep.Step3_3:
            case TutorialStep.Step3_4:
            case TutorialStep.Step3_5:
                NextText();
                break;
            case TutorialStep.Step3_6_FadeOut:
                tutorialSceneTransition.ToneUp();
                AttackObserver.SetHowDogeza(true);
                isViewText = true;

                if (AttackObserver.GetIsClearDogeza())
                {
                    AutoSerectNextText(TutorialStep.Step3_7);
                    isViewText = false;
                }
                break;
            case TutorialStep.Step3_7:
            case TutorialStep.Step3_8:
            case TutorialStep.Step3_9:
            case TutorialStep.Step3_10:
                NextText();
                break;
            case TutorialStep.StepComplate:
                tutorialSceneTransition.FadeAndLoadScene("test");
                //�`���[�g���A���ł̓_����������
                PointCounter.Instance.Point = 0;
                break;
        }
        if (isViewText)
        {
            HideBalloon();
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
        fuki1.SetActive(false);
        fuki2.SetActive(false);
    }

    //�e�L�X�g����
    void NextText()
    {
        if (AutoNextText() || Input.GetKeyDown("d") || Input.GetKeyDown("a"))
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
        if (AutoNextText() || Input.GetKeyDown("d") || Input.GetKeyDown("a"))
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

    bool AutoNextText()
    {
        textCount += Time.deltaTime;
        if(textCount > TextInterval || Input.GetKeyDown("d") || Input.GetKeyDown("a"))
        {
            textCount = 0;
            return true;
        }
        return false;
    }

    void SwitchObjects()
    {
        if(!isViewText)
        {
            showFirst = !showFirst;
            fuki1.SetActive(showFirst);
            fuki2.SetActive(!showFirst);
            muse1.SetActive(showFirst);
            muse2.SetActive(!showFirst);
        }
    }
}
