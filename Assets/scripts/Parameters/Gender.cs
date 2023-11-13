
using Unity.VisualScripting;

public class Gender
{
    public static readonly Gender UNDEFINED_GENDER = new Gender(-1);
    public static readonly Gender MAN = new Gender(0);
    public static readonly Gender WOMAN = new Gender(1);

    private Gender gender = UNDEFINED_GENDER;

    public Gender( int gender )
    {
        switch(gender)
        {
            case -1:
                this.gender = UNDEFINED_GENDER;
                break;
            case 0:
                this.gender = MAN;
                break;
            case 1:
                this.gender = WOMAN;
                break;
        }
    }

    public Gender getGender()
    {
        return gender;
    }

}