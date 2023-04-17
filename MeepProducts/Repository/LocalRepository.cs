using MeepProducts.Data;
using MeepProducts.Interfaces;
using MeepProducts.Models;
using Microsoft.EntityFrameworkCore;

namespace MeepProducts.Repository
{
    public class LocalRepository : ILocalRepository
    {
        private readonly DataContext _context;

        public LocalRepository(DataContext context) 
        {
            _context = context;
        }

        public Local GetLocal(int id)
        {
            return _context.Locais.Where(p => p.Id == id).FirstOrDefault();
        }

        public Local GetLocal(string name)
        {
            return _context.Locais.Where(p => p.Cidade == name).FirstOrDefault();
        }

        public ICollection<Local> GetLocals()
        {
            return _context.Locais.OrderBy(p => p.Id).ToList();

        }
        public ICollection<Portal> GetPortaisByLocal(int Localid)
        {
            return _context.Portais.Where(p => p.LocalId == Localid).ToList();
        }

        public bool LocalExists(int id)
        {
            return _context.Locais.Any(p => p.Id == id);
        }

        public bool ExistsByName(string name)
        {
            return _context.Locais.Any(p => p.Cidade == name);
        }

        public bool CreateLocal(Local local)
        {
            _context.Add(local);
            return Save();
        }

        public bool UpdateLocal(Local local)
        {
            _context.Update(local);
            return Save();
        }
        public bool DeleteLocal(Local local)
        {
            _context.Remove(local);
            return Save();
        }
        public bool Save()
        {
         var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

     
    }
}
 