using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public static KeyManager keyManager;

    public delegate void DownSpace();
    private List<DownSpace> downSpace = new List<DownSpace>();
    private bool downSpaceBool = false;

    public delegate void DownUpArrow();
    private List<DownUpArrow> downUpArrow = new List<DownUpArrow>();
    private bool downUpArrowBool = false;

    public delegate void DownDownArrow();
    private List<DownDownArrow> downDownArrow = new List<DownDownArrow>();
    private bool downDownArrowBool = false;

    private void Awake()
    {
        keyManager = this;
    }
    // Update is called once per frame
    void Update()
    {
        if (downSpaceBool && Input.GetKeyDown(KeyCode.Space))
        {
            downSpaceBool = downSpace.Count == 1 ? false:true ;
            downSpace[0]();
            downSpace.Remove(downSpace[0]);
        }
        if (downUpArrowBool && Input.GetKeyDown(KeyCode.UpArrow))
        {
            downUpArrowBool = downUpArrow.Count == 1?false:true;
            downUpArrow[0]();
            downUpArrow.Remove(downUpArrow[0]);
        }
        if (downDownArrowBool && Input.GetKeyDown(KeyCode.DownArrow))
        {
            downDownArrowBool = downDownArrow.Count == 1?false:true;
            downDownArrow[0]();
            downDownArrow.Remove(downDownArrow[0]);
        }
    }

    public void setDownSpace(DownSpace ds)
    {
        downSpace.Add(ds);
        downSpaceBool = true;
    }
    public void setDownUpArrow(DownUpArrow dua)
    {
        downUpArrow.Add(dua);
        downUpArrowBool = true;
    }
    public void setDownDownArrow(DownDownArrow dda)
    {
        downDownArrow.Add(dda);
        downDownArrowBool = true;
    }
}
