using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEnemyManager : MonoBehaviour
{
    //敵プレハブ

    public GameObject walkEnemyL;
    public GameObject walkEnemyR;

    public float spawnInterval = 5f;
    public float fiveSecondSpeedUpRange = 0.3f;

    private float timer;
    private float gameCount = 0;

    private int ramdomEnemyNum = 0;    //敵のランダム情報を保存 
    private int isRightDirection; //方向のランダム情報を保存

    //左右ランダム+敵の種類ランダムでInstabtiate関数を使用して敵を出現させてください。
    //上が完成したら、一定時間で敵を作成できるように。一定時間はだんだん短くなります

    // Start is called before the first frame update
    void Start()
    {
        timer = 5f;
        gameCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        gameCount += Time.deltaTime;

        //５秒ごとに0.3秒速く
        if (gameCount > 5)
        {
            gameCount = 0;
        }

        if (timer > spawnInterval)
        {
            timer = 0f;

            //敵と方向を設定
            ramdomEnemyNum = 2;
            isRightDirection = RandomDirection();

             CreateWalk(); //歩き
        }
    }

    public void SpawnState1()
    {
        ramdomEnemyNum = 2;
        isRightDirection = 1;

        CreateWalk(); //歩き
    }

    int RandomDirection()
    {
        // 0 : 左, 1 : 右
        return Random.Range(0, 2);
    }
    void CreateWalk()
    {
        //右側に作成
        if (isRightDirection == 0)
        {
            Debug.Log("歩き : 左");
            Instantiate(walkEnemyL, new Vector3(-10f, 0f, 0f), Quaternion.identity);
        }
        //左側に作成
        else
        {
            Debug.Log("歩き : 右");
            Instantiate(walkEnemyR, new Vector3(10f, 0f, 0f), Quaternion.identity);
        }
    }
}
