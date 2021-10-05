using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using UnipPim.Hotel.Desktop.Service.Interfaces;
using UnipPim.Hotel.Desktop.Service.ModelsDTO;

namespace UnipPim.Hotel.Desktop
{
    public partial class Login : Form
    {
        private readonly ILoginService _loginService;        
        private readonly IServiceProvider _provider;
        
        public Login(IServiceProvider provider)
        {
            InitializeComponent();
            _provider = provider;            
            _loginService = provider.GetService<ILoginService>();
        }

        private async void btnLogar_Click(object sender, EventArgs e)
        {
            LoginRequest LoginRequest = new LoginRequest() { Email = txtEmail.Text, Password = txtSenha.Text };

            var response = await _loginService.Login(LoginRequest);

            if(response.Status == 200)
            {
                this.Hide();
                Form form = new Home(_provider);
                form.Closed += (s, args) => this.Close();
                form.Show();
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
                lblErrorLogin.Text = erro;
            }
        }

        private void linkLblEsqueceuSenha_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var processes = Process.GetProcessesByName("Chrome");
            var path = processes.FirstOrDefault()?.MainModule?.FileName;
            Process.Start(path, "https://localhost:44342/Identity/Account/ForgotPassword");
        }       
    }
}
