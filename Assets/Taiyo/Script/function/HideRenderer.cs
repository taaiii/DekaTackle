using UnityEngine;

public class HideRenderer : MonoBehaviour
{
    void Start()
    {
        // ‹N“®Žž‚ÉRenderer‚ð–³Œø‰»
        GetComponent<Renderer>().enabled = false;
    }
}
