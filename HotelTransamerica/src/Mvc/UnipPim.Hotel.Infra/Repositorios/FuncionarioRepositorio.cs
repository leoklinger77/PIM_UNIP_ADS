using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Interfaces.Repositorio;
using UnipPim.Hotel.Dominio.Models;
using UnipPim.Hotel.Dominio.Tools;
using UnipPim.Hotel.Infra.Data;
using X.PagedList;

namespace UnipPim.Hotel.Infra.Repositorios
{
    public class FuncionarioRepositorio : IFuncionarioRepositorio
    {
        private readonly HotelContext _context;

        public FuncionarioRepositorio(HotelContext context)
        {
            _context = context;
        }

        public async Task<Paginacao<Funcionario>> Paginacao(int page, int size, string query)
        {
            IPagedList<Funcionario> list;
            if (string.IsNullOrEmpty(query))
            {
                list = await _context.Funcionario.Include(x => x.Cargo).AsNoTracking().ToPagedListAsync(page, size);
            }
            else
            {
                list = await _context.Funcionario.Include(x => x.Cargo).AsNoTracking()
                                .Where(x => x.NomeCompleto.Contains(query) || x.Cpf.Contains(query))
                                .ToPagedListAsync(page, size);
            }

            

            return new Paginacao<Funcionario>()
            {
                List = list.ToList(),
                TotalResult = list.TotalItemCount,
                PageIndex = page,
                PageSize = size,
                Query = query
            };
        }

        public async Task<Funcionario> Find(Expression<Func<Funcionario, bool>> predicate)
        {
            return await _context.Funcionario.AsNoTracking().Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<Funcionario> ObterPorId(Guid id)
        {
            var result = await _context.Funcionario
                .Include(x => x.Cargo)
                .Include(x => x.Emails)
                .Include(x => x.Telefones)
                .Include(x => x.Enderecos)
                .Include(x => x.GrupoFuncionario.Acesso)
                .AsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            foreach (var item in result.Enderecos)
            {
                item.AssociarCidade(await _context.Cidade.Include(x => x.Estado).AsNoTracking().FirstAsync(x => x.Id == item.CidadeId));
            }

            return result;
        }

        public async Task<Email> ObterEmailPorId(Guid funcionarioId, Guid id)
        {
            return await _context.Email.AsNoTracking()
                .Where(x => x.FuncionarioId == funcionarioId && x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<Telefone> ObterTelefonePorId(Guid funcionarioId, Guid id)
        {
            return await _context.Telefone.AsNoTracking()
                .Where(x => x.FuncionarioId == funcionarioId && x.Id == id)
                .FirstOrDefaultAsync();
        }
        public async Task Insert(Funcionario entity)
        {
            await _context.Funcionario.AddAsync(entity);
        }

        public async Task AddEmail(IEnumerable<Email> email)
        {
            
        }

        public async Task AddTelefone(IEnumerable<Telefone> telefone)
        {
            await _context.Telefone.AddRangeAsync(telefone);
        }

        public async Task AddEndereco(IEnumerable<Endereco> endereco)
        {
            await _context.Endereco.AddRangeAsync(endereco);
        }

        public async Task Update(Funcionario entity)
        {
            _context.Funcionario.Update(entity);
        }
        public async Task UpdateEmail(IEnumerable<Email> email)
        {
            _context.Email.UpdateRange(email);
        }

        public async Task UpdateTelefone(IEnumerable<Telefone> telefone)
        {
            _context.Telefone.UpdateRange(telefone);
        }

        public async Task UpdateEndereco(IEnumerable<Endereco> endereco)
        {
            _context.Endereco.UpdateRange(endereco);
        }

        public async Task Delete(Funcionario entity)
        {
            _context.Funcionario.Remove(entity);
        }

        public async Task DeleteEmail(Email email)
        {
            _context.Email.Remove(email);
        }

        public async Task DeleteTelefone(Telefone email)
        {
            _context.Telefone.Remove(email);
        }

        public async Task DeleteEndereco(Endereco endereco)
        {
            _context.Endereco.Remove(endereco);
        }

        public async Task DeleteEmail(IEnumerable<Email> email)
        {
            _context.Email.RemoveRange(email);
        }

        public async Task DeleteTelefone(IEnumerable<Telefone> telefone)
        {
            _context.Telefone.RemoveRange(telefone);
        }

        public async Task DeleteEndereco(IEnumerable<Endereco> endereco)
        {
            _context.Endereco.RemoveRange(endereco);
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.DisposeAsync();
        }

        public async Task<List<Funcionario>> ObterTodos()
        {
            return await _context.Funcionario
                .Include(x => x.Cargo)
                .Include(x => x.Emails)
                .Include(x => x.Telefones)
                .Include(x => x.Enderecos)                                
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
