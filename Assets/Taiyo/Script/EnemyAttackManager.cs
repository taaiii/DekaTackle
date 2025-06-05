using UnityEngine;
using System.Collections;

public class EnemyAttackManager : MonoBehaviour
{
    public float attackRange = 5f;
    public string leftEnemyTag = "EnemyL";
    public string rightEnemyTag = "EnemyR";

    public PlayerStates playerStates;

    private GameObject player;
    private Coroutine checkKeyCoroutine = null; // コルーチン制御用

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        // isCollisionがfalseのときのみ攻撃可能
        if (Input.GetKeyUp(KeyCode.A) && playerStates.isCollision == false)
        {
            ProcessInput(Vector3.left, leftEnemyTag, rightEnemyTag);
        }

        if (Input.GetKeyUp(KeyCode.D) && playerStates.isCollision == false)
        {
            ProcessInput(Vector3.right, rightEnemyTag, leftEnemyTag);
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
                // 成功（近い敵を正しく攻撃）
                playerStates.isCollision = false;
                HandleAttack(inputEnemy);
                return;
            }
        }

        // ミス（遠い敵を攻撃、または敵がいない）
        playerStates.isCollision = true;
        Debug.Log("ミス：遠い敵を攻撃したか敵がいなかった");

        // コルーチンがまだ起動していなければスタート
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
            // f と j を同時押ししているかチェック
            if (Input.GetKey(KeyCode.F) && Input.GetKey(KeyCode.J))
            {
                playerStates.isCollision = false;
                Debug.Log("FとJを同時押し → isCollision = false");
                break;
            }

            yield return null;
        }

        checkKeyCoroutine = null; // 終了したらリセット
        Debug.Log("CheckKeyPressCoroutine: 終了");
    }
}
