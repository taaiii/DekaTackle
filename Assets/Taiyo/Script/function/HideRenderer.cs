using UnityEngine;

public class HideRenderer : MonoBehaviour
{
    void Start()
    {
        // �N������Renderer�𖳌���
        GetComponent<Renderer>().enabled = false;
    }
}
