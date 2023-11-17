using System.Collections.Generic;

public class ForcedEvents
{
    private List<ForcedEvent> fevents = new List<ForcedEvent>();

    public ForcedEvents()
    {

    }

    public void execute(in Season season, in Round round)
    {
        foreach(ForcedEvent fe in fevents)
        {
            fe.execution(season, round);
        }

    }
}