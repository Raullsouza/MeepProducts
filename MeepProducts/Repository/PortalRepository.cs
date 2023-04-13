using MeepProducts.Data;
using MeepProducts.Interfaces;
using MeepProducts.Models;

namespace MeepProducts.Repository
{
    public class PortalRepository : IPortalRepository
    {
        private readonly DataContext _context;

        public PortalRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Portal> GetPortals()
        {
            return _context.Portais.OrderBy(c => c.PortalId).ToList(); 
        }

        public Portal GetPortalById(int id)
        {
            return _context.Portais.Where(p => p.PortalId == id).FirstOrDefault();
        }

        public ICollection<Categoria> GetCategoriasByPortalId(int portalId)
        {
           return  _context.Categorias.Where(p => p.PortalId == portalId).ToList(); 
        }
     
        public bool PortalExists(int id)
        {
            return _context.Portais.Any(p => p.PortalId == id);
        }

        public Portal GetPortalByName(string name)
        {
            return _context.Portais.Where(p => p.Nome == name).FirstOrDefault();
        }

        public bool PortalExistsByName(string name)
        {
            return _context.Portais.Any(p => p.Nome == name);
        }
    }
}
