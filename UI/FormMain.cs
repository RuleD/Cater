using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bll;
using Model;

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
            if (this.Tag != null && this.Tag.ToString().Equals("0"))
            {
                menuManager.Visible = false;
            }
            Load_HallInfo();
        }

        private void menuQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuMember_Click(object sender, EventArgs e)
        {
            MemberInfoList m = MemberInfoList.Create();
            m.Show();
            m.Focus();
        }

        private void menuDish_Click(object sender, EventArgs e)
        {
            DishInfoList d=DishInfoList.Create();
            d.Show();
            d.Focus();
        }

        private void menuManager_Click(object sender, EventArgs e)
        {
            ManagerInfoList m=ManagerInfoList.Create();
            m.Show();
            m.Focus();
        }

        private void menuTable_Click(object sender, EventArgs e)
        {
            TableInfoList t=TableInfoList.Create();
            t.Show();
            t.Focus();
        }

        private void Load_HallInfo()
        {
            HallInfoBll hallInfoBll = new HallInfoBll();
            var list = hallInfoBll.GetList();
            foreach (HallInfo info in list)
            {
                TabPage tabPage=new TabPage(info.HTitle);
                tabPage.Tag = info.HId;
                tabControl1.TabPages.Add(tabPage);
            }
            tabControl1_SelectedIndexChanged(null, null);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage tabPage = tabControl1.SelectedTab;
            int tableId = Convert.ToInt32(tabPage.Tag.ToString());
            TableInfoBll tableInfoBll = new TableInfoBll();
            var list = tableInfoBll.GetList(tableId);
            ListView listView = new ListView();
            listView.LargeImageList = imageList1;
            foreach (TableInfo info in list)
            {
                listView.Items.Add(new ListViewItem(info.TTitle,info.TIsFree?1:0));
            }
            listView.Dock=DockStyle.Fill;
            tabPage.Controls.Add(listView);
        }


    }
}
