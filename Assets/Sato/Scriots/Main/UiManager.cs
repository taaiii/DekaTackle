using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    //UIŠÖ˜A‚ð“ü‚ê‚Ä‚ ‚é(Time,Score)
    public GameObject[] UIes;

    private void Update()
    {
        foreach(GameObject ui in UIes)
        {
            if(DrawUiObserver.Instance.GetIsView())
            {
                ui.SetActive(true);
            }
            else
            {
                ui.SetActive(false);
            }
        }
    }
}
