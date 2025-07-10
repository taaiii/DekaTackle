using UnityEngine;
using System.Collections;

public class TutorialEnemyAttackManager : MonoBehaviour
{
    //�ȉ��y�����Q�[�W�p�I�u�W�F�N�g�ƕϐ�
    public float scaleSpeed = 2f;               // �g��X�s�[�h

    private float originalYScale;
    public float waitTime;
    public float DogezaImagesMaxSize;
    [SerializeField] private GameObject DogezaImages;
    [SerializeField] private GameObject MaskImages;
    [SerializeField] private GameObject KariMiss;
    //
    public float attackRange = 5f;
    public string leftEnemyTag = "EnemyL";
    public string rightEnemyTag = "EnemyR";

    public PlayerStates playerStates;
    public SEPlayer sePlayer;
    public bool isSorry = false;
    private ShakeCamera shakeCamera;

    public GameObject tackleSuccesseImage;
    public GameObject tackleFailureImage;

    public GameObject tackleSound;

    public float DrawimageTime = 0.5f;

    public int inFever = 0;

    private GameObject player;
    private Coroutine checkKeyCoroutine = null;
    private float successeTimer = 0;

    //����ʒm
    public JudgeAttackObserver judgeAttackObserver;

    //private float FailTimer = 0;

    void Start()
    {
        originalYScale = transform.localScale.y;//�}�X�N�̏����̑傫���̕ۑ�
        tackleSuccesseImage.SetActive(false);
        tackleFailureImage.SetActive(false);
        player = GameObject.FindWithTag("Player");

        // �ǉ��FCameraShake���擾
        shakeCamera = Camera.main.GetComponent<ShakeCamera>();
        if (shakeCamera == null)
        {
            Debug.LogWarning("ShakeCamera�R���|�[�l���g��MainCamera�ɂ���܂���I");
        }

        successeTimer = 0;
        tackleSuccesseImage.SetActive(false);
        tackleFailureImage.SetActive(false);
        player = GameObject.FindWithTag("Player");

        successeTimer = 0;
        //FailTimer = 0;
        StartCoroutine(DelayedProcessCoroutine());
    }

    void Update()
    {
        if (tackleSuccesseImage == true)
        {
            successeTimer += Time.deltaTime;
            //tackleSuccesseImage.transform.position = new Vector3( successeTimer * 3, 0, 0 );
            if (successeTimer > DrawimageTime)
            {
                tackleSuccesseImage.SetActive(false);
                successeTimer = 0;
            }
        }
        if (judgeAttackObserver.GetOkAttack())
        {
            if (inFever == 0)
            {
                if (Input.GetKeyUp(KeyCode.A))
                {
                    ProcessInput(Vector3.left, leftEnemyTag, rightEnemyTag);

                    // ��ʗh�炷�i�h�ꂪ�ݒ肳��Ă���΁j
                    if (shakeCamera != null)
                    {
                        shakeCamera.TriggerShake(0.3f, 0.15f);
                    }
                }

                if (Input.GetKeyUp(KeyCode.D))
                {
                    ProcessInput(Vector3.right, rightEnemyTag, leftEnemyTag);

                    if (shakeCamera != null)
                    {
                        shakeCamera.TriggerShake(0.3f, 0.15f);

                    }
                }

            }
            else if (inFever == 1)
            {
                if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
                {
                    if (shakeCamera != null)
                    {
                        shakeCamera.TriggerShake(0.3f, 0.15f);
                        OnTackleSuccess();
                        playerStates.isCollision = false;
                        PointCounter.Instance.Point++;
                    }
                }
            }
        }

        if (judgeAttackObserver.GetIsDogeza())
        {
            // �R���[�`���������Ă��Ȃ���ΊJ�n
            if (checkKeyCoroutine == null)
            {
                playerStates.isCollision = true;
                checkKeyCoroutine = StartCoroutine(CheckKeyPressCoroutine());
            }
        }

    }

