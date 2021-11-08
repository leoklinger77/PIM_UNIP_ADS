using UnipPim.Hotel.Pagamento.Dominio.Models;

namespace UnipPim.Hotel.Pagamento.Dominio.Servico
{
    public interface IPagamentoCartaoCreditoFacade
    {
        Transacao RealizarPagamento(Pedido pedido, Models.Pagamento pagamento);
    }
}
