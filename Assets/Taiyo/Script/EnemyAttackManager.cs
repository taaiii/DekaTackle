using UnityEngine;
using System.Collections;

public class EnemyAttackManager : MonoBehaviour
{
    public float attackRange = 5f;
    public string leftEnemyTag = "EnemyL";
    public string rightEnemyTag = "EnemyR";

    public PlayerStates playerStates;

    private GameObject player;
    private Coroutine checkKeyCoroutine = null;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
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
            Debug.Log($"�G��|����: {enemy.name}");
            PointCounter.Point++;
            Destroy(enemy);
        }
    }

    private IEnumerator CheckKeyPressCoroutine()
    {
        Debug.Log("CheckKeyPressCoroutine: �J�n");

        while (playerStates.isCollision)
        {
            // �Е��������Ă���Ԃɂ����Е��������Ή���
            if ((Input.GetKey(KeyCode.F) && Input.GetKeyDown(KeyCode.J)) ||
                (Input.GetKey(KeyCode.J) && Input.GetKeyDown(KeyCode.F)))
            {
                playerStates.isCollision = false;
                Debug.Log("�����FF�܂���J�������Ȃ�������Е���������");
                break;
            }

            yield return null;
        }

        checkKeyCoroutine = null;
        Debug.Log("CheckKeyPressCoroutine: �I��");
    }
}
