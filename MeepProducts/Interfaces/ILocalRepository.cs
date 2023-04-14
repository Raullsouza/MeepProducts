﻿using MeepProducts.Models;

namespace MeepProducts.Interfaces
{
    public interface ILocalRepository
    {
        ICollection<Local> GetLocals();
        Local GetLocal(int id);
        Local GetLocal(string name);
        bool LocalExists(int id);
        bool ExistsByName(string name);
        bool createLocal(Local local);
        bool save();
    }
}
