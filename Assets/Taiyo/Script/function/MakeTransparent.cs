using UnityEngine;

public class MakeTransparent : MonoBehaviour
{
    void Start()
    {
        Material mat = GetComponent<Renderer>().material;
        Color c = mat.color;
        c.a = 0f;
        mat.color = c;
    }
}
