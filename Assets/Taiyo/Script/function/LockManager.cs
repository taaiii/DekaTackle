using UnityEngine;

public class LockManager : MonoBehaviour
{
    public enum buttonlock
    {
        LOCK,
        OPEN,
    }

    // ���̃X�N���v�g����A�N�Z�X�\�ȃ��b�N���
    public static buttonlock state = buttonlock.LOCK;

    private void Start()
    {
        state = buttonlock.LOCK;
    }
    void Update()
    {
        // o�L�[�Ń��b�N����
        if (Input.GetKeyDown("o"))
        {
            state = buttonlock.OPEN;
            Debug.Log("��Ԃ� OPEN �ɂȂ�܂���");
        }
    }
}
