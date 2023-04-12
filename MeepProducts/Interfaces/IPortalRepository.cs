using MeepProducts.Models;

namespace MeepProducts.Interfaces
{
    public interface IPortalRepository
    {
        ICollection<Portal> GetPortals();
        Portal GetPortalById(int id);
        ICollection<Categoria> GetCategoriasByPortalId(int portalId);
        bool PortalExists(int id);

    }
}
