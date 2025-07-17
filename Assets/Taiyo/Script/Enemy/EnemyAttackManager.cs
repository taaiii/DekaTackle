using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyAttackManager : MonoBehaviour
{
    public float scaleSpeed = 2f;
    private float originalYScale;
    public float waitTime;
    public float DogezaImagesMaxSize;
    [SerializeField] private GameObject DogezaImages;
    [SerializeField] private GameObject MaskImages;
    [SerializeField] private GameObject KariMiss;

    public float attackRange = 5f;
    public string leftEnemyTag = "EnemyL";
    public string rightEnemyTag = "EnemyR";

    public PlayerStates playerStates;
    public SEPlayer sePlayer;
    public bool isSorry = false;
    private ShakeCamera shakeCamera;

    public GameObject tackleSuccessImageL; // ← A用
    public GameObject tackleSuccessImageR; // ← D用

    public GameObject tackleSound;

    public float DrawimageTime = 0.2f;

    public int inFever = 0;

    private GameObject player;
    private Coroutine checkKeyCoroutine = null;

    void Start()
    {
        originalYScale = transform.localScale.y;
        tackleSuccessImageL.SetActive(false);
        tackleSuccessImageR.SetActive(false);
        player = GameObject.FindWithTag("Player");

        shakeCamera = Camera.main.GetComponent<ShakeCamera>();
        if (shakeCamera == null)
        {
            Debug.LogWarning("ShakeCameraがMainCameraにありません！");
        }

        StartCoroutine(DelayedProcessCoroutine());
    }

    void Update()
    {
        if (!playerStates.isCollision)
        {
            if (inFever == 0)
            {
                if (Input.GetKeyUp(KeyCode.A))
                {
                    ProcessInput(Vector3.left, leftEnemyTag, rightEnemyTag, "A");
                    if (shakeCamera != null)
                    {
                        shakeCamera.TriggerShake(0.3f, 0.15f);
                    }
                }

                if (Input.GetKeyUp(KeyCode.D))
                {
                    ProcessInput(Vector3.right, rightEnemyTag, leftEnemyTag, "D");
                    if (shakeCamera != null)
                    {
                        shakeCamera.TriggerShake(0.3f, 0.15f);
                    }
                }
            }
            else if (inFever == 1)
            {
                if (Input.GetKeyUp(KeyCode.A))
                {
                    if (shakeCamera != null)
                    {
                        shakeCamera.TriggerShake(0.3f, 0.15f);
                        OnTackleSuccess("A");
                        playerStates.isCollision = false;
                        PointCounter.Instance.Point++;
                    }
                }

                if (Input.GetKeyUp(KeyCode.D))
                {
                    if (shakeCamera != null)
                    {
                        shakeCamera.TriggerShake(0.3f, 0.15f);
                        OnTackleSuccess("D");
                        playerStates.isCollision = false;
                        PointCounter.Instance.Point++;
                    }
                }
            }
        }
    }

    void ProcessInput(Vector3 inputDirection, string inputTag, string oppositeTag, string key)
    {
        GameObject inputEnemy = GetNearestEnemy(inputTag, inputDirection);
        GameObject oppositeEnemy = GetNearestEnemy(oppositeTag, -inputDirection);

        float inputDist = inputEnemy ? Vector3.Distance(player.transform.position, inputEnemy.transform.position) : Mathf.Infinity;
        float oppositeDist = oppositeEnemy ? Vector3.Distance(player.transform.position, oppositeEnemy.transform.position) : Mathf.Infinity;

        if (inputEnemy != null && inputDist <= attackRange)
        {
            if (inputDist <= oppositeDist)
            {
                OnTackleSuccess(key);
                playerStates.isCollision = false;
                HandleAttack(inputEnemy);
                return;
            }
        }

        playerStates.isCollision = true;
        Debug.Log("ミス：遠い敵を攻撃 or 敵がいない");

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
            PointCounter.Instance.Point++;
            Destroy(enemy);
        }
    }

    void OnTackleSuccess(string key)
    {
        sePlayer.SetUseOneShot(true);
        sePlayer.PlayTackleSE();

        if (key == "A")
        {
            StartCoroutine(ShowSuccessImage(tackleSuccessImageL));
        }
        else if (key == "D")
        {
            StartCoroutine(ShowSuccessImage(tackleSuccessImageR));
        }
    }

    private IEnumerator ShowSuccessImage(GameObject image)
    {
        image.SetActive(true);
        yield return new WaitForSeconds(DrawimageTime);
        image.SetActive(false);
    }

    private IEnumerator CheckKeyPressCoroutine()
    {
        Debug.Log("CheckKeyPressCoroutine: 開始");
        sePlayer.SetUseOneShot(false);
        sePlayer.PlaysippaiSE();

        //描画NG
        DrawUiObserver.Instance.SetIsView(false);

        float holdTime = 0f;
        float duration = 2.0f;
        float startY = originalYScale;
        float targetY = originalYScale + 6.0f;

        KariMiss.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        KariMiss.SetActive(false);
        DogezaImages.SetActive(true);

        while (playerStates.isCollision)
        {
            if (inFever == 2)
            {
                DogezaImages.SetActive(false);
                checkKeyCoroutine = null;
                sePlayer.StopSE();
                playerStates.isCollision = false;
                Debug.Log("inFeverが2になったので中断");
                yield break;
            }

            if (Input.GetKey(KeyCode.F) && Input.GetKey(KeyCode.J))
            {
                isSorry = true;
                holdTime += Time.deltaTime;

                float t = Mathf.Clamp01(holdTime / duration);
                Vector3 scale = MaskImages.transform.localScale;
                scale.y = Mathf.Lerp(startY, targetY, t);
                MaskImages.transform.localScale = scale;

                if (holdTime >= duration)
                {
                    playerStates.isCollision = false;
                    Debug.Log("成功：FとJを2秒間同時に押した");
                    DogezaImages.SetActive(false);

                    //描画OK
                    DrawUiObserver.Instance.SetIsView(true);

                    break;
                }
            }
            else
            {
                isSorry = false;
                holdTime = 0f;

                Vector3 scale = MaskImages.transform.localScale;
                scale.y = startY;
                MaskImages.transform.localScale = scale;
            }

            yield return null;
        }

        isSorry = false;
        checkKeyCoroutine = null;
        sePlayer.StopSE();
        Debug.Log("CheckKeyPressCoroutine: 終了");
    }

    private IEnumerator DelayedProcessCoroutine()
    {
        yield return new WaitForSeconds(60f);
        inFever = 2;

        yield return new WaitForSeconds(3f);
        inFever = 1;

        yield return new WaitForSeconds(10f);
        inFever = 2;
    }
}
