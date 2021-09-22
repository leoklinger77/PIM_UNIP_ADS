using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Interfaces.Repositorio;
using UnipPim.Hotel.Dominio.Models;
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
        public async Task<IPagedList<Funcionario>> Paginacao(int page, int size, string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return await _context.Funcionario.AsNoTracking().ToPagedListAsync(page, size);
            }

            return await _context.Funcionario.AsNoTracking()
                .Where(x => x.NomeCompleto.Contains(query) || x.Cpf.Contains(query))
                .ToPagedListAsync(page, size);
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

        public async Task AddEmail(Email email)
        {
            await _context.Email.AddAsync(email);
        }

        public async Task AddTelefone(Telefone telefone)
        {
            await _context.Telefone.AddAsync(telefone);
        }

        public async Task AddEndereco(Endereco Endereco)
        {
            await _context.Endereco.AddAsync(Endereco);
        }

        public async Task Update(Funcionario entity)
        {
            _context.Funcionario.Update(entity);
        }
        public async Task UpdateEmail(Email email)
        {
            _context.Email.Update(email);
        }

        public async Task UpdateTelefone(Telefone telefone)
        {
            _context.Telefone.Update(telefone);
        }

        public async Task UpdateEndereco(Endereco endereco)
        {
            _context.Endereco.Update(endereco);
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

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.DisposeAsync();
        }
    }
}
