using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bll;
using Common;
using Model;

namespace UI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private ManagerInfoBll miBll = new ManagerInfoBll();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ManagerInfo mi = new ManagerInfo()
            {
                MName = txtName.Text.Trim(),
                MPwd = MD5Helper.GetMD5(txtPwd.Text.Trim()) 
            };
            if (miBll.Login(mi))
            {
                FormMain fm = new FormMain();
                fm.Tag = mi.MType;
                fm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(@"用户名或密码错误");
            }
        }
    }
}
