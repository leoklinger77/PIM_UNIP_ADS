using UnipPim.Hotel.Dominio.Interfaces;
using UnipPim.Hotel.Pagamento.Dominio.Models;

namespace UnipPim.Hotel.Pagamento.Dominio.Servico
{
    public interface IPagamentoRepository : IRepositorioBase<Models.Pagamento>
    {
        void Adicionar(Models.Pagamento pagamento);
        void AdicionarTransacao(Transacao transacao);
    }
}
