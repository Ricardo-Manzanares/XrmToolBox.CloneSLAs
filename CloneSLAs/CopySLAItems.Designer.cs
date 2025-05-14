namespace CloneSLAs
{
    partial class CopySLAItems
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
            this.p_CopySLA = new System.Windows.Forms.Panel();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.lb_btnCancelSLA = new System.Windows.Forms.Label();
            this.p_CreateSLA = new System.Windows.Forms.Panel();
            this.btn_CopySLA = new System.Windows.Forms.Button();
            this.lb_btnCopySLA = new System.Windows.Forms.Label();
            this.gb_NewSLA = new System.Windows.Forms.GroupBox();
            this.cb_SLATarget = new System.Windows.Forms.ComboBox();
            this.p_CopySLA.SuspendLayout();
            this.p_CreateSLA.SuspendLayout();
            this.gb_NewSLA.SuspendLayout();
            this.SuspendLayout();
            // 
            // p_CopySLA
            // 
            this.p_CopySLA.Controls.Add(this.btn_Cancel);
            this.p_CopySLA.Controls.Add(this.lb_btnCancelSLA);
            this.p_CopySLA.Location = new System.Drawing.Point(191, 71);
            this.p_CopySLA.Name = "p_CopySLA";
            this.p_CopySLA.Size = new System.Drawing.Size(69, 59);
            this.p_CopySLA.TabIndex = 21;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Cancel.Image = global::CloneSLAs.Properties.Resources.cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(14, 0);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(40, 40);
            this.btn_Cancel.TabIndex = 3;
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
            this.p_CreateSLA.Controls.Add(this.btn_CopySLA);
            this.p_CreateSLA.Controls.Add(this.lb_btnCopySLA);
            this.p_CreateSLA.Location = new System.Drawing.Point(95, 71);
            this.p_CreateSLA.Name = "p_CreateSLA";
            this.p_CreateSLA.Size = new System.Drawing.Size(69, 59);
            this.p_CreateSLA.TabIndex = 20;
            // 
            // btn_CopySLA
            // 
            this.btn_CopySLA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_CopySLA.Image = global::CloneSLAs.Properties.Resources.accept;
            this.btn_CopySLA.Location = new System.Drawing.Point(14, 0);
            this.btn_CopySLA.Name = "btn_CopySLA";
            this.btn_CopySLA.Size = new System.Drawing.Size(40, 40);
            this.btn_CopySLA.TabIndex = 2;
            this.btn_CopySLA.UseVisualStyleBackColor = true;
            this.btn_CopySLA.Click += new System.EventHandler(this.btn_CopySLA_Click);
            // 
            // lb_btnCopySLA
            // 
            this.lb_btnCopySLA.AutoSize = true;
            this.lb_btnCopySLA.Location = new System.Drawing.Point(1, 43);
            this.lb_btnCopySLA.Name = "lb_btnCopySLA";
            this.lb_btnCopySLA.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lb_btnCopySLA.Size = new System.Drawing.Size(57, 13);
            this.lb_btnCopySLA.TabIndex = 8;
            this.lb_btnCopySLA.Text = "Copy SLA";
            // 
            // gb_NewSLA
            // 
            this.gb_NewSLA.Controls.Add(this.cb_SLATarget);
            this.gb_NewSLA.Location = new System.Drawing.Point(13, 12);
            this.gb_NewSLA.Name = "gb_NewSLA";
            this.gb_NewSLA.Size = new System.Drawing.Size(358, 53);
            this.gb_NewSLA.TabIndex = 19;
            this.gb_NewSLA.TabStop = false;
            this.gb_NewSLA.Text = "SLA target";
            // 
            // cb_SLATarget
            // 
            this.cb_SLATarget.FormattingEnabled = true;
            this.cb_SLATarget.Location = new System.Drawing.Point(6, 19);
            this.cb_SLATarget.Name = "cb_SLATarget";
            this.cb_SLATarget.Size = new System.Drawing.Size(343, 21);
            this.cb_SLATarget.TabIndex = 1;
            this.cb_SLATarget.SelectionChangeCommitted += new System.EventHandler(this.cb_SLATarget_SelectionChangeCommitted);
            // 
            // CopySLAItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 135);
            this.Controls.Add(this.p_CopySLA);
            this.Controls.Add(this.p_CreateSLA);
            this.Controls.Add(this.gb_NewSLA);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CopySLAItems";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Copy SLA items";
            this.p_CopySLA.ResumeLayout(false);
            this.p_CopySLA.PerformLayout();
            this.p_CreateSLA.ResumeLayout(false);
            this.p_CreateSLA.PerformLayout();
            this.gb_NewSLA.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p_CopySLA;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label lb_btnCancelSLA;
        private System.Windows.Forms.Panel p_CreateSLA;
        private System.Windows.Forms.Button btn_CopySLA;
        private System.Windows.Forms.Label lb_btnCopySLA;
        private System.Windows.Forms.GroupBox gb_NewSLA;
        private System.Windows.Forms.ComboBox cb_SLATarget;
    }
}