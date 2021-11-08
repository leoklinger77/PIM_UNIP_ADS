using System;
using System.Linq;
using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Interfaces;
using UnipPim.Hotel.Dominio.Interfaces.Repositorio;
using UnipPim.Hotel.Dominio.Interfaces.Servicos;
using UnipPim.Hotel.Dominio.Models;

namespace UnipPim.Hotel.Dominio.Servicos
{
    public class CaixaServico : ServicoBase, ICaixaServico
    {
        private readonly ICaixaRepositorio _caixaRepositorio;
        private readonly IProdutoRepositorio _produtoRepositorio;
        public CaixaServico(INotificacao notifier, ICaixaRepositorio caixaRepositorio, IProdutoRepositorio produtoRepositorio) : base(notifier)
        {
            _caixaRepositorio = caixaRepositorio;
            _produtoRepositorio = produtoRepositorio;
        }

        public async Task AbrirCaixa(Guid funcionarioId, decimal valorDeAbertura)
        {
            var result = await _caixaRepositorio.ObterCaixaPorFuncionario(funcionarioId);

            if (result != null)
            {
                Notificar("Funcionario já possui Caixa aberto.");
                return;
            }

            if (valorDeAbertura < 0)
            {
                Notificar("Valor de abertura do caixa não pode ser menor que 0.");
                return;
            }

            await _caixaRepositorio.Insert(new Caixa(valorDeAbertura, funcionarioId));

            await _caixaRepositorio.SaveChanges();
            await Task.CompletedTask;
        }

        public async Task FecharCaixa(Guid funcionario)
        {
            var result = await _caixaRepositorio.ObterCaixaPorFuncionario(funcionario);

            if (result == null)
            {
                Notificar("Funcionario não possui Caixa aberto.");
                return;
            }

            result.FecharCaixa();

            await _caixaRepositorio.Update(result);

            await _caixaRepositorio.SaveChanges();
            await Task.CompletedTask;
        }

        public async Task<Caixa> ObterCaixa(Guid funcionario)
        {
            var result = await _caixaRepositorio.ObterCaixaPorFuncionario(funcionario);

            if (result == null)
            {
                Notificar("Funcionario não possui Caixa aberto.");
                return result;
            }
            return result;
        }

        public async Task<OrderVenda> IniciarOrderDeVenda(Guid funcId, string cpf)
        {
            var orderAtivaExist = await _caixaRepositorio.ObterOrderRascunho(funcId);
            if (orderAtivaExist != null)
            {                
                return orderAtivaExist;
            }

            var caixa = await _caixaRepositorio.ObterCaixaPorFuncionario(funcId);
            if (caixa == null)
            {
                Notificar("Caixa fechado.");
                return null;
            }

            var order = new OrderVenda(caixa.Id, cpf);

            await _caixaRepositorio.Insert(order);
            await _caixaRepositorio.SaveChanges();

            return order;
        }

        public async Task AddProdutoNaOrder(Guid funcId, Guid orderVendaId, Guid produtoId, int quantidade)
        {
            var orderAtivaExist = await _caixaRepositorio.ObterOrderRascunho(funcId);
            if (orderAtivaExist == null)
            {
                Notificar("Order não existente.");
                return;
            }
            var product = await _produtoRepositorio.ObterPorId(produtoId);
            if (product == null)
            {
                Notificar("Produto não existe");
                return;
            }

            int qtde = orderAtivaExist.ItensVendas.Count;
            var item = new ItensVenda(orderVendaId, produtoId, product.Valor, quantidade);
            orderAtivaExist.AddItem(item);

            if(qtde < orderAtivaExist.ItensVendas.Count)
            {
                await _caixaRepositorio.Insert(item);
            }
            else
            {
                await _caixaRepositorio.Update(orderAtivaExist.ItensVendas);
            }            
            await _caixaRepositorio.Update(orderAtivaExist);
            await _caixaRepositorio.SaveChanges();
        }

        public async Task UpdateProdutoNaOrder(Guid funcId, Guid orderVendaId, Guid produtoId, int quantidade)
        {
            var orderAtivaExist = await _caixaRepositorio.ObterOrderRascunho(funcId);
            if (orderAtivaExist == null)
            {
                Notificar("Order não existente.");
                return;
            }
            var itemVenda = orderAtivaExist.ItensVendas.FirstOrDefault(x => x.ProdutoId == produtoId);
            if (itemVenda == null)
            {
                Notificar("Produto não existe");
                return;
            }
                                    
            orderAtivaExist.UpdateItem(new ItensVenda(orderVendaId, produtoId, itemVenda.PrecoVenda, quantidade));
            
            await _caixaRepositorio.RemoverItemVenda(itemVenda);
            await _caixaRepositorio.Update(orderAtivaExist);
            await _caixaRepositorio.SaveChanges();
        }

        public async Task RemoverProdutoNaOrder(Guid funcId, Guid orderVendaId, Guid produtoId)
        {
            var orderAtivaExist = await _caixaRepositorio.ObterOrderRascunho(funcId);
            if (orderAtivaExist == null)
            {
                Notificar("Order não existente.");
                return;
            }

            var itemVenda = orderAtivaExist.ItensVendas.FirstOrDefault(x => x.ProdutoId == produtoId);
            if (itemVenda == null)
            {
                Notificar("Produto não existe");
                return;
            }

            orderAtivaExist.RemoveItem(itemVenda);

            await _caixaRepositorio.RemoverItemVenda(itemVenda);
            await _caixaRepositorio.Update(orderAtivaExist);
            await _caixaRepositorio.SaveChanges();
        }
    }
}
