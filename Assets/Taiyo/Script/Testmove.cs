using UnityEngine;

public class Testmove : MonoBehaviour
{
    public float moveSpeed = 0.02f; // –ˆƒtƒŒ[ƒ€‚ÌˆÚ“®—Ê

    void Update()
    {
        Vector3 move = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
        {
            move.x -= moveSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            move.x += moveSpeed;
        }

        transform.position += move;
    }
}
