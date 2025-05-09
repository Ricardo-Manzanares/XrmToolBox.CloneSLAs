namespace CloneSLAs
{
    partial class CreateSLA
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
            this.gb_NewSLA = new System.Windows.Forms.GroupBox();
            this.cb_MainEntity = new System.Windows.Forms.ComboBox();
            this.tb_NewName = new System.Windows.Forms.TextBox();
            this.lb_NewName = new System.Windows.Forms.Label();
            this.tb_NewDescription = new System.Windows.Forms.TextBox();
            this.lb_Description_Source = new System.Windows.Forms.Label();
            this.lb_MainEntity = new System.Windows.Forms.Label();
            this.p_CopySLA = new System.Windows.Forms.Panel();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.lb_btnCancelSLA = new System.Windows.Forms.Label();
            this.p_CreateSLA = new System.Windows.Forms.Panel();
            this.btn_CreateSLA = new System.Windows.Forms.Button();
            this.lb_btnCreateSLA = new System.Windows.Forms.Label();
            this.gb_NewSLA.SuspendLayout();
            this.p_CopySLA.SuspendLayout();
            this.p_CreateSLA.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_NewSLA
            // 
            this.gb_NewSLA.Controls.Add(this.cb_MainEntity);
            this.gb_NewSLA.Controls.Add(this.tb_NewName);
            this.gb_NewSLA.Controls.Add(this.lb_NewName);
            this.gb_NewSLA.Controls.Add(this.tb_NewDescription);
            this.gb_NewSLA.Controls.Add(this.lb_Description_Source);
            this.gb_NewSLA.Controls.Add(this.lb_MainEntity);
            this.gb_NewSLA.Location = new System.Drawing.Point(12, 12);
            this.gb_NewSLA.Name = "gb_NewSLA";
            this.gb_NewSLA.Size = new System.Drawing.Size(358, 176);
            this.gb_NewSLA.TabIndex = 6;
            this.gb_NewSLA.TabStop = false;
            this.gb_NewSLA.Text = "New SLA";
            // 
            // cb_MainEntity
            // 
            this.cb_MainEntity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_MainEntity.FormattingEnabled = true;
            this.cb_MainEntity.Location = new System.Drawing.Point(6, 71);
            this.cb_MainEntity.Name = "cb_MainEntity";
            this.cb_MainEntity.Size = new System.Drawing.Size(343, 21);
            this.cb_MainEntity.TabIndex = 19;
            this.cb_MainEntity.SelectedValueChanged += new System.EventHandler(this.cb_MainEntity_SelectedValueChanged);
            // 
            // tb_NewName
            // 
            this.tb_NewName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_NewName.Location = new System.Drawing.Point(6, 32);
            this.tb_NewName.Name = "tb_NewName";
            this.tb_NewName.Size = new System.Drawing.Size(343, 20);
            this.tb_NewName.TabIndex = 1;
            // 
            // lb_NewName
            // 
            this.lb_NewName.AutoSize = true;
            this.lb_NewName.Location = new System.Drawing.Point(6, 16);
            this.lb_NewName.Name = "lb_NewName";
            this.lb_NewName.Size = new System.Drawing.Size(35, 13);
            this.lb_NewName.TabIndex = 5;
            this.lb_NewName.Text = "Name";
            // 
            // tb_NewDescription
            // 
            this.tb_NewDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_NewDescription.Location = new System.Drawing.Point(6, 110);
            this.tb_NewDescription.Multiline = true;
            this.tb_NewDescription.Name = "tb_NewDescription";
            this.tb_NewDescription.Size = new System.Drawing.Size(343, 54);
            this.tb_NewDescription.TabIndex = 2;
            // 
            // lb_Description_Source
            // 
            this.lb_Description_Source.AutoSize = true;
            this.lb_Description_Source.Location = new System.Drawing.Point(6, 94);
            this.lb_Description_Source.Name = "lb_Description_Source";
            this.lb_Description_Source.Size = new System.Drawing.Size(60, 13);
            this.lb_Description_Source.TabIndex = 3;
            this.lb_Description_Source.Text = "Description";
            // 
            // lb_MainEntity
            // 
            this.lb_MainEntity.AutoSize = true;
            this.lb_MainEntity.Location = new System.Drawing.Point(6, 55);
            this.lb_MainEntity.Name = "lb_MainEntity";
            this.lb_MainEntity.Size = new System.Drawing.Size(58, 13);
            this.lb_MainEntity.TabIndex = 1;
            this.lb_MainEntity.Text = "Main entity";
            // 
            // p_CopySLA
            // 
            this.p_CopySLA.Controls.Add(this.btn_Cancel);
            this.p_CopySLA.Controls.Add(this.lb_btnCancelSLA);
            this.p_CopySLA.Location = new System.Drawing.Point(191, 194);
            this.p_CopySLA.Name = "p_CopySLA";
            this.p_CopySLA.Size = new System.Drawing.Size(69, 59);
            this.p_CopySLA.TabIndex = 18;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Cancel.Image = global::CloneSLAs.Properties.Resources.cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(14, 0);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(40, 40);
            this.btn_Cancel.TabIndex = 4;
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // lb_btnCancelSLA
            // 
            this.lb_btnCancelSLA.AutoSize = true;
            this.lb_btnCancelSLA.Location = new System.Drawing.Point(11, 43);
            this.lb_btnCancelSLA.Name = "lb_btnCancelSLA";
            this.lb_btnCancelSLA.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lb_btnCancelSLA.Size = new System.Drawing.Size(43, 13);
            this.lb_btnCancelSLA.TabIndex = 14;
            this.lb_btnCancelSLA.Text = "Cancel";
            // 
            // p_CreateSLA
            // 
            this.p_CreateSLA.Controls.Add(this.btn_CreateSLA);
            this.p_CreateSLA.Controls.Add(this.lb_btnCreateSLA);
            this.p_CreateSLA.Location = new System.Drawing.Point(92, 194);
            this.p_CreateSLA.Name = "p_CreateSLA";
            this.p_CreateSLA.Size = new System.Drawing.Size(69, 59);
            this.p_CreateSLA.TabIndex = 17;
            // 
            // btn_CreateSLA
            // 
            this.btn_CreateSLA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_CreateSLA.Image = global::CloneSLAs.Properties.Resources.accept;
            this.btn_CreateSLA.Location = new System.Drawing.Point(14, 0);
            this.btn_CreateSLA.Name = "btn_CreateSLA";
            this.btn_CreateSLA.Size = new System.Drawing.Size(40, 40);
            this.btn_CreateSLA.TabIndex = 3;
            this.btn_CreateSLA.UseVisualStyleBackColor = true;
            this.btn_CreateSLA.Click += new System.EventHandler(this.btn_CreateSLA_Click);
            // 
            // lb_btnCreateSLA
            // 
            this.lb_btnCreateSLA.AutoSize = true;
            this.lb_btnCreateSLA.Location = new System.Drawing.Point(1, 43);
            this.lb_btnCreateSLA.Name = "lb_btnCreateSLA";
            this.lb_btnCreateSLA.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lb_btnCreateSLA.Size = new System.Drawing.Size(64, 13);
            this.lb_btnCreateSLA.TabIndex = 8;
            this.lb_btnCreateSLA.Text = "Create SLA";
            // 
            // CreateSLA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 265);
            this.Controls.Add(this.p_CopySLA);
            this.Controls.Add(this.p_CreateSLA);
            this.Controls.Add(this.gb_NewSLA);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateSLA";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create SLA";
            this.Load += new System.EventHandler(this.CreateSLA_Load);
            this.gb_NewSLA.ResumeLayout(false);
            this.gb_NewSLA.PerformLayout();
            this.p_CopySLA.ResumeLayout(false);
            this.p_CopySLA.PerformLayout();
            this.p_CreateSLA.ResumeLayout(false);
            this.p_CreateSLA.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_NewSLA;
        private System.Windows.Forms.TextBox tb_NewDescription;
        private System.Windows.Forms.Label lb_Description_Source;
        private System.Windows.Forms.Label lb_MainEntity;
        private System.Windows.Forms.Panel p_CopySLA;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label lb_btnCancelSLA;
        private System.Windows.Forms.Panel p_CreateSLA;
        private System.Windows.Forms.Button btn_CreateSLA;
        private System.Windows.Forms.Label lb_btnCreateSLA;
        private System.Windows.Forms.TextBox tb_NewName;
        private System.Windows.Forms.Label lb_NewName;
        private System.Windows.Forms.ComboBox cb_MainEntity;
    }
}