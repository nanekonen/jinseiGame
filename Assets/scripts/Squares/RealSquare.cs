using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RealSquare : MonoBehaviour
{
    public SpriteRenderer sr;
    public TextMeshPro text;
    public Square square;

    public void change(Square square)
    {
        square.sr = sr;
        square.text = text;
        square.changeImage();
        this.square = square;
    }
}
