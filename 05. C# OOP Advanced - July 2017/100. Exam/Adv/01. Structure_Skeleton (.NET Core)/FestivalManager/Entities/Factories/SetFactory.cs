namespace FestivalManager.Entities.Factories
{
    using Contracts;
    using Entities.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class SetFactory : ISetFactory
    {
        public ISet CreateSet(string name, string type)
        {
            Type[] currentAssembly = Assembly.GetCallingAssembly().GetTypes();
            Type currentType = currentAssembly.SingleOrDefault(t => t.Name == type);
            return (ISet)Activator.CreateInstance(currentType, name);

            //if (type == "Short")
            //{
            //    return new Short(name);
            //}
            //else if (type == "Medium")
            //{
            //    return new Medium(name);
            //}
            //else
            //{
            //    return new Long(name);
            //}
        }
    }
}