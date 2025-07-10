using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class SetSortingLayer : MonoBehaviour
{
    public string sortingLayerName = "Default";
    public int orderInLayer = 0;

    void Start()
    {
        var renderer = GetComponent<Renderer>();
        renderer.sortingLayerName = sortingLayerName;
        renderer.sortingOrder = orderInLayer;
    }
}
