using UnityEngine;
using TMPro; // TextMeshPro を使う場合
using static LockManager; // enum buttonlock を簡略に使えるようにする

public class StateTextDisplay : MonoBehaviour
{
    public TextMeshProUGUI stateText; // インスペクターでTextオブジェクトをアタッチ

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
