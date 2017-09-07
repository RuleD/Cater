using System;
using System.Windows.Forms;
using Bll;
using Model;

namespace UI
{
    public partial class DishTypeInfoList : Form
    {
        public event Action TypeEvent;
        private static DishTypeInfoList dishTypeInfoList;
        private DishTypeInfoList()
        {
            InitializeComponent();
        }

        public static DishTypeInfoList Create()
        {
            if (dishTypeInfoList == null || dishTypeInfoList.IsDisposed)
            {
                dishTypeInfoList = new DishTypeInfoList();
            }
            return dishTypeInfoList;
        }

        DishTypeInfoBll mtiBll = new DishTypeInfoBll();

        private void Form1_Load(object sender, EventArgs e)
        {
            ReLoad_List();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            DishTypeInfo mi = new DishTypeInfo()
            {
                DTitle = txtTitle.Text.Trim(),
                DIsDelete = false
            };
            if (btn_Add.Text == @"添加")
            {
                if (mtiBll.Add(mi))
                {
                    btn_Cancel_Click(null, null);
                    ReLoad_List();
                    if (TypeEvent != null) TypeEvent();
                }
                else
                {
                    MessageBox.Show(@"添加出错");
                }
            }
            else
            {
                mi.DId = Convert.ToInt32(txtId.Text.Trim());
                if (mtiBll.Update(mi))
                {
                    btn_Cancel_Click(null, null);
                    ReLoad_List();
                    if (TypeEvent != null) TypeEvent();
                }
                else
                {
                    MessageBox.Show(@"修改出错");
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
                        if (TypeEvent != null) TypeEvent();
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
            btn_Add.Text = @"修改";
        }
    }
}
