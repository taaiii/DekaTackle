using UnityEngine;
using System.Collections;

public class EnemyAttackManager : MonoBehaviour
{
    public float attackRange = 5f;
    public string leftEnemyTag = "EnemyL";
    public string rightEnemyTag = "EnemyR";

    public PlayerStates playerStates;
    public SEPlayer sePlayer;
    public bool isSorry = false;

    public GameObject tackleSuccesseImage;
    public GameObject tackleFailureImage;

    public GameObject tackleSound;

    public float DrawimageTime = 0.5f;

    private GameObject player;
    private Coroutine checkKeyCoroutine = null;
    private float successeTimer = 0;
    //private float FailTimer = 0;

    void Start()
    {
        tackleSuccesseImage.SetActive(false);
        tackleFailureImage.SetActive(false);
        player = GameObject.FindWithTag("Player");

        successeTimer = 0;
        //FailTimer = 0;
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

        // isCollision = false �̎��̂ݍU�����͂��󂯕t����
        if (!playerStates.isCollision)
        {
            if (Input.GetKeyUp(KeyCode.A))
            {
                ProcessInput(Vector3.left, leftEnemyTag, rightEnemyTag);
            }

            if (Input.GetKeyUp(KeyCode.D))
            {
                ProcessInput(Vector3.right, rightEnemyTag, leftEnemyTag);
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

        // �R���[�`���������Ă��Ȃ���ΊJ�n
        if (checkKeyCoroutine == null)
        {
            checkKeyCoroutine = StartCoroutine(CheckKeyPressCoroutine());
        }
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
        sePlayer.PlayTackleSE(); // SE��炷
    }


    private IEnumerator CheckKeyPressCoroutine()
    {
        Debug.Log("CheckKeyPressCoroutine: �J�n");

        float holdTime = 0f; // ���������Ă��鎞�Ԃ̃J�E���g

        while (playerStates.isCollision)
        {
            // ������������Ă���Ԃ͎��Ԃ����Z
            if (Input.GetKey(KeyCode.F) && Input.GetKey(KeyCode.J))
            {
                isSorry = true;
                holdTime += Time.deltaTime;

                if (holdTime >= 3f)
                {
                    playerStates.isCollision = false;
                    Debug.Log("�����FF��J��3�b�ԓ����ɉ�����");
                    break;
                }
            }
            else
            {
                // �ǂ��炩�������ꂽ�烊�Z�b�g
                isSorry= false;
                if (holdTime > 0f)
                {
                    Debug.Log("�L�[�������ꂽ�̂ŃJ�E���g���Z�b�g");
                }
                holdTime = 0f;
            }

            yield return null;
        }
        isSorry = false;
        checkKeyCoroutine = null;
        Debug.Log("CheckKeyPressCoroutine: �I��");
    }

}
