using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogezaStart_Oka : MonoBehaviour
{
    [SerializeField] private GameObject KariMiss;
    [SerializeField] private GameObject DogezaImages;
    public float waitTime;
    public void OnClickButton()
    {
        StartCoroutine("ChangeDogeza");
    }
    IEnumerator ChangeDogeza()
    {
        KariMiss.SetActive(true);

        yield return new WaitForSeconds(waitTime);
        KariMiss.SetActive(false);
        DogezaImages.SetActive(true);
    }
}
