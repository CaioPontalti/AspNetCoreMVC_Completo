using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Data.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : Entity, new()
    {

        protected readonly MeuDbContext _context;
        protected readonly DbSet<T> _DbSet;


        public Repository(MeuDbContext context)
        {
            _context = context;
            _DbSet = _context.Set<T>();
        }


        public async Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> expressao)
        {
            var result = await _DbSet.AsNoTracking().Where(expressao).ToListAsync();

            return result;
        }

        public virtual async Task<T> ObterPorId(Guid id)
        {
            var result = await _DbSet.FindAsync(id);

            return result;
        }

        public virtual async Task<List<T>> ObterTdos()
        {
            var result = await _DbSet.ToListAsync();

            return result;
        }

        public virtual async Task Adicionar(T entity)
        {
            _DbSet.Add(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task Atualizar(T entity)
        {
            _DbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task Remover(Guid id)
        {
            _DbSet.Remove(new T { Id = id });
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
