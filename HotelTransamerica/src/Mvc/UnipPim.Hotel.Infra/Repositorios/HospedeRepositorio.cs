using Microsoft.EntityFrameworkCore;
using System;
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
    public class HospedeRepositorio : IHospedeRepositorio
    {
        private readonly HotelContext _context;

        public HospedeRepositorio(HotelContext context)
        {
            _context = context;
        }

        public async Task<Paginacao<Hospede>> Paginacao(int page, int size, string query)
        {
            IPagedList<Hospede> list;
            if (string.IsNullOrEmpty(query))
            {
                list = await _context.Hospede.AsNoTracking().ToPagedListAsync(page, size);
            }
            else
            {
                list = await _context.Hospede.AsNoTracking()
                    .Where(x => x.Cpf.Contains(query)|| x.NomeCompleto.Contains(query))
                    .ToPagedListAsync(page, size);
            }

            return new Paginacao<Hospede>()
            {
                List = list.ToList(),
                TotalResult = list.TotalItemCount,
                PageIndex = page,
                PageSize = size,
                Query = query
            };
        }

        public async Task<Hospede> ObterPorId(Guid id)
        {
            return await _context.Hospede.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Hospede> Find(Expression<Func<Hospede, bool>> predicate)
        {
            return await _context.Hospede.AsNoTracking().Where(predicate).FirstOrDefaultAsync();
        }

        public async Task Insert(Hospede entity)
        {
            await _context.Hospede.AddAsync(entity);
        }

        public async Task AddEmail(Email email)
        {
            await _context.Email.AddAsync(email);
        }

        public async Task AddTelefone(Telefone telefone)
        {
            await _context.Telefone.AddAsync(telefone);
        }

        public async Task AddEndereco(Endereco endereco)
        {
            await _context.Endereco.AddAsync(endereco);
        }

        public async Task Update(Hospede entity)
        {
             _context.Hospede.Update(entity);
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

        public async Task Delete(Hospede entity)
        {
             _context.Hospede.Remove(entity);
        }

        public async Task DeleteEmail(Email email)
        {
            _context.Email.Remove(email);
        }

        public async Task DeleteTelefone(Telefone telefone)
        {
            _context.Telefone.Remove(telefone);
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
