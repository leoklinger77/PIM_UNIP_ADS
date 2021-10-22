using System;
using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Models;

namespace UnipPim.Hotel.Dominio.Interfaces.Servicos
{
    public interface ICaixaServico
    {
        Task<Caixa> ObterCaixa(Guid funcionario);
        Task AbrirCaixa(Guid funcionario, decimal valorDeAbertura);
        Task FecharCaixa(Guid funcionario);        
        Task<OrderVenda> IniciarOrderDeVenda(Guid funcId, string cpf);
        Task AddProdutoNaOrder(Guid funcId, Guid orderVendaId, Guid produtoId, int quantidade);
    }
}
