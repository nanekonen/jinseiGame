
using Unity.VisualScripting;

public class LoveInterest 
{
    public static readonly LoveInterest UNDEFINED_LOVE_INTEREST = new LoveInterest();

    public const int MAN = 0;
    public const int WOMAN = 1;
    public const int UNDEFINED = -1;

    private int gender = UNDEFINED;

    public LoveInterest( int gender )
    {
        this.gender = gender;
    }

    private LoveInterest()
    {
        this.gender = UNDEFINED;
    }

}