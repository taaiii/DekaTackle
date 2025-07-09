using UnityEngine;

public class TutorialMoveL : MonoBehaviour
{
    public float moveSpeed = 1f; // •bŠÔˆÚ“®—Ê
    public const float DeletePos  = 0f;

    bool isMove = false;

    void Update()
    {
        if (isMove)
        {
            Vector3 move = Vector3.right * moveSpeed * Time.deltaTime;
            transform.position += move;
        }

        if (transform.position.x > DeletePos)
        {
            Destroy(gameObject);
        }
    }

    public void SetMove(bool move)
    {
        isMove = move;
    }
}
