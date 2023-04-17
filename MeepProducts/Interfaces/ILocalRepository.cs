using MeepProducts.Models;

namespace MeepProducts.Interfaces
{
    public interface ILocalRepository
    {
        ICollection<Local> GetLocals();
        Local GetLocal(int id);
        Local GetLocal(string name);
        ICollection<Portal> GetPortaisByLocal(int Localid);
        bool LocalExists(int id);
        bool ExistsByName(string name);
        bool CreateLocal(Local local);
        bool UpdateLocal(Local local);  
        bool DeleteLocal(Local local);
        bool Save();
    }
}
