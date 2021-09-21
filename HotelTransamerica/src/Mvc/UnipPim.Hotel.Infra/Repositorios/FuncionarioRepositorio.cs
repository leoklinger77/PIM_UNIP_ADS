using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Interfaces.Repositorio;
using UnipPim.Hotel.Dominio.Models;
using UnipPim.Hotel.Infra.Data;

namespace UnipPim.Hotel.Infra.Repositorios
{
    public class FuncionarioRepositorio : IFuncionarioRepositorio
    {
        private readonly HotelContext _context;

        public FuncionarioRepositorio(HotelContext context)
        {
            _context = context;
        }

        public async Task<Funcionario> Find(Expression<Func<Funcionario, bool>> predicate)
        {
            return await _context.Funcionario.AsNoTracking().Where(predicate).FirstOrDefaultAsync();
        }

        public async Task Insert(Funcionario entity)
        {
            await _context.Funcionario.AddAsync(entity);
        }

        public async Task<Funcionario> ObterPorId(Guid id)
        {
            return await _context.Funcionario.AsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
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

        public async Task AddEmail(Email email)
        {
            await _context.Email.AddAsync(email);
        }

        public async Task AddTelefone(Telefone telefone)
        {
            await _context.Telefone.AddAsync(telefone);
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
