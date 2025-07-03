using UnityEngine;
using UnityEngine.UI;

public class FeverRawImage : MonoBehaviour
{
    [SerializeField] private RawImage rawImage;

    public float showDelay = 60f;
    public float displayDuration = 10f;

    void Awake()
    {
        if (rawImage == null)
        {
            rawImage = GameObject.Find("RawImageName")?.GetComponent<RawImage>();
            if (rawImage == null)
            {
                Debug.LogWarning("Awake��RawImage�擾���s");
            }
        }
    }
    void OnEnable()
    {
        if (rawImage == null)
        {
            Debug.LogWarning("rawImage ���ݒ肳��Ă��܂���I");
            return;
        }

        rawImage.enabled = false;
        StartCoroutine(ShowAndHideRawImage());
    }

    private System.Collections.IEnumerator ShowAndHideRawImage()
    {
        yield return new WaitForSeconds(showDelay);

        rawImage.enabled = true;
        Debug.Log("RawImage �\���I");

        yield return new WaitForSeconds(displayDuration);

        rawImage.enabled = false;
        Debug.Log("RawImage ��\���I");
    }
}
