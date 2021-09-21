using System.Collections.Generic;
using System.Linq;
using UnipPim.Hotel.Dominio.Interfaces;

namespace UnipPim.Hotel.Dominio.Notificacoes
{
    public class Noficacao : INotificacao
    {
        private List<string> _erros = new List<string>();

        public Noficacao() { }

        public void AddError(string erro)
        {
            _erros.Add(erro);
        }
        public bool ContemErros()
        {
            return _erros.Any();
        }

        public ICollection<string> Erros()
        {
            return _erros;
        }
    }
}
