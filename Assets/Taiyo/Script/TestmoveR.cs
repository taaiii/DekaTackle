using UnityEngine;

public class TestmoveR : MonoBehaviour
{
    public float moveSpeedR = 1f; // �b�Ԉړ���

    void Update()
    {
        Vector3 move = Vector3.right * moveSpeedR * Time.deltaTime;
        transform.position -= move;
    }
}
