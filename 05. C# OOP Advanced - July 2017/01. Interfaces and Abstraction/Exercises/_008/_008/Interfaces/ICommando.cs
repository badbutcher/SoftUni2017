namespace _008.Interfaces
{
    using System.Collections.Generic;

    public interface ICommando : ISpecialisedSoldier
    {
        IList<IMissions> Missions { get; }

        void CompleteMission();
    }
}