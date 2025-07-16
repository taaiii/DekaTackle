using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playlight : MonoBehaviour
{
    public AudioSource audioSource;     // Inspector �Őݒ肷�邩�AStart �Ŏ擾
    public AudioClip clipToPlay;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.Play();
    }
}
