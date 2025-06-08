using UnityEngine;
using TMPro;

public class CollisionTextDisplay : MonoBehaviour
{
    public PlayerStates playerStates;               // �Q�Ƃ���v���C���[�X�e�[�g
    public TextMeshProUGUI warningText;             // �\��/��\������e�L�X�g

    void Update()
    {
        if (playerStates != null && warningText != null)
        {
            // isCollision �� true �̂Ƃ��\���A����ȊO�͔�\��
            warningText.gameObject.SetActive(playerStates.isCollision);
        }
    }
}
