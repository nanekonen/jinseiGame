using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using System.IO;

public abstract class SeasonSquares
{
    public abstract List<Square> changeOfSquares(List<RealSquare>rsquares);

    public List<string[]> ReadCSVFile(string csvFilePath)
    {
        List<string[]> csvData = new List<string[]>();
        // CSVファイルが存在するか確認
        if (File.Exists(csvFilePath))
        {
            // CSVファイルを読み込む
            string[] lines = File.ReadAllLines(csvFilePath);
            foreach (string line in lines)
            {
                csvData.Add(line.Split(","));
            }
        }
        else
        {
            Debug.LogError("CSVファイルが見つかりません: " + csvFilePath);
        }
        return csvData;
    }
}

