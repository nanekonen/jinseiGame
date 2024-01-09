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
    public CanvasGroup canvas4;
    public CanvasGroup textCanvas1;
    public CanvasGroup textCanvas2;
    public CanvasGroup textCanvas3;
    public CanvasGroup textCanvas4;
    public CanvasGroup textCanvas5;
    private CanvasGroup[] canvases = new CanvasGroup[4];
    private CanvasGroup[] textCanvases = new CanvasGroup[5];

    // Start is called before the first frame update
    void Start()
    {
        clickCnt = 0;   
        canvases[0] = canvas1;
        canvases[1] = canvas2;
        canvases[2] = canvas3;
        canvases[3] = canvas4;
        textCanvases[0] = textCanvas1;
        textCanvases[1] = textCanvas2;
        textCanvases[2] = textCanvas3;
        textCanvases[3] = textCanvas4;
        textCanvases[4] = textCanvas5;
        for(int i=0; i<textCanvases.Length; i++)
        {
            if (i != 0)
            {
                textCanvases[i].alpha = 0;
            }
            else
            {
                textCanvases[i].alpha = 1;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(clickCnt);
            if(clickCnt < 4)
            {
                canvases[clickCnt].alpha = 0;
                if(clickCnt < 5)
                {
                    textCanvases[clickCnt].alpha = 0;
                    if (clickCnt + 1 < textCanvases.Length)
                    {
                        textCanvases[++clickCnt].alpha = 1;
                    }
                }
            }
            else
            {
                SceneManager.LoadScene("inputForm");
            }
            
        }
    }
}
