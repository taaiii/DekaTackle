using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEnemyManager : MonoBehaviour
{
    //�G�v���n�u

    public GameObject walkEnemyL;
    public GameObject walkEnemyR;

    public float spawnInterval = 5f;
    public float fiveSecondSpeedUpRange = 0.3f;

    private float timer;
    private float gameCount = 0;

    private int ramdomEnemyNum = 0;    //�G�̃����_������ۑ� 
    private int isRightDirection; //�����̃����_������ۑ�

    //���E�����_��+�G�̎�ރ����_����Instabtiate�֐����g�p���ēG���o�������Ă��������B
    //�オ����������A��莞�ԂœG���쐬�ł���悤�ɁB��莞�Ԃ͂��񂾂�Z���Ȃ�܂�

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

        //�T�b���Ƃ�0.3�b����
        if (gameCount > 5)
        {
            gameCount = 0;
        }

        if (timer > spawnInterval)
        {
            timer = 0f;

            //�G�ƕ�����ݒ�
            ramdomEnemyNum = 2;
            isRightDirection = RandomDirection();

             CreateWalk(); //����
        }
    }

    public void SpawnState1()
    {
        ramdomEnemyNum = 2;
        isRightDirection = 1;

        CreateWalk(); //����
    }

    int RandomDirection()
    {
        // 0 : ��, 1 : �E
        return Random.Range(0, 2);
    }
    void CreateWalk()
    {
        //�E���ɍ쐬
        if (isRightDirection == 0)
        {
            Debug.Log("���� : ��");
            Instantiate(walkEnemyL, new Vector3(-10f, 0f, 0f), Quaternion.identity);
        }
        //�����ɍ쐬
        else
        {
            Debug.Log("���� : �E");
            Instantiate(walkEnemyR, new Vector3(10f, 0f, 0f), Quaternion.identity);
        }
    }
}
