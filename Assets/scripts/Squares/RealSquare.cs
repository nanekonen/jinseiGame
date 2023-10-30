using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RealSquare : MonoBehaviour
{
    public static List<SpriteRenderer> srList = new List<SpriteRenderer>();
    public static List<TextMeshPro> textList = new List<TextMeshPro>();

    public SpriteRenderer sr;
    public TextMeshPro text;
    // Start is called before the first frame update
    private void Awake()
    {
        Map.map.rsquares.Add(this);
        srList.Add(sr);
        textList.Add(text);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
