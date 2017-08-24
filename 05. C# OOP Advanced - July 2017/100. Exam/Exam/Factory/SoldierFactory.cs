using System;

public class SoldierFactory : ISoldierFactory
{
    public ISoldier CreateSoldier(string soldierTypeName, string name, int age, double experience, double endurance)
    {
        Type commandType = Type.GetType(soldierTypeName);
        var constructor = commandType.GetConstructor(new[] { typeof(string), typeof(int), typeof(double), typeof(double) });
        return (ISoldier)constructor.Invoke(new object[] { name, age, experience, endurance });
    }
}