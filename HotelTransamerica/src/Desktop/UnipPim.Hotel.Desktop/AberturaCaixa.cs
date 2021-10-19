using System;
using System.Windows.Forms;

namespace UnipPim.Hotel.Desktop
{
    public partial class AberturaCaixa : Form
    {
        private readonly IServiceProvider _provider;
        public AberturaCaixa(IServiceProvider provider)
        {
            InitializeComponent();
            _provider = provider;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {            
            Caixa objpermitir = new Caixa(_provider);
            objpermitir.MdiParent = this.MdiParent;
            objpermitir.Show();
            this.Close();
        }
    }
}
