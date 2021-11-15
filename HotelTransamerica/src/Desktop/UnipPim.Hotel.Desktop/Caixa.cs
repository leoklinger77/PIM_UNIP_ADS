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
        private Guid OrderVendaId;

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

                //Verificar se existe uma order de venda






                var response = await _caixaService.BuscarProdutoPorCodigoDeBarras(txtCodeBarras.Text);

                if (response.Class != null)
                {

                    //Verificar se já possui produto Adicionado, caso tenha, Adicionar outro, Caso não tenha, Criar uma nova Ordem de Venda
                    //DataGridView dataGridView1 = new DataGridView();
                    //dataGridView1.AutoGenerateColumns = true;
                    //Controls.Add(dataGridView1);
                    //dataGridView1.DataSource = EDIFiles;
                    //this.ShowDialog();
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
