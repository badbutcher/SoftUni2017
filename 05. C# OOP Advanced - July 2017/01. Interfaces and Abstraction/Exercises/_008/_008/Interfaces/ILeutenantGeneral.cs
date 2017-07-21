namespace _008.Interfaces
{
    using System.Collections.Generic;

    public interface ILeutenantGeneral : IPrivate
    {
        IList<ISoldier> Soldiers { get; }
    }
}