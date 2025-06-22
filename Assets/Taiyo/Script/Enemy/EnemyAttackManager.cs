using UnityEngine;
using System.Collections;

public class EnemyAttackManager : MonoBehaviour
{
    //以下土下座ゲージ用オブジェクトと変数
    public float scaleSpeed = 2f;               // 拡大スピード

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
    //private float FailTimer = 0;

    void Start()
    {
        originalYScale = transform.localScale.y;//マスクの初期の大きさの保存
        tackleSuccesseImage.SetActive(false);
        tackleFailureImage.SetActive(false);
        player = GameObject.FindWithTag("Player");

        // 追加：CameraShakeを取得
        shakeCamera = Camera.main.GetComponent<ShakeCamera>();
        if (shakeCamera == null)
        {
            Debug.LogWarning("ShakeCameraコンポーネントがMainCameraにありません！");
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

        // isCollision = false の時のみ攻撃入力を受け付ける
        if (!playerStates.isCollision)
        {
            if (inFever == 0)
            {
                if (Input.GetKeyUp(KeyCode.A))
                {
                    ProcessInput(Vector3.left, leftEnemyTag, rightEnemyTag);

                    // 画面揺らす（揺れが設定されていれば）
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
                OnTackleSuccess();
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
            tackleSuccesseImage.SetActive(true);
            Debug.Log($"敵を倒した: {enemy.name}");
            PointCounter.Instance.Point++;
            Destroy(enemy);
        }
    }
    // 例：EnemyAttackManager.cs の中
    void OnTackleSuccess()
    {
        // ダメージ処理など…
        sePlayer.PlayTackleSE(); // SEを鳴らす
    }


    private IEnumerator CheckKeyPressCoroutine()
    {
        Debug.Log("CheckKeyPressCoroutine: 開始");

        float holdTime = 0f; // 押し続けている時間のカウント
        //
        Vector3 currentScale = MaskImages.transform.localScale;
        KariMiss.SetActive(true);//仮ミスイメージ登場
        yield return new WaitForSeconds(waitTime);
        KariMiss.SetActive(false);
        DogezaImages.SetActive(true);
        //
        while (playerStates.isCollision)
        {
            // 両方が押されている間は時間を加算
            if (Input.GetKey(KeyCode.F) && Input.GetKey(KeyCode.J))
            {
                isSorry = true;
                holdTime += Time.deltaTime;
                currentScale.y += scaleSpeed * holdTime;
                if (holdTime >= 2f)
                {
                    playerStates.isCollision = false;
                    Debug.Log("成功：FとJを3秒間同時に押した");
                    DogezaImages.SetActive(false);
                    break;
                }
            }
            else
            {
                // どちらかが離されたらリセット
                isSorry = false;
                if (holdTime > 0f)
                {

                    Debug.Log("キーが離されたのでカウントリセット");
                }
                currentScale.y = originalYScale;
                holdTime = 0f;
            }
            MaskImages.transform.localScale = currentScale;
            yield return null;
        }
        isSorry = false;
        checkKeyCoroutine = null;
        Debug.Log("CheckKeyPressCoroutine: 終了");
    }

    private IEnumerator DelayedProcessCoroutine()
    {
        yield return new WaitForSeconds(60f);
        inFever = 1;

        yield return new WaitForSeconds(10f);
        inFever = 2;
    }
}
