using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrologueManager : MonoBehaviour
{
    private int clickCnt;
    public CanvasGroup canvas1;
    public CanvasGroup canvas2;
    public CanvasGroup canvas3;
    private CanvasGroup[] canvases = new CanvasGroup[3];

    // Start is called before the first frame update
    void Start()
    {
        clickCnt = 0;   
        canvases[0] = canvas1;
        canvases[1] = canvas2;
        canvases[2] = canvas3;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && ){
            canvases[clickCnt++].alpha = 0;
            
        }   
    }
}
