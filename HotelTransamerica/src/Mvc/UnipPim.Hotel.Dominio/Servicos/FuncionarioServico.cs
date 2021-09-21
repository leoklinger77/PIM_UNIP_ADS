using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Interfaces;
using UnipPim.Hotel.Dominio.Interfaces.Repositorio;
using UnipPim.Hotel.Dominio.Interfaces.Servicos;
using UnipPim.Hotel.Dominio.Models;
using UnipPim.Hotel.Dominio.Models.Validacoes;

namespace UnipPim.Hotel.Dominio.Servicos
{
    public class FuncionarioServico : ServicoBase, IFuncionarioServico
    {
        private readonly IFuncionarioRepositorio _funcionarioRepositorio;
        public FuncionarioServico(INotificacao notifier,
                                  IFuncionarioRepositorio funcionarioRepositorio)
                                  : base(notifier)
        {
            _funcionarioRepositorio = funcionarioRepositorio;
        }

        public async Task<bool> Insert(Funcionario funcionario)
        {
            if (IniciarValidacao(new FuncionarioValidation(), funcionario)) return false;

            await _funcionarioRepositorio.Insert(funcionario);

            return await _funcionarioRepositorio.SaveChanges() > 0;
        }
    }
}
