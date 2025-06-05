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
        // isCollision = false の時のみ攻撃入力を受け付ける
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
                // 成功：正しい敵を攻撃
                playerStates.isCollision = false;
                HandleAttack(inputEnemy);
                return;
            }
        }

        // ミス：遠い敵 or 敵なし
        playerStates.isCollision = true;
        Debug.Log("ミス：遠い敵を攻撃 or 敵がいない");

        // コルーチンが動いていなければ開始
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

            // 方向が逆ならスキップ
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
            Debug.Log($"敵を倒した: {enemy.name}");
            PointCounter.Point++;
            Destroy(enemy);
        }
    }

    private IEnumerator CheckKeyPressCoroutine()
    {
        Debug.Log("CheckKeyPressCoroutine: 開始");

        while (playerStates.isCollision)
        {
            // 片方を押している間にもう片方を押せば解除
            if ((Input.GetKey(KeyCode.F) && Input.GetKeyDown(KeyCode.J)) ||
                (Input.GetKey(KeyCode.J) && Input.GetKeyDown(KeyCode.F)))
            {
                playerStates.isCollision = false;
                Debug.Log("成功：FまたはJを押しながらもう片方を押した");
                break;
            }

            yield return null;
        }

        checkKeyCoroutine = null;
        Debug.Log("CheckKeyPressCoroutine: 終了");
    }
}
