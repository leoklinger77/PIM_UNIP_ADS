using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using UnipPim.Hotel.Desktop.Service.Interfaces;

namespace UnipPim.Hotel.Desktop
{
    public partial class Caixa : Form
    {
        private readonly IUser _user;
        private readonly IServiceProvider _provider;
        private readonly ICaixaService _caixaService;

        public Caixa(IServiceProvider provider)
        {
            InitializeComponent();
            _provider = provider;
            _user = _provider.GetService<IUser>();
            _caixaService = _provider.GetService<ICaixaService>();
        }

        private async void txtCodeBarras_TextChanged(object sender, EventArgs e)
        {
            if (txtCodeBarras.Text.Length == 13 || txtCodeBarras.Text.Length == 14)
            {

                var response = await _caixaService.BuscarProdutoPorCodigoDeBarras(txtCodeBarras.Text);

                if (response.Class == null)
                {

                    //Verificar se já possui produto Adicionado, caso tenha, Adicionar outro, Caso não tenha, Criar uma nova Ordem de Venda

                }
                else
                {
                    txtErroBuscaProduto.Text = "Produto não encontrado";
                }
            }

            if (txtCodeBarras.Text.Length >= 15) txtCodeBarras.Text = "";
        }
    }
}
