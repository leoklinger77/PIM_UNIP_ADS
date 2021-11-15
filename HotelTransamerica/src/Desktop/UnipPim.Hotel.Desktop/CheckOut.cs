using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UnipPim.Hotel.Desktop
{
    public partial class CheckOut : Form
    {
        private readonly IServiceProvider _provider;
        public CheckOut(IServiceProvider provider)
        {
            _provider = provider;
            InitializeComponent();
        }
    }
}
