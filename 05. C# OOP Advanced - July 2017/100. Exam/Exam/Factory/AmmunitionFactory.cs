using System;

public class AmmunitionFactory : IAmmunitionFactory
{
    public IAmmunition CreateAmmunition(string name)
    {
        Type commandType = Type.GetType(name);
        var constructor = commandType.GetConstructor(new[] { typeof(string) });
        return (IAmmunition)constructor.Invoke(new object[] { name });
    }
}