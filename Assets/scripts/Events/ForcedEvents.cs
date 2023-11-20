using System.Collections.Generic;

public class ForcedEvents
{
    private List<ForcedEvent> fevents = new List<ForcedEvent>();
    private int eventIndex = 0;
    private Season season;
    private Round round;

    public ForcedEvents()
    {

    }
    public void add(ForcedEvent fe)
    {
        fe.added(eventFinish);
        fevents.Add(fe);
    }

    public void execute(in Season season, in Round round)
    {
        eventIndex = 0;
        this.season = season;
        this.round = round;
        if(eventIndex < fevents.Count)
        {
            fevents[eventIndex].execute(season, round);
        }
        else
        {
            GameMain.gameMain.turnStart();
        }
    }
    private void eventFinish()
    {
        eventIndex++;
        if(eventIndex < fevents.Count)
        {
            fevents[eventIndex].execute(season, round);
        }
        else
        {
            GameMain.gameMain.turnStart();
        }
    }
}