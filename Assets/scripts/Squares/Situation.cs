using Cysharp.Threading.Tasks;

public struct Situation
{
    public Season season;
    public int squareNumber;
    public int squareType;

    public Situation
    (
        Season season,
        int squareNumber,
        int squareType
    )
    {
        this.season = season;
        this.squareNumber = squareNumber;
        this.squareType = squareType;
    }
}