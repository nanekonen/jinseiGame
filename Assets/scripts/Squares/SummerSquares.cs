using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.AddressableAssets;
using TMPro;

public class SummerSquares : SeasonSquares
{
    private const string normalSquareCsvFilePath = @"Assets\Resources_moved\CSV\normal_squares\SpringNormalSquareData.csv";
    private readonly string[] activitySquareCsvFilePath = {
        @"Assets\Resources_moved\CSV\activity_squares\SpringBasketSquareData.csv",
        @"Assets\Resources_moved\CSV\activity_squares\SpringBrassBandSquareData.csv",
        @"Assets\Resources_moved\CSV\activity_squares\SpringPartTimeSquareData.csv"
        };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public  override List<Square> changeOfSquares(List<RealSquare> rsquares)
    {

        List<Square> squares = new List<Square>();
        List<string[]> normalSquareData = ReadCSVFile(normalSquareCsvFilePath);
        List<List<string[]>> activitySquareData = new List<List<string[]>>();
        activitySquareData.Add(ReadCSVFile(activitySquareCsvFilePath[0]));
        activitySquareData.Add(ReadCSVFile(activitySquareCsvFilePath[1]));
        activitySquareData.Add(ReadCSVFile(activitySquareCsvFilePath[2]));

        foreach(string[] squareData in normalSquareData){//通常マスの追加
            squares.Add(new NormalSquare(squareData[0],int.Parse(squareData[1]),int.Parse(squareData[2]),int.Parse(squareData[3])));
        }

        for(int i = 0; i < activitySquareData[0].Count; i++){//部活マスの追加
            List<string> sentence = new List<string>();
            List<int> academic = new List<int>();
            List<int> appearance = new List<int>();
            List<int> luck = new List<int>();
            List<int> favorability = new List<int>();
            foreach(List<string[]> dataByActivity in activitySquareData){
                sentence.Add(dataByActivity[i][0]);
                academic.Add(int.Parse(dataByActivity[i][1]));
                appearance.Add(int.Parse(dataByActivity[i][2]));
                luck.Add(int.Parse(dataByActivity[i][3]));
                favorability.Add(int.Parse(dataByActivity[i][4]));
            }
            squares.Add(new ActivitySquare(sentence,academic,appearance,luck,favorability));
        }
 
        return squares;
    }
}
