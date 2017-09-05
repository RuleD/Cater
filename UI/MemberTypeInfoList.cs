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
    public partial class MemberTypeInfoList : Form
    {
        public MemberTypeInfoList()
        {
            InitializeComponent();
        }
        MemberTypeInfoBll mtiBll = new MemberTypeInfoBll();

        private void Form1_Load(object sender, EventArgs e)
        {
            ReLoad_List();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            MemberTypeInfo mi = new MemberTypeInfo()
            {
                MTitle = txtTitle.Text.Trim(),
                MDiscount = Convert.ToDecimal(txtDiscount.Text.Trim()),
                MIsDelete = false
            };
            if (btn_Add.Text == "添加")
            {
                if (mtiBll.Add(mi))
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
                if (mtiBll.Update(mi))
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
            gvList.DataSource = mtiBll.GetList();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            txtId.Text = @"添加时无编号";
            txtTitle.Text = "";
            txtDiscount.Text = "";
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
                    if (mtiBll.Remove(id))
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
            txtTitle.Text = row.Cells[1].Value.ToString();
            txtDiscount.Text = row.Cells[2].Value.ToString();
            btn_Add.Text = @"修改";
        }
    }
}
