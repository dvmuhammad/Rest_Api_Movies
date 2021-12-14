using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories.Base
{
    public class RepositoryBase<T>:IRepository<T> where T: class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public RepositoryBase( DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity) => _dbSet.Add(entity);

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity) => _dbSet.Remove(entity);

        public void Delete(Expression<Func<T, bool>> @where)
        {
            var objects = _dbSet.Where(where).AsEnumerable();
            foreach (var obj in objects)
                _dbSet.Remove(obj);
        }

        public bool SaveChanges()=> _context.SaveChanges() >= 0;

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

        public T GetById(int id)=> _dbSet.Find(id);

        public T Get(Expression<Func<T, bool>> @where)=> _dbSet.Where(@where).FirstOrDefault();

        public async Task<T> GetByIdAsync(int id)=> await _dbSet.FindAsync(id);

        public async Task<IEnumerable<T>> GetAllAsync()=> await _dbSet.ToListAsync();

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> @where) => _dbSet.Where(@where).AsEnumerable();


        public IEnumerable<T> GetAll()=> _dbSet.AsEnumerable();
        
    }
}