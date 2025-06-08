using UnityEngine;
using TMPro;

public class CollisionTextDisplay : MonoBehaviour
{
    public PlayerStates playerStates;               // 参照するプレイヤーステート
    public TextMeshProUGUI warningText;             // 表示/非表示するテキスト

    void Update()
    {
        if (playerStates != null && warningText != null)
        {
            // isCollision が true のとき表示、それ以外は非表示
            warningText.gameObject.SetActive(playerStates.isCollision);
        }
    }
}
