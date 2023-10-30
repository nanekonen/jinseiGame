using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class SeasonSquares : MonoBehaviour
{
    public abstract List<Square> changeOfSquares(List<SpriteRenderer>sprites,List<TextMeshPro>texts);
}
