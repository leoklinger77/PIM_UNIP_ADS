using System;
using System.Collections.Generic;

namespace UnipPim.Hotel.Models
{
    public class ProdutoViewModel
    {
        public Guid Id { get; set; }
        public Guid CategoriaId { get; set; }
        public string Nome { get; set; }
        public string CodigoBarras { get;  set; }
        public int QuantidadeEstoque { get;  set; }
        public int QuantidadeVendida { get; private set; }
        public decimal Valor { get;  set; }
        public CategoriaViewModel Categoria { get;  set; }

        public IEnumerable<CategoriaViewModel> ListaCategoria { get; set; } = new List<CategoriaViewModel>();
    }
}
