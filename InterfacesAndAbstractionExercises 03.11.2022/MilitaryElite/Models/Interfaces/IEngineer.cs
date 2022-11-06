namespace MilitaryElite.Models.Interfaces
{
    using System.Collections.Generic;
    public interface IEngineer : ISpecialisedSoldier
    {
        public List<Repair> Repairs { get; }
    }
}
