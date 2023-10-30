using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    //hierarchy
    public Transform transform;

    //Status
    public string name;
    public int id;
    public bool sex;//true:man,false:woman
    public bool love_interest;//true:man,false:woman
    public int academic;
    public int apperance;
    public int luck;
    public List<int> favorability = new List<int>();
    public int lover;
    public int activity;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void proceed(int number)
    {
        Map.map.positions[id] = (Map.map.positions[id] + number)%Map.map.positions.Count;
        //âÊñ è„Ç…îΩâf

        Map.map.getSquare(Map.map.positions[id]).execution(this);
    }
}
