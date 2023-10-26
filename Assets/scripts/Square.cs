using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Square : MonoBehaviour
{

    public static Square generateInstance(string name, List<Object> argument)
    {
        
    }

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void execution();

    public abstract void inicialization(List<Object>argument);
}