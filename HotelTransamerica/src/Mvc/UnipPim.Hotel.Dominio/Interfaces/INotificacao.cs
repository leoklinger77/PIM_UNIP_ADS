using System;
using System.Collections.Generic;
using System.Text;

namespace UnipPim.Hotel.Dominio.Interfaces
{
    public interface INotificacao
    {
        ICollection<string> Erros();
        void AddError(string erro);
        bool ContemErros();
    }
}
