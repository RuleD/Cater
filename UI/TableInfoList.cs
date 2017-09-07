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
    public partial class TableInfoList : Form
    {
        private static TableInfoList tableInfoList;
        public TableInfoList()
        {
            InitializeComponent();
        }

        public static TableInfoList Create()
        {
            if (tableInfoList == null || tableInfoList.IsDisposed)
            {
                tableInfoList = new TableInfoList();
            }
            return tableInfoList;
        }
        TableInfoBll dishInfoBll = new TableInfoBll();
        private HallInfoBll hallInfoBll = new HallInfoBll();

        private void Form1_Load(object sender, EventArgs e)
        {
            ReLoad_List();
            ReLoad_TypeList();
        }

        private void ReLoad_TypeList()
        {
            cbType.DisplayMember = "HTitle";
            cbType.ValueMember = "HId";
            cbType.DataSource = hallInfoBll.GetList();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            TableInfo mi = new TableInfo()
            {
                TTitle = txtTitle.Text.Trim(),
                THallId = Convert.ToInt32(cbType.SelectedValue.ToString()),
                THallTitle = cbType.SelectedText,
                TIsFree = true,
                TIsDelete = false
            };
            if (btn_Add.Text == "添加")
            {
                if (dishInfoBll.Add(mi))
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
                mi.TId = Convert.ToInt32(txtId.Text.Trim());
                if (dishInfoBll.Update(mi))
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
            gvList.DataSource = dishInfoBll.GetList();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            txtId.Text = @"添加时无编号";
            txtTitle.Text = "";
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
                    if (dishInfoBll.Remove(id))
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
            txtId.Text = row.Cells["TId"].Value.ToString();
            txtTitle.Text = row.Cells["TTitle"].Value.ToString();
            cbType.Text = row.Cells["THallTitle"].Value.ToString();
            btn_Add.Text = @"修改";
        }

        private void btn_Type_Click(object sender, EventArgs e)
        {
            DishTypeInfoList m = DishTypeInfoList.Create();
            m.TypeEvent += Reloading;
            m.Show();
            m.Focus();
        }

        private void Reloading()
        {
            ReLoad_List();
            ReLoad_TypeList();
        }

        private void gvList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                if (Convert.ToBoolean(e.Value.ToString()))
                {
                    e.Value = "是";
                }
                else
                {
                    e.Value = "否";
                }
            }
        }
    }
}
