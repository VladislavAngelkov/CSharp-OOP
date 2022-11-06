namespace MilitaryElite.Models.Interfaces
{
    using System.Collections.Generic;
    public interface ICommando : ISpecialisedSoldier
    {
        public List<Mission> Missions { get; }
    }
}
