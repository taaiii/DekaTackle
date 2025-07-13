using UnityEngine;

public class LockManager : MonoBehaviour
{
    public enum buttonlock
    {
        LOCK,
        OPEN,
    }

    // 他のスクリプトからアクセス可能なロック状態
    public static buttonlock state = buttonlock.LOCK;

    private void Start()
    {
        state = buttonlock.LOCK;
    }
    void Update()
    {
        // oキーでロック解除
        if (Input.GetKeyDown("o"))
        {
            state = buttonlock.OPEN;
            Debug.Log("状態が OPEN になりました");
        }
    }
}
