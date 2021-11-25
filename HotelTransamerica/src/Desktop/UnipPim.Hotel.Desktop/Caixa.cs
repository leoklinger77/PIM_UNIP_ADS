using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using UnipPim.Hotel.Desktop.Service.Interfaces;
using UnipPim.Hotel.Desktop.Service.ModelsDTO;

namespace UnipPim.Hotel.Desktop
{
    public partial class Caixa : Form
    {
        private readonly IUser _user;
        private readonly IServiceProvider _provider;
        private readonly ICaixaService _caixaService;
        private Guid OrderVendaId;



        private List<ProdutoDTO> listProduto = new List<ProdutoDTO>();

        decimal valorTotal = 0;
        decimal valorDesconto = 0;
        decimal subTotal = 0;
        decimal valorRecebido = 0;
        decimal troco = 0;

        public Caixa(IServiceProvider provider)
        {
            InitializeComponent();
            _provider = provider;
            _user = _provider.GetService<IUser>();
            _caixaService = _provider.GetService<ICaixaService>();
        }

        private async void txtCodeBarras_TextChanged(object sender, EventArgs e)
        {
            string x = txtCodeBarras.Text.Length > 0 ? txtCodeBarras.Text.Substring(txtCodeBarras.Text.Length - 1) : string.Empty;

            if (x.ToUpper() == "X")
            {
                txtQuantidade.Text = txtCodeBarras.Text.Substring(0, txtCodeBarras.Text.Length - 1);
                txtCodeBarras.Text = string.Empty;
                return;
            }

            if (txtCodeBarras.Text.Length == 13 || txtCodeBarras.Text.Length == 14)
            {
                //TODO Verificar se order ja existe

                var response = await _caixaService.BuscarProdutoPorCodigoDeBarras(txtCodeBarras.Text);

                if (response.Class != null)
                {

                    //Verificar se o produto ja existe
                    var exist = listProduto.FirstOrDefault(x => x.Id == response.Class.Id);
                    if (exist != null)
                    {
                        exist.QuantidadeDeVendaAtual += int.Parse(txtQuantidade.Text);
                    }
                    else
                    {
                        response.Class.QuantidadeDeVendaAtual = int.Parse(txtQuantidade.Text);
                        listProduto.Add(response.Class);
                    }

                    //Calculo de valor
                    valorTotal += response.Class.Valor * int.Parse(txtQuantidade.Text);
                    subTotal = valorTotal - valorDesconto;

                    //Remove lista
                    ItensGridView.Rows.Clear();

                    //adiciona lista novamnete
                    foreach (var item in listProduto)
                    {
                        ItensGridView.Rows.Add(item.Nome, item.QuantidadeDeVendaAtual, item.Valor, item.QuantidadeDeVendaAtual * item.Valor);
                    }

                    Calculo();
                }
                else
                {
                    txtErroBuscaProduto.Text = "Produto não encontrado";
                }
            }

            if (txtCodeBarras.Text.Length >= 15) txtCodeBarras.Text = "";
        }

        private void txtDesconto_TextChanged(object sender, EventArgs e)
        {
            Calculo();
        }
        private void txtValorRecebido_TextChanged(object sender, EventArgs e)
        {
            Calculo();
        }

        private void Calculo()
        {
            valorDesconto = txtDesconto.Text == "" ? 0 : decimal.Parse(txtDesconto.Text);
            subTotal = valorTotal - valorDesconto;

            valorRecebido = txtValorRecebido.Text == "" ? 0 : decimal.Parse(txtValorRecebido.Text);
            if (valorRecebido > 0)
            {
                troco = valorRecebido - subTotal;
                txtTroco.Text = troco.ToString();
            }
            else
            {
                txtTroco.Text = "0";
            }

            //Seta valores no front
            txtTotal.Text = valorTotal.ToString();
            txtDesconto.Text = valorDesconto.ToString();
            txtSubTotal.Text = subTotal.ToString();
            txtQuantidade.Text = "1";
            txtCodeBarras.Text = "";
        }

        private void btnFinalizarVenda_Click(object sender, EventArgs e)
        {
            if (cmbFormaPagamento.Text == "") lblError.Text = "Selecione a forma de pagamento";

            if (cmbFormaPagamento.Text == "Dinheiro")
            {
                if (valorRecebido < subTotal)
                {
                    lblError.Text = "Valor recebido é inferior ao Total a Pagar.";
                    return;
                }
            }
        }       
    }
}
