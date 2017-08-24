using System;
using System.Collections.Generic;

public class Army : IArmy
{
    public IReadOnlyList<ISoldier> Soldiers { get; private set; }

    public void AddSoldier(ISoldier soldier)
    {
        Soldiers = new List<ISoldier>();
    }

    public void RegenerateTeam(string soldierType)
    {
        Type type = Type.GetType(soldierType);
        foreach (var item in Soldiers)
        {
            item.Regenerate();
        }
    }
}