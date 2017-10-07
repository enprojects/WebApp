using System;
using System.Collections.Generic;

namespace WebApp.DataLayer
{
    public interface IGeneralRepository<Tentity>
    {
        IEnumerable<Tentity> GetByCretiria(Func<Tentity, bool> func);
        int Save();
        int Delete(Tentity entity);
        int Add(Tentity entity);
        // int Update(Tentity entity); 
        int Update();
        Tentity Get(Func<Tentity, bool> func);
    }
}