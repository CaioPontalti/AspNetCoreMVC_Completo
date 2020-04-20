using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(MeuDbContext context) : base(context)
        {

        }

        public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
            var fornecedor = await _DbSet.AsNoTracking()
                                        .Include(e => e.Endereco)
                                        .FirstOrDefaultAsync(e => e.Id == id);

            return fornecedor;
        }

        public async Task<Fornecedor> ObterFornecedorProdutosEnderecos(Guid id)
        {
            var fornecedores = await _DbSet.AsNoTracking()
                                           .Include(p => p.Produtos)
                                           .Include(e => e.Endereco)
                                           .FirstOrDefaultAsync(f => f.Id == id);

            return fornecedores;
        }
    }
}
