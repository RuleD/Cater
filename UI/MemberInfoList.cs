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
    public partial class MemberInfoList : Form
    {
        private static MemberInfoList memberInfoList = new MemberInfoList();
        private MemberInfoList()
        {
            InitializeComponent();
        }

        public static MemberInfoList Create()
        {
            return memberInfoList;
        }
        MemberInfoBll memberInfoBll = new MemberInfoBll();
        private MemberTypeInfoBll memberTypeInfoBll = new MemberTypeInfoBll();

        private void Form1_Load(object sender, EventArgs e)
        {
            ReLoad_List();
            ReLoad_TypeList();
        }

        private void ReLoad_TypeList()
        {
            cbType.DisplayMember = "MTitle";
            cbType.ValueMember = "MId";
            cbType.DataSource=memberTypeInfoBll.GetList();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            MemberInfo mi = new MemberInfo()
            {
                MName = txtName.Text.Trim(),
                MPhone = txtPhone.Text.Trim(),
                MMoney = Convert.ToDecimal(txtMoney.Text.Trim()),
                MTypeId = Convert.ToInt32(cbType.SelectedValue.ToString()),
                MTitle = cbType.SelectedText,
                MIsDelete = false
            };
            if (btn_Add.Text == "添加")
            {
                if (memberInfoBll.Add(mi))
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
                mi.MId = Convert.ToInt32(txtId.Text.Trim());
                if (memberInfoBll.Update(mi))
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
            gvList.DataSource = memberInfoBll.GetList();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            txtId.Text = @"添加时无编号";
            txtName.Text = "";
            txtPhone.Text = "";
            txtMoney.Text = "";
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
                    if (memberInfoBll.Remove(id))
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
            txtId.Text = row.Cells["MId"].Value.ToString();
            txtName.Text = row.Cells["MName"].Value.ToString();
            txtPhone.Text = row.Cells["MPhone"].Value.ToString();
            txtMoney.Text = row.Cells["MMoney"].Value.ToString();
            cbType.Text = row.Cells["MTitle"].Value.ToString();
            btn_Add.Text = @"修改";
        }

        private void btn_Type_Click(object sender, EventArgs e)
        {
            MemberTypeInfoList m=MemberTypeInfoList.Create();
            m.TypeEvent += Reloading;
            m.Show();
            m.Focus();
        }

        private void Reloading()
        {
            ReLoad_List();
            ReLoad_TypeList();
        }
    }
}
