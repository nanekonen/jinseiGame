using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSEPlayer : MonoBehaviour
{
    //hornsound�͔C�ӂ̖��O��OK�ł��A����ȊO�͕ς��Ȃ��ł��������B
    private AudioSource buttonSE;

    void Start()
    {
        buttonSE = GetComponent<AudioSource>();
    }
    //�{�^�����N���b�N�������̃X�N���v�g�ł��B
    public void OnClick()
    {
        buttonSE.PlayOneShot(buttonSE.clip);
    }

}