using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSEPlayer : MonoBehaviour
{
    //hornsoundは任意の名前でOKです、それ以外は変えないでください。
    private AudioSource buttonSE;

    void Start()
    {
        buttonSE = GetComponent<AudioSource>();
    }
    //ボタンをクリックした時のスクリプトです。
    public void OnClick()
    {
        buttonSE.PlayOneShot(buttonSE.clip);
    }

}