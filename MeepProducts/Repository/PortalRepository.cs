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
            return _context.Portais.OrderBy(c => c.Id).ToList(); 
        }

        public Portal GetPortalById(int id)
        {
            return _context.Portais.Where(p => p.Id == id).FirstOrDefault();
        }

        public ICollection<Categoria> GetCategoriasByPortalId(int portalId)
        {
           return  _context.Categorias.Where(p => p.Id == portalId).ToList(); 
        }
     
        public bool PortalExists(int id)
        {
            return _context.Portais.Any(p => p.Id == id);
        }

        public Portal GetPortalByName(string name)
        {
            return _context.Portais.Where(p => p.Nome == name).FirstOrDefault();
        }

        public bool PortalExistsByName(string name)
        {
            return _context.Portais.Any(p => p.Nome == name);
        }

        public bool CreatePortal(Portal portal)
        {
            _context.Add(portal);
            return Save();
        }
        public bool UpdatePortal(Portal portal)
        {
            _context.Update(portal);
            return Save();
        }
        public bool DeletePortal(Portal portal)
        {
            _context.Remove(portal);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

      
    }
}
