using System;
using System.Windows.Forms;
using UnipPim.Hotel.Desktop.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace UnipPim.Hotel.Desktop
{
    public partial class Home : Form
    {
        private readonly IServiceProvider _provider;
        private readonly ICaixaService _caixaService;

        public Home(IServiceProvider provider)
        {
            InitializeComponent();
            _provider = provider;
            _caixaService = provider.GetService<ICaixaService>();
        }

        private async void abrirCaixaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var response = await _caixaService.ObterCaixa();

            if (response.Class != null)
            {

                Caixa frmfilho = new Caixa(_provider);
                frmfilho.MdiParent = this;
                frmfilho.Show();
            }
            else
            {
                AberturaCaixa frmfilho = new AberturaCaixa(_provider);
                frmfilho.MdiParent = this;
                frmfilho.Show();
            }
        }

        private async void fecharCaixaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var response = await _caixaService.FecharCaixa();

            if (response.Status == 200)
            {
                if (Application.OpenForms.OfType<Caixa>().Count() > 0)
                {
                    var caixa = Application.OpenForms.OfType<Caixa>().First();
                    caixa.Close();
                }
            }
            else
            {

            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form = new Login(_provider);
            form.Closed += (s, args) => this.Close();
            form.Show();
        }

        private async void checkInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var response = await _caixaService.ObterCaixa();
            if (response.Class != null)
            {
                //CheckIn frmfilho = new CheckIn(_provider);
                //frmfilho.MdiParent = this;
                //frmfilho.Show();
            }
            else
            {
                MessageBox.Show("Caixa fechado. Por favor, abra o caixa.");
            }

        }

        private async void checkOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var response = await _caixaService.ObterCaixa();
            if (response.Class != null)
            {
                CheckOut frmfilho = new CheckOut(_provider);
                frmfilho.MdiParent = this;
                frmfilho.Show();
            }
            else
            {
                MessageBox.Show("Caixa fechado. Por favor, abra o caixa.");
            }
        }
    }
}
