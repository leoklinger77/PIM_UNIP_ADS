using System;
using System.Collections.Generic;

namespace UnipPim.Hotel.Models
{
    public class FrigobarViewModel
    {
        public Guid Id { get; set; }

        public IEnumerable<ProdutosFrigobarViewModel> ProdutosFrigobar { get; set; } = new List<ProdutosFrigobarViewModel>();
        public IEnumerable<ProdutosConsumidosViewModel> ProdutosConsumido { get; set; } = new List<ProdutosConsumidosViewModel>();


        public IEnumerable<ProdutoViewModel> ListaProdutos { get; set; } = new List<ProdutoViewModel>();
    }
}
