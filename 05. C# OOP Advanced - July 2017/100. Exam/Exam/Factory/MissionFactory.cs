using System;

public class MissionFactory : IMissionFactory
{
    public IMission CreateMission(string difficultyLevel, double neededPoints)
    {
        Type commandType = Type.GetType(difficultyLevel);
        var constructor = commandType.GetConstructor(new[] { typeof(double) });
        return (IMission)constructor.Invoke(new object[] { neededPoints });
    }
}