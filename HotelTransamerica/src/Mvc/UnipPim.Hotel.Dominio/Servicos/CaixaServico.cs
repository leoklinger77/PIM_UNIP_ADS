using System;
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
        public CaixaServico(INotificacao notifier, ICaixaRepositorio caixaRepositorio) : base(notifier)
        {
            _caixaRepositorio = caixaRepositorio;
        }

        public async Task AbrirCaixa(Guid funcionarioId, decimal valorDeAbertura)
        {
            var result = await _caixaRepositorio.ObterCaixaPorFuncionario(funcionarioId);

            if(result != null)
            {
                Notificar("Funcionario já possui Caixa aberto.");
                return;
            }

            if(valorDeAbertura < 0)
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

            if(result == null)
            {
                Notificar("Funcionario não possui Caixa aberto.");
                return result;
            }
            return result;
        }
    }
}
