using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Repository_Pattern_Db_First.Repositories
{
    interface IRepository<TEntity> where TEntity : class
    {
        List<TEntity> GetAll();

        TEntity Get(int id);

        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
    }
}
