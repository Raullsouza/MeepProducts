using MeepProducts.Models;

namespace MeepProducts.Interfaces
{
    public interface ILocalRepository
    {
        ICollection<Local> GetLocals();
    }
}
