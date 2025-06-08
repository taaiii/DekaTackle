using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //�G�v���n�u
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
    private int ramdomEnemyNum;    //�G�̃����_������ۑ� 
    private int isRightDirection; //�����̃����_������ۑ�

    //���E�����_��+�G�̎�ރ����_����Instabtiate�֐����g�p���ēG���o�������Ă��������B
    //�オ����������A��莞�ԂœG���쐬�ł���悤�ɁB��莞�Ԃ͂��񂾂�Z���Ȃ�܂�

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

            //�G�ƕ����������_���Őݒ�
            ramdomEnemyNum = RamdomEnemy();
            isRightDirection = RandomDirection();

            //�ϐ��ɂ���č��G��ύX
            switch (ramdomEnemyNum)
            {
                case 0: CreateSilent(); break; //�E�ё�
                case 1: CreateWalk();   break; //����
                case 2: CreateDush();   break; //����@
            }

        }
    }

    int RamdomEnemy()
    {
        //  0 : �E�ё�, 1 : ����, 2 : ����
        return Random.Range(0, 3);
    }
    int RandomDirection()
    {
        // 0 : ��, 1 : �E
        return Random.Range(0, 2);
    }
    void CreateSilent()
    {
        //�E���ɍ쐬
        if (isRightDirection == 0)
        {
            Debug.Log("�E�ё� : ��");
            Instantiate(silentEnemyL, new Vector3(-10f,0f,0f), Quaternion.identity);
        }
        //�����ɍ쐬
        else
        {
            Debug.Log("�E�ё� : �E");
            Instantiate(silentEnemyR, new Vector3(10f, 0f, 0f), Quaternion.identity);
        }
    }
    void CreateWalk()
    {
        //�E���ɍ쐬
        if (isRightDirection == 0)
        {
            Debug.Log("���� : ��");
            Instantiate(silentEnemyL, new Vector3(-10f, 0f, 0f), Quaternion.identity);
        }
        //�����ɍ쐬
        else
        {
            Debug.Log("���� : �E");
            Instantiate(silentEnemyR, new Vector3(10f, 0f, 0f), Quaternion.identity);
        }
    }
    void CreateDush()
    {
        //�E���ɍ쐬
        if (isRightDirection == 0)
        {
            Debug.Log("���� : ��");
            Instantiate(silentEnemyL, new Vector3(-10f, 0f, 0f), Quaternion.identity);
        }
        //�����ɍ쐬
        else
        {
            Debug.Log("���� : �E");
            Instantiate(silentEnemyR, new Vector3(10f, 0f, 0f), Quaternion.identity);
        }

    }
}
