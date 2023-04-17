using MeepProducts.Models;

namespace MeepProducts.Interfaces
{
    public interface IPortalRepository
    {
        ICollection<Portal> GetPortals();
        Portal GetPortalById(int id);
        Portal GetPortalByName(string name);
        ICollection<Categoria> GetCategoriasByPortalId(int portalId);
        bool PortalExists(int id);
        bool PortalExistsByName(string name);
        bool CreatePortal (Portal portal);
        bool UpdatePortal (Portal portal); 
        bool DeletePortal (Portal portal);
        bool Save();
    }
}
