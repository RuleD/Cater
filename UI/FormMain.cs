using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if (this.Tag.ToString().Equals("0"))
            {
                menuManager.Visible = false;
            }
        }

        private void menuQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
