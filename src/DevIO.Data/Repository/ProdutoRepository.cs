using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {

        public ProdutoRepository(MeuDbContext context) : base(context)
        {

        }


        public async Task<Produto> ObterProdutoFornecedor(Guid id)
        {
            var produto = await _DbSet.AsNoTracking()
                                      .Include(f => f.Fornecedor)
                                      .FirstOrDefaultAsync(p => p.Id == id);

            return produto;
        }

        public async Task<IEnumerable<Produto>> ObterProdutosFornecedores()
        {
            var produtos = await _DbSet.AsNoTracking()
                                       .Include(f => f.Fornecedor)
                                       .OrderBy(p => p.Nome).ToListAsync();

            return produtos;
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId)
        {
            var produtos = await Buscar(p => p.FornecedorId == fornecedorId);

            return produtos;
        }
    }
}
