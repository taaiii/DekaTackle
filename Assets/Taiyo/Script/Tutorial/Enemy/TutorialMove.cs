using UnityEngine;

public class TutorialMove : MonoBehaviour
{
    public float moveSpeed = 1f; // •bŠÔˆÚ“®—Ê
    public const float DeletePos  = 0f;

    public bool isMove = true;

    void Update()
    {
        if(isMove)
        {
            Vector3 move = Vector3.right * moveSpeed * Time.deltaTime;
            transform.position += move;
        }

        if (transform.position.x > DeletePos)
        {
            Destroy(gameObject);
        }
    }

   public void SetIsMove(bool move)
    {
        isMove = move;
    }
}
