using Microsoft.Extensions.DependencyInjection;
using System.Windows.Forms;
using UnipPim.Hotel.Desktop.Service.Interfaces;

namespace UnipPim.Hotel.Desktop
{
    public partial class Home : Form
    {
        private readonly IUser _user;
        private readonly ILoginService _loginService;
        private readonly ServiceProvider _provider;

        public Home(ServiceProvider provider)
        {
            InitializeComponent();
            _provider = provider;
            _user = _provider.GetService<IUser>();
            _loginService = _provider.GetService<ILoginService>();
            toolStripStatusUserEmail.Text = _user.GetEmail();
        }

        private void sairToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            Form form = new Login(_provider);
            form.Closed += (s, args) => this.Close();
            form.Show();
        }
    }
}
