using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareManager : MonoBehaviour
{
    public List<Square> list = new List<Square>();
    private Dictionary<string, int> ind = new Dictionary<string, int>();
    public static SquareManager sm;
    private void Awake()
    {
        sm = this;
        Debug.Log("SquareManager");
        for(int i = 0;i < list.Count; i++)
        {
            //ind.Add(list[i].name, i);Debug.Log("name:"+list[i].name);
        }
    }
    // Start is called before the first frame updateValue
    public Square getSquare(string name)
    {
        if (ind.ContainsKey(name))
        {
           // Square s = Instantiate(list[ind[name]],Vector3.zero,Quaternion.identity);
            //s.transform.SetParent(transform);
            //return s;
        }
        return null;
    }
}
