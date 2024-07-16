using PhoneProg.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//use repository folder here



namespace PhoneProg.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        //create for me repository
        IRepository<T> GetRepository<T>() where T : class;

        int SaveChanges();



    }
}