    void ProcessInput(Vector3 inputDirection, string inputTag, string oppositeTag)
    {
        GameObject inputEnemy = GetNearestEnemy(inputTag, inputDirection);
        GameObject oppositeEnemy = GetNearestEnemy(oppositeTag, -inputDirection);

        float inputDist = inputEnemy ? Vector3.Distance(player.transform.position, inputEnemy.transform.position) : Mathf.Infinity;
        float oppositeDist = oppositeEnemy ? Vector3.Distance(player.transform.position, oppositeEnemy.transform.position) : Mathf.Infinity;

        if (inputEnemy != null && inputDist <= attackRange)
        {
            if (inputDist <= oppositeDist)
            {
                // �����F�������G���U��
                OnTackleSuccess();
                playerStates.isCollision = false;
                HandleAttack(inputEnemy);
                return;
            }
        }

        // �~�X�F�����G or �G�Ȃ�
        playerStates.isCollision = true;
        Debug.Log("�~�X�F�����G���U�� or �G�����Ȃ�");

        //�A�^�b�N�����B���s�ʒm
        judgeAttackObserver.SetIsAttack(true);
        judgeAttackObserver.SetSuccess(false);

    }

    GameObject GetNearestEnemy(string tag, Vector3 direction)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(tag);
        GameObject nearest = null;
        float minDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            Vector3 toEnemy = enemy.transform.position - player.transform.position;

            // �������t�Ȃ�X�L�b�v
            if (Vector3.Dot(toEnemy.normalized, direction) < 0.5f) continue;

            float dist = toEnemy.magnitude;
            if (dist < attackRange && dist < minDistance)
            {
                minDistance = dist;
                nearest = enemy;
            }
        }

        return nearest;
    }

    void HandleAttack(GameObject enemy)
    {
        if (enemy != null)
        {
            tackleSuccesseImage.SetActive(true);
            Debug.Log($"�G��|����: {enemy.name}");
            PointCounter.Instance.Point++;
            Destroy(enemy);
        }
    }
    // ��FEnemyAttackManager.cs �̒�
    void OnTackleSuccess()
    {
        // �_���[�W�����Ȃǁc
        sePlayer.SetUseOneShot(true);
        sePlayer.PlayTackleSE(); // SE��炷

        //�A�^�b�N�����B�����ʒm
        judgeAttackObserver.SetIsAttack(true);
        judgeAttackObserver.SetSuccess(true);
    }


    private IEnumerator CheckKeyPressCoroutine()
    {
        Debug.Log("CheckKeyPressCoroutine: �J�n");

        sePlayer.SetUseOneShot(false);
        sePlayer.PlaysippaiSE();

        float holdTime = 0f;
        Vector3 currentScale = MaskImages.transform.localScale;

        KariMiss.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        KariMiss.SetActive(false);
        DogezaImages.SetActive(true);

        while (playerStates.isCollision)
        {

            if (inFever == 1)
            {
                DogezaImages.SetActive(false);
                checkKeyCoroutine = null;
                sePlayer.StopSE();
                playerStates.isCollision = false;
                Debug.Log("inFever��1�ɂȂ����̂Œ��f");
                yield break;
            }
            if (judgeAttackObserver.GetHowDogeza())
            {
                if (Input.GetKey(KeyCode.F) && Input.GetKey(KeyCode.J))
                {

                    isSorry = true;
                    holdTime += Time.deltaTime;
                    currentScale.y += scaleSpeed * holdTime;

                    if (holdTime >= 2f)
                    {
                        playerStates.isCollision = false;
                        Debug.Log("�����FF��J��2�b�ԓ����ɉ�����");
                        DogezaImages.SetActive(false);
                        judgeAttackObserver.SetIsClearDogeza(true);
                        break;
                    }
                }
            }
            else
            {
                isSorry = false;
                if (holdTime > 0f)
                {
                    Debug.Log("�L�[�������ꂽ�̂ŃJ�E���g���Z�b�g");
                }

                currentScale.y = originalYScale;
                holdTime = 0f;
            }

            MaskImages.transform.localScale = currentScale;
            yield return null;
        }

        isSorry = false;
        checkKeyCoroutine = null;
        sePlayer.StopSE();
        judgeAttackObserver.SetIsDogeza(false);
        Debug.Log("CheckKeyPressCoroutine: �I��");
    }


    private IEnumerator DelayedProcessCoroutine()
    {
        yield return new WaitForSeconds(60f);
        inFever = 1;

        yield return new WaitForSeconds(10f);
        inFever = 2;
    }
}
