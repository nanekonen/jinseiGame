using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSEPlayer : MonoBehaviour
{
    private AudioSource buttonSE;

    void Start()
    {
        buttonSE = GetComponent<AudioSource>();
    }

    public void OnClick()
    {
        buttonSE.PlayOneShot(buttonSE.clip);
    }

}