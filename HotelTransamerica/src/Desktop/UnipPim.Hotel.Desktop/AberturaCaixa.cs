using System;
using System.Windows.Forms;
using UnipPim.Hotel.Desktop.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace UnipPim.Hotel.Desktop
{
    public partial class AberturaCaixa : Form
    {
        private readonly IServiceProvider _provider;
        private readonly ICaixaService _caixaService;

        public AberturaCaixa(IServiceProvider provider)
        {
            InitializeComponent();
            _provider = provider;
            _caixaService = provider.GetService<ICaixaService>();
        }

        private async void btnConfirmar_Click(object sender, EventArgs e)
        {
            decimal value = decimal.Parse(txtValorAberturaCaixa.Text == "" ? "0.00" : txtValorAberturaCaixa.Text);
            if (value < 0)
            {
                //Erro
            }
            else
            {
                var response = await _caixaService.AbrirCaixa(value);

                if (response.Status == 200)
                {
                    Caixa objpermitir = new Caixa(_provider);
                    objpermitir.MdiParent = this.MdiParent;
                    objpermitir.Show();
                    this.Close();
                }
                else
                {
                    string erro = "";
                    for (int i = 0; i < response.errors.Messagens.Count; i++)
                    {
                        if (i == response.errors.Messagens.Count - 1)
                        {
                            erro += response.errors.Messagens[i];
                        }
                        else
                        {
                            erro += response.errors.Messagens[i] + ", ";
                        }
                    }
                    //Erro
                }
            }
        }
    }
}
