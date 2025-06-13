using UnityEngine;

public class TestmoveR : MonoBehaviour
{
    public float moveSpeedR = 1f; // •bŠÔˆÚ“®—Ê
    public const float DeletePos = 0f;

    void Update()
    {
        Vector3 move = Vector3.right * moveSpeedR * Time.deltaTime;
        transform.position -= move;

        if (transform.position.x < DeletePos)
        {
            Destroy(gameObject);
        }

    }
}
