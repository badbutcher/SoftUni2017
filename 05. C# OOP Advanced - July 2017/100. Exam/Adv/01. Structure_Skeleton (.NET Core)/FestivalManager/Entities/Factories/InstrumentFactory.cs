namespace FestivalManager.Entities.Factories
{
    using Contracts;
    using Entities.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class InstrumentFactory : IInstrumentFactory
    {
        public IInstrument CreateInstrument(string type)
        {
            Type[] currentAssembly = Assembly.GetCallingAssembly().GetTypes();
            Type currentType = currentAssembly.SingleOrDefault(t => t.Name == type);
            return (IInstrument)Activator.CreateInstance(currentType);

            //if (type == "Drums")
            //{
            //    return new Drums();
            //}
            //else if (type == "Guitar")
            //{
            //    return new Guitar();
            //}
            //else
            //{
            //    return new Microphone();
            //}
        }
    }
}