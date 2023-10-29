using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    //hierarchy
    public Transform transform;

    //Status
    public string name;
    public bool sex;//true:man,false:woman
    public bool love_interest;//true:man,false:woman
    public int academic;
    public int apperance;
    public int luck;
    public Dictionary<string, int> favorability = new Dictionary<string, int>();

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void proceed(int number)
    {
        Map.map.positions[name] = (Map.map.positions[name] + number)%Map.map.positions.Count;
        //âÊñ è„Ç…îΩâf

        Map.map.nowSquare[Map.map.positions[name]].execution(this);
    }
}
