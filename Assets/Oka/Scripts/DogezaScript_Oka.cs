using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogezaScript_Oka : MonoBehaviour
{
    public float scaleSpeed = 2f;               // �g��X�s�[�h

    private float originalYScale;
    public float maxsize;
    [SerializeField] private GameObject DogezaImages;

    void Start()
    {
        originalYScale = transform.localScale.y;
    }

    void Update()
    {
        Vector3 currentScale = transform.localScale;

        if (Input.GetKey(KeyCode.Q))
        {
            // �X�y�[�X�L�[��������Ă���Ԋg��
            currentScale.y += scaleSpeed * Time.deltaTime;
            if (currentScale.y > maxsize)
            {
                Debug.Log("�y��������");
                DogezaImages.SetActive(false);
            }

        }
        else
        {
            // �������u�ԁA���ɖ߂�
            currentScale.y = originalYScale;
        }

        transform.localScale = currentScale;
    }
}
