namespace UI
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuManager = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMember = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDish = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTable = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuManager,
            this.menuMember,
            this.menuDish,
            this.menuTable,
            this.menuOrder,
            this.menuQuit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(798, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuManager
            // 
            this.menuManager.Name = "menuManager";
            this.menuManager.Size = new System.Drawing.Size(68, 21);
            this.menuManager.Text = "店员管理";
            this.menuManager.Click += new System.EventHandler(this.menuManager_Click);
            // 
            // menuMember
            // 
            this.menuMember.Name = "menuMember";
            this.menuMember.Size = new System.Drawing.Size(68, 21);
            this.menuMember.Text = "会员管理";
            this.menuMember.Click += new System.EventHandler(this.menuMember_Click);
            // 
            // menuDish
            // 
            this.menuDish.Name = "menuDish";
            this.menuDish.Size = new System.Drawing.Size(68, 21);
            this.menuDish.Text = "菜单管理";
            this.menuDish.Click += new System.EventHandler(this.menuDish_Click);
            // 
            // menuTable
            // 
            this.menuTable.Name = "menuTable";
            this.menuTable.Size = new System.Drawing.Size(68, 21);
            this.menuTable.Text = "餐桌管理";
            // 
            // menuOrder
            // 
            this.menuOrder.Name = "menuOrder";
            this.menuOrder.Size = new System.Drawing.Size(68, 21);
            this.menuOrder.Text = "订单管理";
            // 
            // menuQuit
            // 
            this.menuQuit.Name = "menuQuit";
            this.menuQuit.Size = new System.Drawing.Size(44, 21);
            this.menuQuit.Text = "退出";
            this.menuQuit.Click += new System.EventHandler(this.menuQuit_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 422);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "餐饮管理";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuManager;
        private System.Windows.Forms.ToolStripMenuItem menuMember;
        private System.Windows.Forms.ToolStripMenuItem menuDish;
        private System.Windows.Forms.ToolStripMenuItem menuTable;
        private System.Windows.Forms.ToolStripMenuItem menuOrder;
        private System.Windows.Forms.ToolStripMenuItem menuQuit;
    }
}