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
        private ApplicationContext _context { get; set; }

        public BaseRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<TDbModel> Create(TDbModel model)
        {
            _context.Set<TDbModel>().Add(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task Delete(Guid id)
        {
            var toDelete = _context.Set<TDbModel>().FirstOrDefault(m => m.Id == id);
            _context.Set<TDbModel>().Remove(toDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<List<TDbModel>> GetAll()
        {
            return _context.Set<TDbModel>().ToList();
        }

        public async Task<TDbModel> Update(TDbModel model)
        {
            var toUpdate = _context.Set<TDbModel>().FirstOrDefault(m => m.Id == model.Id);
            if (toUpdate != null)
            {
                toUpdate = model;
            }
            _context.Update(toUpdate);
            await _context.SaveChangesAsync();
            return toUpdate;
        }

        public async Task<TDbModel> Get(Guid id)
        {
            return await _context.Set<TDbModel>().FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
