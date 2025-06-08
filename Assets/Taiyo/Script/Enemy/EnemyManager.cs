using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //“GƒvƒŒƒnƒu
    public GameObject silentEnemyL;
    public GameObject silentEnemyR;

    public GameObject walkEnemyL;
    public GameObject walkEnemyR;

    public GameObject dushEnemyL;
    public GameObject dushEnemyR;

    public GameObject truckEnemyL;
    public GameObject truckEnemyR;

    public float spawnInterval = 5f;
    public float fiveSecondSpeedUpRange = 0.3f;

    private float timer;
    private float gameCount = 0;

    private int ramdomEnemyNum;    //“G‚Ìƒ‰ƒ“ƒ_ƒ€î•ñ‚ğ•Û‘¶ 
    private int isRightDirection; //•ûŒü‚Ìƒ‰ƒ“ƒ_ƒ€î•ñ‚ğ•Û‘¶

    //¶‰Eƒ‰ƒ“ƒ_ƒ€+“G‚Ìí—Şƒ‰ƒ“ƒ_ƒ€‚ÅInstabtiateŠÖ”‚ğg—p‚µ‚Ä“G‚ğoŒ»‚³‚¹‚Ä‚­‚¾‚³‚¢B
    //ã‚ªŠ®¬‚µ‚½‚çAˆê’èŠÔ‚Å“G‚ğì¬‚Å‚«‚é‚æ‚¤‚ÉBˆê’èŠÔ‚Í‚¾‚ñ‚¾‚ñ’Z‚­‚È‚è‚Ü‚·

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

        //‚T•b‚²‚Æ‚É0.3•b‘¬‚­
        if (gameCount > 5)
        {
            SpownSpeedUp();
            gameCount = 0;
        }

        if(timer > spawnInterval)
        {
            timer = 0f;

            //“G‚Æ•ûŒü‚ğƒ‰ƒ“ƒ_ƒ€‚Åİ’è
            ramdomEnemyNum = RamdomEnemy();
            isRightDirection = RandomDirection();

            //•Ï”‚É‚æ‚Á‚Äì‚é“G‚ğ•ÏX
            switch (ramdomEnemyNum)
            {
                case 0: CreateSilent(); break; //”E‚Ñ‘«
                case 1: CreateWalk();   break; //•à‚«
                case 2: CreateDush();   break; //‘–‚è@
            }

        }
    }

    int RamdomEnemy()
    {
        //  0 : ”E‚Ñ‘«, 1 : •à‚«, 2 : ‘–‚è
        return Random.Range(0, 3);
    }
    int RandomDirection()
    {
        // 0 : ¶, 1 : ‰E
        return Random.Range(0, 2);
    }
    void CreateSilent()
    {
        //‰E‘¤‚Éì¬
        if (isRightDirection == 0)
        {
            Debug.Log("”E‚Ñ‘« : ¶");
            Instantiate(silentEnemyL, new Vector3(-10f,0f,0f), Quaternion.identity);
        }
        //¶‘¤‚Éì¬
        else
        {
            Debug.Log("”E‚Ñ‘« : ‰E");
            Instantiate(silentEnemyR, new Vector3(10f, 0f, 0f), Quaternion.identity);
        }
    }
    void CreateWalk()
    {
        //‰E‘¤‚Éì¬
        if (isRightDirection == 0)
        {
            Debug.Log("•à‚« : ¶");
            Instantiate(silentEnemyL, new Vector3(-10f, 0f, 0f), Quaternion.identity);
        }
        //¶‘¤‚Éì¬
        else
        {
            Debug.Log("•à‚« : ‰E");
            Instantiate(silentEnemyR, new Vector3(10f, 0f, 0f), Quaternion.identity);
        }
    }
    void CreateDush()
    {
        //‰E‘¤‚Éì¬
        if (isRightDirection == 0)
        {
            Debug.Log("‘–‚è : ¶");
            Instantiate(silentEnemyL, new Vector3(-10f, 0f, 0f), Quaternion.identity);
        }
        //¶‘¤‚Éì¬
        else
        {
            Debug.Log("‘–‚è : ‰E");
            Instantiate(silentEnemyR, new Vector3(10f, 0f, 0f), Quaternion.identity);
        }

    }
    void SpownSpeedUp()
    {
        //0.3•b‘¬‚­
        spawnInterval -= fiveSecondSpeedUpRange;
    }
}
