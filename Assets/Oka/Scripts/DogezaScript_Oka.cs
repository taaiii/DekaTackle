using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogezaScript_Oka : MonoBehaviour
{
    public float scaleSpeed = 2f;               // 拡大スピード

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
            // スペースキーが押されている間拡大
            currentScale.y += scaleSpeed * Time.deltaTime;
            if (currentScale.y > maxsize)
            {
                Debug.Log("土下座成功");
                DogezaImages.SetActive(false);
            }

        }
        else
        {
            // 離した瞬間、元に戻す
            currentScale.y = originalYScale;
        }

        transform.localScale = currentScale;
    }
}
