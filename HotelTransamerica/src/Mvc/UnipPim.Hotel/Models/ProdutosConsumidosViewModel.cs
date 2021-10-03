using System;

namespace UnipPim.Hotel.Models
{
    public class ProdutosConsumidosViewModel
    {
        public Guid FrigobarId { get; set; }
        public ProdutoViewModel Produto { get; set; }
        public decimal Valor { get; set; }
        public int Quantity { get; set; }
        public FrigobarViewModel Frigobar { get; set; }
    }
}
