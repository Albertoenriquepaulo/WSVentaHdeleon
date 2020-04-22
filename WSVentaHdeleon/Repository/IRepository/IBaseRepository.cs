using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSVentaHdeleon.Models.ViewModels;

namespace WSVentaHdeleon.Repository.IRepository
{
    public interface IBaseRepository<T> where T : class
    {
        T GetAll();
        T GetOne(int id);
        T Update(ClienteVM oModel);
        T Create(ClienteVM oModel);
        T Delete(int id);

    }
}
