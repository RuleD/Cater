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
    public partial class ManagerInfoList : Form
    {
        ManagerInfoBll miBll = new ManagerInfoBll();
        private static ManagerInfoList managerInfoList;
        public ManagerInfoList()
        {
            InitializeComponent();
        }

        public static ManagerInfoList Create()
        {
            if (managerInfoList == null || managerInfoList.IsDisposed)
            {
                managerInfoList = new ManagerInfoList();
            }
            return managerInfoList;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ReLoad_List();
        }

        private void gvList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                switch (e.Value.ToString())
                {
                    case "1":
                        e.Value = "经理";
                        break;
                    case "0":
                        e.Value = "店员";
                        break;
                }
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            ManagerInfo mi = new ManagerInfo()
            {
                MName = txtName.Text.Trim(),
                MPwd = txtPwd.Text.Trim(),
                MType = rb1.Checked ? 1 : 0
            };
            if (btn_Add.Text == "添加")
            {
                if (miBll.Add(mi))
                {
                    btn_Cancel_Click(null, null);
                    ReLoad_List();
                }
                else
                {
                    MessageBox.Show("添加出错");
                }
            }
            else
            {
                mi.Mid = Convert.ToInt32(txtId.Text.Trim());
                if (miBll.Update(mi))
                {
                    btn_Cancel_Click(null, null);
                    ReLoad_List();
                }
                else
                {
                    MessageBox.Show("修改出错");
                }
            }
        }

        private void ReLoad_List()
        {
            gvList.AutoGenerateColumns = false;
            gvList.DataSource = miBll.GetList(null);
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            txtId.Text = @"添加时无编号";
            txtName.Text = "";
            txtPwd.Text = "";
            rb2.Checked = true;
            btn_Add.Text = @"添加";
        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            var rows = gvList.SelectedRows;
            if (rows.Count > 0)
            {
                DialogResult result = MessageBox.Show(@"确认要删除吗？", @"提示", MessageBoxButtons.OKCancel);
                if (result==DialogResult.OK)
                {
                    int id = Convert.ToInt32(rows[0].Cells[0].Value.ToString());
                    if (miBll.Remove(id))
                    {
                        ReLoad_List();
                    }
                    else
                    {
                        MessageBox.Show(@"删除失败");
                    }
                }
            }
        }

        private void gvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = gvList.Rows[e.RowIndex];
            txtId.Text = row.Cells[0].Value.ToString();
            txtName.Text = row.Cells[1].Value.ToString();
            txtPwd.Text = @"******";
            if (row.Cells[2].Value.ToString()=="1")
            {
                rb1.Checked = true;
            }
            else
            {
                rb2.Checked = true;
            }
            btn_Add.Text = @"修改";
        }
    }
}
