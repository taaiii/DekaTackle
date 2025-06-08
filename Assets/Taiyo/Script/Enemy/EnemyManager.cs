using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //敵プレハブ
    public GameObject silentEnemyL;
    public GameObject silentEnemyR;

    public GameObject walkEnemyL;
    public GameObject walkEnemyR;

    public GameObject dushEnemyL;
    public GameObject dushEnemyR;

    public GameObject truckEnemyL;
    public GameObject truckEnemyR;

    public float SpawnInterval = 5f;

    private float timer;
    private int ramdomEnemyNum;    //敵のランダム情報を保存 
    private int isRightDirection; //方向のランダム情報を保存

    //左右ランダム+敵の種類ランダムでInstabtiate関数を使用して敵を出現させてください。
    //上が完成したら、一定時間で敵を作成できるように。一定時間はだんだん短くなります

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > SpawnInterval)
        {
            timer = 0f;

            //敵と方向をランダムで設定
            ramdomEnemyNum = RamdomEnemy();
            isRightDirection = RandomDirection();

            //変数によって作る敵を変更
            switch (ramdomEnemyNum)
            {
                case 0: CreateSilent(); break; //忍び足
                case 1: CreateWalk();   break; //歩き
                case 2: CreateDush();   break; //走り　
            }

        }
    }

    int RamdomEnemy()
    {
        //  0 : 忍び足, 1 : 歩き, 2 : 走り
        return Random.Range(0, 3);
    }
    int RandomDirection()
    {
        // 0 : 左, 1 : 右
        return Random.Range(0, 2);
    }
    void CreateSilent()
    {
        //右側に作成
        if (isRightDirection == 0)
        {
            Debug.Log("忍び足 : 左");
            Instantiate(silentEnemyL, new Vector3(-10f,0f,0f), Quaternion.identity);
        }
        //左側に作成
        else
        {
            Debug.Log("忍び足 : 右");
            Instantiate(silentEnemyR, new Vector3(10f, 0f, 0f), Quaternion.identity);
        }
    }
    void CreateWalk()
    {
        //右側に作成
        if (isRightDirection == 0)
        {
            Debug.Log("歩き : 左");
            Instantiate(silentEnemyL, new Vector3(-10f, 0f, 0f), Quaternion.identity);
        }
        //左側に作成
        else
        {
            Debug.Log("歩き : 右");
            Instantiate(silentEnemyR, new Vector3(10f, 0f, 0f), Quaternion.identity);
        }
    }
    void CreateDush()
    {
        //右側に作成
        if (isRightDirection == 0)
        {
            Debug.Log("走り : 左");
            Instantiate(silentEnemyL, new Vector3(-10f, 0f, 0f), Quaternion.identity);
        }
        //左側に作成
        else
        {
            Debug.Log("走り : 右");
            Instantiate(silentEnemyR, new Vector3(10f, 0f, 0f), Quaternion.identity);
        }

    }
}
