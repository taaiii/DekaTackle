using UnityEngine;

public class TutorialMoveR : MonoBehaviour
{
    public float moveSpeedR = 1f; // •bŠÔˆÚ“®—Ê
    public const float DeletePos = 0f;

    bool isMove = false;

    void Update()
    {
        if (isMove)
        {
            Vector3 move = Vector3.left * moveSpeedR * Time.deltaTime;
            transform.position += move;

            if (transform.position.x < DeletePos)
            {
                Destroy(gameObject);
            }
        }
    }

    public void SetMove(bool move)
    {
        isMove = move;
    }
}
