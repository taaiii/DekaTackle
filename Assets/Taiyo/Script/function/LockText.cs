using UnityEngine;
using TMPro; // TextMeshPro ���g���ꍇ
using static LockManager; // enum buttonlock ���ȗ��Ɏg����悤�ɂ���

public class StateTextDisplay : MonoBehaviour
{
    public TextMeshProUGUI stateText; // �C���X�y�N�^�[��Text�I�u�W�F�N�g���A�^�b�`

    void Update()
    {
        switch (LockManager.state)
        {
            case buttonlock.LOCK:
                stateText.text = "LOCK";
                break;
            case buttonlock.OPEN:
                stateText.text = "OPEN";
                break;
        }
    }
}
