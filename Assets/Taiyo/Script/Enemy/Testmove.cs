using UnityEngine;

public class Testmove : MonoBehaviour
{
    public float moveSpeed = 1f; // �b�Ԉړ���

    void Update()
    {
        Vector3 move = Vector3.right * moveSpeed * Time.deltaTime;
        transform.position += move;
    }
}
