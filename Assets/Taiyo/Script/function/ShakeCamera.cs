using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    public float shakeDuration = 0.5f;   // —h‚ç‚·ŠÔ
    public float shakeMagnitude = 0.1f;  // —h‚ê‚Ì‘å‚«‚³

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
            shakeOffset.z = 0;  // 2D‚È‚Ì‚ÅZ²‚Í“®‚©‚³‚È‚¢
            transform.localPosition = originalPos + shakeOffset;

            currentShakeDuration -= Time.deltaTime;
        }
        else
        {
            currentShakeDuration = 0f;
            transform.localPosition = originalPos;
        }
    }

    // —h‚ç‚·ˆ—‚ğŠO•”‚©‚çŒÄ‚×‚é‚æ‚¤‚É‚·‚é
    public void TriggerShake(float duration, float magnitude)
    {
        shakeDuration = duration;
        shakeMagnitude = magnitude;
        currentShakeDuration = shakeDuration;
    }
}
