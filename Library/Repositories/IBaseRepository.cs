using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Models;

namespace Library.Repositories
{
    public interface IBaseRepository<TDbModel> where TDbModel : IEntity
    {
        public Task<List<TDbModel>> GetAll();

        public Task<TDbModel> Get(Guid id);

        public Task<TDbModel> Create(TDbModel model);

        public Task<TDbModel> Update(TDbModel model);

        public Task Delete(Guid id);
    }
}
