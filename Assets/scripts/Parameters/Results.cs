public struct Results
{
    public Deviation academicDev;
    public Deviation appearanceDev;
    public Deviation luckDev;
    public FavorabilityDeviation fav_dev; // Todo modify!!!!

    public Results
    (
        Deviation ac,
        Deviation ap,
        Deviation luck,
        FavorabilityDeviation f
    )
    {
        academicDev = ac;
        appearanceDev = ap; 
        luckDev = luck; 
        fav_dev = f;
    }
}