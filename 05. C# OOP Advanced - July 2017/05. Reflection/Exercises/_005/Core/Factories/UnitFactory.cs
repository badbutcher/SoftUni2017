namespace _03BarracksFactory.Core.Factories
{
    using Contracts;
    using System;

    public class UnitFactory : IUnitFactory
    {
        private const string UnitNameSpace = "_03BarracksFactory.Models.Units.";

        public IUnit CreateUnit(string unitType)
        {
            Type typeUnit = Type.GetType(UnitNameSpace + unitType);
            IUnit unitInstance = (IUnit)Activator.CreateInstance(typeUnit);
            return unitInstance;
        }
    }
}