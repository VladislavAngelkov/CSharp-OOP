
namespace MilitaryElite.Models.Interfaces
{
    using System.Collections.Generic;
    public interface ILieutenantGeneral : IPrivate
    {
        public List<Private> Privates { get;}
    }
}
