
namespace ProductDemo
{
    partial class Form1
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtedit = new Telerik.WinControls.UI.RadButton();
            this.txtdelete = new Telerik.WinControls.UI.RadButton();
            this.txtadd = new Telerik.WinControls.UI.RadButton();
            this.txtsearch = new Telerik.WinControls.UI.RadTextBox();
            this.search = new Telerik.WinControls.UI.RadButton();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            this.radLabel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtadd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.search)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.AutoSize = false;
            this.radLabel1.Controls.Add(this.txtedit);
            this.radLabel1.Controls.Add(this.txtdelete);
            this.radLabel1.Controls.Add(this.txtadd);
            this.radLabel1.Controls.Add(this.txtsearch);
            this.radLabel1.Controls.Add(this.search);
            this.radLabel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.radLabel1.Location = new System.Drawing.Point(648, 0);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(152, 450);
            this.radLabel1.TabIndex = 1;
            // 
            // txtedit
            // 
            this.txtedit.Location = new System.Drawing.Point(23, 410);
            this.txtedit.Name = "txtedit";
            this.txtedit.Size = new System.Drawing.Size(110, 24);
            this.txtedit.TabIndex = 2;
            this.txtedit.Text = "แก้ไข";
            // 
            // txtdelete
            // 
            this.txtdelete.Location = new System.Drawing.Point(22, 376);
            this.txtdelete.Name = "txtdelete";
            this.txtdelete.Size = new System.Drawing.Size(110, 24);
            this.txtdelete.TabIndex = 2;
            this.txtdelete.Text = "ลบ";
            // 
            // txtadd
            // 
            this.txtadd.Location = new System.Drawing.Point(22, 340);
            this.txtadd.Name = "txtadd";
            this.txtadd.Size = new System.Drawing.Size(110, 24);
            this.txtadd.TabIndex = 2;
            this.txtadd.Text = "เพิ่ม";
            // 
            // txtsearch
            // 
            this.txtsearch.AutoSize = false;
            this.txtsearch.Location = new System.Drawing.Point(10, 34);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(133, 43);
            this.txtsearch.TabIndex = 0;
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(22, 83);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(110, 24);
            this.search.TabIndex = 1;
            this.search.Text = "ค้นหา";
     
            // 
            // radGridView1
            // 
            this.radGridView1.BackColor = System.Drawing.SystemColors.Control;
            this.radGridView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.radGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridView1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.radGridView1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radGridView1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radGridView1.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "ITEMBARCODE";
            gridViewTextBoxColumn1.HeaderText = "บาร์โค้ด";
            gridViewTextBoxColumn1.Name = "ITEMBARCODE";
            gridViewTextBoxColumn1.Width = 58;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "ITEMID";
            gridViewTextBoxColumn2.HeaderText = "รหัสสินค้า";
            gridViewTextBoxColumn2.Name = "ITEMID";
            gridViewTextBoxColumn2.Width = 58;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "INVENTDIMID";
            gridViewTextBoxColumn3.HeaderText = "มิติ";
            gridViewTextBoxColumn3.Name = "INVENTDIMID";
            gridViewTextBoxColumn3.Width = 58;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "UNITID";
            gridViewTextBoxColumn4.HeaderText = "หน่วย";
            gridViewTextBoxColumn4.Name = "UNITID";
            gridViewTextBoxColumn4.Width = 58;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "SPC_PRICEGROUP3";
            gridViewTextBoxColumn5.HeaderText = "ราคา";
            gridViewTextBoxColumn5.Name = "SPC_PRICEGROUP3";
            gridViewTextBoxColumn5.Width = 58;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "SPC_ITEMNAME";
            gridViewTextBoxColumn6.HeaderText = "ชื่อสินค้า";
            gridViewTextBoxColumn6.Name = "SPC_ITEMNAME";
            gridViewTextBoxColumn6.Width = 58;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "SPC_IMAGEPATH ";
            gridViewTextBoxColumn7.HeaderText = "รูป";
            gridViewTextBoxColumn7.Name = "SPC_IMAGEPATH ";
            gridViewTextBoxColumn7.Width = 58;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "SPC_ITEMBUYERGROUPID";
            gridViewTextBoxColumn8.HeaderText = "รหัสจัดซื้อ";
            gridViewTextBoxColumn8.Name = "SPC_ITEMBUYERGROUPID";
            gridViewTextBoxColumn8.Width = 58;
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.FieldName = "PRIMARYVENDORID";
            gridViewTextBoxColumn9.HeaderText = "รหัสผู้จำหน่าย";
            gridViewTextBoxColumn9.Name = "PRIMARYVENDORID";
            gridViewTextBoxColumn9.Width = 58;
            gridViewTextBoxColumn10.EnableExpressionEditor = false;
            gridViewTextBoxColumn10.FieldName = "NAME";
            gridViewTextBoxColumn10.HeaderText = "ชื่อผู้จำหน่าย";
            gridViewTextBoxColumn10.Name = "NAME";
            gridViewTextBoxColumn10.Width = 59;
            gridViewTextBoxColumn11.EnableExpressionEditor = false;
            gridViewTextBoxColumn11.FieldName = "DESCRIPTION";
            gridViewTextBoxColumn11.HeaderText = "คำอธิบาย";
            gridViewTextBoxColumn11.Name = "DESCRIPTION";
            gridViewTextBoxColumn11.Width = 56;
            this.radGridView1.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11});
            this.radGridView1.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.ReadOnly = true;
            this.radGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radGridView1.Size = new System.Drawing.Size(648, 450);
            this.radGridView1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.radGridView1);
            this.Controls.Add(this.radLabel1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            this.radLabel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtadd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.search)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadButton search;
        private Telerik.WinControls.UI.RadTextBox txtsearch;
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private Telerik.WinControls.UI.RadButton txtedit;
        private Telerik.WinControls.UI.RadButton txtdelete;
        private Telerik.WinControls.UI.RadButton txtadd;
    }
}

