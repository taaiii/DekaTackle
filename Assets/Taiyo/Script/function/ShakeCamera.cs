using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    public float shakeDuration = 0.5f;   // �h�炷����
    public float shakeMagnitude = 0.1f;  // �h��̑傫��

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
            shakeOffset.z = 0;  // 2D�Ȃ̂�Z���͓������Ȃ�
            transform.localPosition = originalPos + shakeOffset;

            currentShakeDuration -= Time.deltaTime;
        }
        else
        {
            currentShakeDuration = 0f;
            transform.localPosition = originalPos;
        }
    }

    // �h�炷�������O������Ăׂ�悤�ɂ���
    public void TriggerShake(float duration, float magnitude)
    {
        shakeDuration = duration;
        shakeMagnitude = magnitude;
        currentShakeDuration = shakeDuration;
    }
}
