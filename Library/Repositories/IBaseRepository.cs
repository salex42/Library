using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Models;

namespace Library.Repositories
{
    public interface IBaseRepository<TDbModel> where TDbModel : IEntity
    {
        public Task<List<TDbModel>> GetAllAsync();

        public Task<TDbModel> GetAsync(Guid id);

        public Task<Guid> CreateAsync(TDbModel model);

        public Task<Guid> UpdateAsync(TDbModel model);

        public Task DeleteAsync(Guid id);

        public Task SaveAsync();
    }
}
