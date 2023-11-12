
using Unity.VisualScripting;

public class Gender
{
    public static readonly Gender UNDEFINED_GENDER = new Gender();

    public const int MAN = 0;
    public const int WOMAN = 1;
    public const int UNDEFINED = -1;

    private int gender = UNDEFINED;

    public Gender( int gender )
    {
        this.gender = gender;
    }

    private Gender()
    {
        this.gender = UNDEFINED;
    }

}