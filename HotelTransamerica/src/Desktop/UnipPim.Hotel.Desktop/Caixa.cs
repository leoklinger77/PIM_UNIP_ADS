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

        public Caixa(IServiceProvider provider)
        {
            InitializeComponent();
            _provider = provider;
            _user = _provider.GetService<IUser>();                        
        }        

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void Caixa_Load(object sender, EventArgs e)
        {

        }
    }
}
