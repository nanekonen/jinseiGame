using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareManager : MonoBehaviour
{
    public List<Square> squareList = new List<Square>();

    private Dictionary<string, Square> squareDictionary = new Dictionary<string, Square>();
    // Start is called before the first frame update
    void Start()
    {
        foreach(Square s in squareList)
        {
            squareDictionary.Add(s.name, s);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Square generateSprite(string name, Dictionary<string,Object> argument)
    {
        Square s = squareDictionary[name];
        return CopyHelper.DeepCopy(s);
    }
}
