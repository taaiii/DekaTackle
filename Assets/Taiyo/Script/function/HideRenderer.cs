using UnityEngine;

public class HideRenderer : MonoBehaviour
{
    void Start()
    {
        // 起動時にRendererを無効化
        GetComponent<Renderer>().enabled = false;
    }
}
