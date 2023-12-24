using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public static KeyManager keyManager;

    public delegate void KeyCallback();

    private KeyCallback space = KeyManager.empty;
    private bool isSpaceCallbackReserved = false;

    private KeyCallback upArrow = KeyManager.empty;
    private bool isUpArrowCallbackReserved = false;

    private KeyCallback downArrow = KeyManager.empty;
    private bool isDownArrowCallbackReserved = false;

    private void Awake()
    {
        keyManager = this;
    }
    // Update is called once per frame
    void Update()
    {
        if (isSpaceCallbackReserved && Input.GetKeyDown(KeyCode.Space))
        {
            isSpaceCallbackReserved = false;
            space();
            //space = KeyManager.empty;
        }

        if (isUpArrowCallbackReserved && Input.GetKeyDown(KeyCode.UpArrow))
        {
            isUpArrowCallbackReserved = false;
            upArrow();
            upArrow = KeyManager.empty;
        }

        if (isDownArrowCallbackReserved && Input.GetKeyDown(KeyCode.DownArrow))
        {
            isDownArrowCallbackReserved = false;
            downArrow();
            downArrow = KeyManager.empty;
        }
    }

    public bool setSpaceCallback(KeyCallback ds)
    {
        bool success = false; 
        if( isSpaceCallbackReserved )
        {
            success = false;
            return success;
        }
        else
        {
            space = ds;
            isSpaceCallbackReserved = true;

            success = true;

            return success;
        }

    }
    public IEnumerator waitFor1Or2Or3()
    {
        int num  = 1;
        while( true )
        {
            if( Input.GetKeyDown(KeyCode.Alpha1) )
            {
                num = 1;
                break;
            }

            if( Input.GetKeyDown(KeyCode.Alpha2 ) )
            {
                num = 2;
                break;
            }

            if( Input.GetKeyDown(KeyCode.Alpha3 ) )
            {
                num = 3;
                break;
            }
            yield return null;
        }

        yield return num;
    }
    public IEnumerator waitForAOrB()
    {
        bool A = true;
        while( true )
        {
            if( Input.GetKeyDown(KeyCode.B))
            {
                A = false;
                break;
            }

            if( Input.GetKeyDown(KeyCode.A))
            {
                A = true;
                break;
            }
            yield return null;
        }

        string text = "";
            
        if( A )
        {
            text = "A";
        }
        else
        {
            text = "B"; 
        }

        yield return text;
    }
    public IEnumerator waitForRightOrLeftArrow()
    {
        bool left = true;
        while( true )
        {
            if( Input.GetKeyDown(KeyCode.RightArrow))
            {
                left = false;
                break;
            }

            if( Input.GetKeyDown(KeyCode.LeftArrow))
            {
                left = true;
                break;
            }
            yield return null;
        }

        string text = "";
            
        if( left )
        {
            text = "left";
        }
        else
        {
            text = "right"; 
        }

        yield return text;
    }
    public IEnumerator waitForSpace()
    {
        bool done = false;
        while(!done)
        {
            if( Input.GetKeyDown(KeyCode.Space))
            {
                done = true;
            }
            yield return null;
        }
    }
    public bool setUpArrowCallback(KeyCallback dua)
    {
        bool success = false; 
        if( isUpArrowCallbackReserved )
        {
            success = false;
            return success;
        }
        else
        {
            upArrow = dua;
            isUpArrowCallbackReserved = true;

            success = true;

            return success;
        }
    }
    public bool setDownArrowCallback(KeyCallback dda)
    {
        bool success = false; 
        if( isDownArrowCallbackReserved )
        {
            success = false;
            return success;
        }
        else
        {
            downArrow = dda;
            isDownArrowCallbackReserved = true;

            success = true;

            return success;
        }
    }

    private static void empty()
    { 

    }


}
