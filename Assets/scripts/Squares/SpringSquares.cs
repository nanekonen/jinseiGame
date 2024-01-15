using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.AddressableAssets;
using TMPro;

public class SpringSquares : SeasonSquares
{
    private const string normalSquareCsvFilePath = @"Assets/Resources_moved/CSV/normal_squares/Spring/NormalSquareData.csv";
    private readonly string[] loverSquareCsvFilePath = {
        @"Assets/Resources_moved/CSV/lover_squares/Spring/BasketSquareData.csv",
        @"Assets/Resources_moved/CSV/lover_squares/Spring/BrassBandSquareData.csv",
        @"Assets/Resources_moved/CSV/lover_squares/Spring/PartTimeSquareData.csv"
        };
    private const string partnerSquareCsvFilePath = @"Assets/Resources_moved/CSV/lover_squares/Spring/PartnerSquareData.csv";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public  override List<Square> changeOfSquares()
    {

        List<Square> squares = new List<Square>();

        List<string[]> normalSquareData = ReadCSVFile(normalSquareCsvFilePath);

        List<List<string[]>> loverSquareData = new List<List<string[]>>();
        loverSquareData.Add(ReadCSVFile(loverSquareCsvFilePath[0]));
        loverSquareData.Add(ReadCSVFile(loverSquareCsvFilePath[1]));
        loverSquareData.Add(ReadCSVFile(loverSquareCsvFilePath[2]));

        List<string[]> partnerSquareData = ReadCSVFile(partnerSquareCsvFilePath);

        for(int i = 0; i < 10; i++){
            //通常マスの追加
            squares.Add(new NormalSquare(normalSquareData[i][0], int.Parse(normalSquareData[i][1]), int.Parse(normalSquareData[i][2]), int.Parse(normalSquareData[i][3])));
            squares.Add(new NormalSquare(normalSquareData[i+10][0], int.Parse(normalSquareData[i+10][1]), int.Parse(normalSquareData[i+10][2]), int.Parse(normalSquareData[i+10][3])));

            List<string> sentence = new List<string>();
            List<int> favorability = new List<int>();
            List<string> nameOfLovers = new List<string>();
            string partnerSentence = partnerSquareData[i % (loverSquareData[0].Count/2)][0];
            int partnerFavorability = int.Parse(partnerSquareData[i % (loverSquareData[0].Count / 2)][1]);

            //部活マスの追加
            foreach (List<string[]> dataByActivity in loverSquareData){
                sentence.Add(dataByActivity[i][0]);
                favorability.Add(int.Parse(dataByActivity[i][1]));
                nameOfLovers.Add(dataByActivity[i][2]);
                nameOfLovers.Add(dataByActivity[i][3]);
            }

            squares.Add(new LoverSquare(sentence,favorability,nameOfLovers,partnerSentence,partnerFavorability));
        }
 
        return squares;
    }
}
