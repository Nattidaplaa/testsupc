
namespace ProductDemo
{
    partial class Search
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.gridsearch = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridsearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridsearch.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // gridsearch
            // 
            this.gridsearch.BackColor = System.Drawing.SystemColors.Control;
            this.gridsearch.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridsearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridsearch.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.gridsearch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gridsearch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gridsearch.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.gridsearch.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "ITEMID";
            gridViewTextBoxColumn1.HeaderText = "รหัสสินค้า";
            gridViewTextBoxColumn1.Name = "ITEMID";
            gridViewTextBoxColumn1.Width = 257;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "INVENTDIMID";
            gridViewTextBoxColumn2.HeaderText = "มิติสินค้า";
            gridViewTextBoxColumn2.Name = "INVENTDIMID";
            gridViewTextBoxColumn2.Width = 247;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "SPC_IMAGEPATH";
            gridViewTextBoxColumn3.HeaderText = "รูปภาพ";
            gridViewTextBoxColumn3.Name = "SPC_IMAGEPATH";
            gridViewTextBoxColumn3.Width = 277;
            this.gridsearch.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3});
            this.gridsearch.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridsearch.Name = "gridsearch";
            this.gridsearch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gridsearch.Size = new System.Drawing.Size(800, 450);
            this.gridsearch.TabIndex = 0;
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gridsearch);
            this.Name = "Search";
            this.Text = "Search";
            ((System.ComponentModel.ISupportInitialize)(this.gridsearch.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridsearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView gridsearch;
    }
}