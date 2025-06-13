using UnityEngine;

public class Testmove : MonoBehaviour
{
    public float moveSpeed = 1f; // •bŠÔˆÚ“®—Ê
    public const float DeletePos  = 0f;

    void Update()
    {
        Vector3 move = Vector3.right * moveSpeed * Time.deltaTime;
        transform.position += move;

        if(transform.position.x > DeletePos)
        {
            Destroy(gameObject);
        }
    }
}
