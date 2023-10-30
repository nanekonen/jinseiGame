using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RealSquare : MonoBehaviour
{
    private static List<SpriteRenderer> srList = new List<SpriteRenderer>();
    private static List<TextMeshPro> textList = new List<TextMeshPro>();

    public SpriteRenderer sr;
    public TextMeshPro text;
    // Start is called before the first frame update
    private void Awake()
    {
        srList.Add(sr);
        textList.Add(text);
    }

    public static List<SpriteRenderer> getSpriteRenderer()
    {
        return srList;
    }

    public static List<TextMeshPro> getTextMeshPro()
    {
        return textList;
    }
}
