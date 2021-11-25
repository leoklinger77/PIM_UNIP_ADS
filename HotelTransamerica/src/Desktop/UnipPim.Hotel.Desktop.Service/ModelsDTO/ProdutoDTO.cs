using System;

namespace UnipPim.Hotel.Desktop.Service.ModelsDTO
{
    public class ProdutoDTO
    {
        public Guid Id { get; set; }
        public Guid CategoriaId { get; set; }
        public string Nome { get; set; }
        public string CodigoBarras { get; set; }        
        public int QuantidadeEstoque { get; set; }        
        public int QuantidadeVendida { get; set; }  
        public decimal Valor { get; set; }
        public CategoriaDTO Categoria { get; set; }

        public int QuantidadeDeVendaAtual { get; set; }
    }

    public class CategoriaDTO
    {
        public Guid Id { get; set; }        
        public string Nome { get; set; }
    }
}
