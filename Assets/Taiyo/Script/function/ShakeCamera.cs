using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    public float shakeDuration = 0.5f;   // 揺らす時間
    public float shakeMagnitude = 0.1f;  // 揺れの大きさ

    private Vector3 originalPos;
    private float currentShakeDuration = 0f;

    void Start()
    {
        originalPos = transform.localPosition;
    }

    void Update()
    {
        if (currentShakeDuration > 0)
        {
            Vector3 shakeOffset = Random.insideUnitSphere * shakeMagnitude;
            shakeOffset.z = 0;  // 2DなのでZ軸は動かさない
            transform.localPosition = originalPos + shakeOffset;

            currentShakeDuration -= Time.deltaTime;
        }
        else
        {
            currentShakeDuration = 0f;
            transform.localPosition = originalPos;
        }
    }

    // 揺らす処理を外部から呼べるようにする
    public void TriggerShake(float duration, float magnitude)
    {
        shakeDuration = duration;
        shakeMagnitude = magnitude;
        currentShakeDuration = shakeDuration;
    }
}
