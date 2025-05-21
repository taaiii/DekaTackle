using UnityEngine;

public class TestmoveR : MonoBehaviour
{
    public float moveSpeed = 0.01f; 

    void Update()
    {
        Vector3 move = Vector3.zero;
        move.x -= moveSpeed;
        transform.position += move;
    }
}
