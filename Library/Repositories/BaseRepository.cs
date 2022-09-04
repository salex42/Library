using System;
using System.Collections.Generic;
using Library.DataBase;
using Library.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Library.Repositories
{
    public class BaseRepository<TDbModel> : IBaseRepository<TDbModel> where TDbModel : class, IEntity
    {
        protected ApplicationContext _context { get; set; }

        public BaseRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateAsync(TDbModel model)
        {
            _context.Set<TDbModel>().Add(model);
            return model.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var toDelete = _context.Set<TDbModel>().FirstOrDefault(m => m.Id == id);
            _context.Set<TDbModel>().Remove(toDelete);
        }

        public async Task<List<TDbModel>> GetAllAsync()
        {
            return _context.Set<TDbModel>().ToList();
        }

        public async Task<Guid> UpdateAsync(TDbModel model)
        {
            var toUpdate = _context.Set<TDbModel>().FirstOrDefault(m => m.Id == model.Id);
            if (toUpdate != null)
            {
                toUpdate = model;
            }
            _context.Update(toUpdate);
            return toUpdate.Id;
        }

        public async Task<TDbModel> GetAsync(Guid id)
        {
            return await _context.Set<TDbModel>().FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
