using System;
using System.Windows.Forms;

namespace UnipPim.Hotel.Desktop
{
    public partial class Home : Form
    {
        private readonly IServiceProvider _provider;        

        public Home(IServiceProvider provider)
        {
            InitializeComponent();
            _provider = provider;            
        }

        private void abrirCaixaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AberturaCaixa frmfilho = new AberturaCaixa(_provider);
            frmfilho.MdiParent = this;
            frmfilho.Show();
        }

        private void fileMenu_Click(object sender, EventArgs e)
        {

        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form = new Login(_provider);
            form.Closed += (s, args) => this.Close();
            form.Show();
        }
    }
}
