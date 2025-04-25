namespace CloneSLAs
{
    partial class CloneSLAsControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.gb_SLAs = new System.Windows.Forms.GroupBox();
            this.tb_Description = new System.Windows.Forms.TextBox();
            this.lb_Description = new System.Windows.Forms.Label();
            this.tb_MainEntity = new System.Windows.Forms.TextBox();
            this.lb_MainEntity = new System.Windows.Forms.Label();
            this.cb_SLAs = new System.Windows.Forms.ComboBox();
            this.gb_ElementsFromSLASelected = new System.Windows.Forms.GroupBox();
            this.lv_ElementsOfSLA = new System.Windows.Forms.ListView();
            this.p_SLAs = new System.Windows.Forms.Panel();
            this.p_ElementsOfSLA = new System.Windows.Forms.Panel();
            this.p_control = new System.Windows.Forms.Panel();
            this.p_FooterRight = new System.Windows.Forms.Panel();
            this.lb_TotalItems = new System.Windows.Forms.Label();
            this.p_FooterLeft = new System.Windows.Forms.Panel();
            this.lb_Status = new System.Windows.Forms.Label();
            this.toolStripMenu.SuspendLayout();
            this.gb_SLAs.SuspendLayout();
            this.gb_ElementsFromSLASelected.SuspendLayout();
            this.p_SLAs.SuspendLayout();
            this.p_ElementsOfSLA.SuspendLayout();
            this.p_control.SuspendLayout();
            this.p_FooterRight.SuspendLayout();
            this.p_FooterLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssSeparator1});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(817, 25);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // gb_SLAs
            // 
            this.gb_SLAs.Controls.Add(this.tb_Description);
            this.gb_SLAs.Controls.Add(this.lb_Description);
            this.gb_SLAs.Controls.Add(this.tb_MainEntity);
            this.gb_SLAs.Controls.Add(this.lb_MainEntity);
            this.gb_SLAs.Controls.Add(this.cb_SLAs);
            this.gb_SLAs.Location = new System.Drawing.Point(3, 3);
            this.gb_SLAs.Name = "gb_SLAs";
            this.gb_SLAs.Size = new System.Drawing.Size(351, 176);
            this.gb_SLAs.TabIndex = 5;
            this.gb_SLAs.TabStop = false;
            this.gb_SLAs.Text = "SLAs";
            // 
            // tb_Description
            // 
            this.tb_Description.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Description.Location = new System.Drawing.Point(9, 111);
            this.tb_Description.Multiline = true;
            this.tb_Description.Name = "tb_Description";
            this.tb_Description.Size = new System.Drawing.Size(336, 54);
            this.tb_Description.TabIndex = 4;
            // 
            // lb_Description
            // 
            this.lb_Description.AutoSize = true;
            this.lb_Description.Location = new System.Drawing.Point(6, 95);
            this.lb_Description.Name = "lb_Description";
            this.lb_Description.Size = new System.Drawing.Size(60, 13);
            this.lb_Description.TabIndex = 3;
            this.lb_Description.Text = "Description";
            // 
            // tb_MainEntity
            // 
            this.tb_MainEntity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_MainEntity.Location = new System.Drawing.Point(9, 64);
            this.tb_MainEntity.Name = "tb_MainEntity";
            this.tb_MainEntity.Size = new System.Drawing.Size(336, 20);
            this.tb_MainEntity.TabIndex = 2;
            // 
            // lb_MainEntity
            // 
            this.lb_MainEntity.AutoSize = true;
            this.lb_MainEntity.Location = new System.Drawing.Point(6, 48);
            this.lb_MainEntity.Name = "lb_MainEntity";
            this.lb_MainEntity.Size = new System.Drawing.Size(58, 13);
            this.lb_MainEntity.TabIndex = 1;
            this.lb_MainEntity.Text = "Main entity";
            // 
            // cb_SLAs
            // 
            this.cb_SLAs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_SLAs.FormattingEnabled = true;
            this.cb_SLAs.Location = new System.Drawing.Point(9, 19);
            this.cb_SLAs.Name = "cb_SLAs";
            this.cb_SLAs.Size = new System.Drawing.Size(336, 21);
            this.cb_SLAs.TabIndex = 0;
            this.cb_SLAs.SelectedValueChanged += new System.EventHandler(this.cb_SLAs_SelectedValueChanged);
            // 
            // gb_ElementsFromSLASelected
            // 
            this.gb_ElementsFromSLASelected.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_ElementsFromSLASelected.Controls.Add(this.lv_ElementsOfSLA);
            this.gb_ElementsFromSLASelected.Location = new System.Drawing.Point(3, 3);
            this.gb_ElementsFromSLASelected.Name = "gb_ElementsFromSLASelected";
            this.gb_ElementsFromSLASelected.Size = new System.Drawing.Size(448, 179);
            this.gb_ElementsFromSLASelected.TabIndex = 6;
            this.gb_ElementsFromSLASelected.TabStop = false;
            this.gb_ElementsFromSLASelected.Text = "Elements of SLA";
            // 
            // lv_ElementsOfSLA
            // 
            this.lv_ElementsOfSLA.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lv_ElementsOfSLA.FullRowSelect = true;
            this.lv_ElementsOfSLA.HideSelection = false;
            this.lv_ElementsOfSLA.Location = new System.Drawing.Point(7, 20);
            this.lv_ElementsOfSLA.Name = "lv_ElementsOfSLA";
            this.lv_ElementsOfSLA.Size = new System.Drawing.Size(435, 148);
            this.lv_ElementsOfSLA.TabIndex = 0;
            this.lv_ElementsOfSLA.UseCompatibleStateImageBehavior = false;
            this.lv_ElementsOfSLA.View = System.Windows.Forms.View.Details;
            // 
            // p_SLAs
            // 
            this.p_SLAs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.p_SLAs.Controls.Add(this.gb_SLAs);
            this.p_SLAs.Location = new System.Drawing.Point(3, 3);
            this.p_SLAs.Name = "p_SLAs";
            this.p_SLAs.Size = new System.Drawing.Size(360, 185);
            this.p_SLAs.TabIndex = 7;
            // 
            // p_ElementsOfSLA
            // 
            this.p_ElementsOfSLA.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.p_ElementsOfSLA.Controls.Add(this.gb_ElementsFromSLASelected);
            this.p_ElementsOfSLA.Location = new System.Drawing.Point(360, 0);
            this.p_ElementsOfSLA.Name = "p_ElementsOfSLA";
            this.p_ElementsOfSLA.Size = new System.Drawing.Size(454, 185);
            this.p_ElementsOfSLA.TabIndex = 8;
            // 
            // p_control
            // 
            this.p_control.Controls.Add(this.p_FooterRight);
            this.p_control.Controls.Add(this.p_FooterLeft);
            this.p_control.Controls.Add(this.p_SLAs);
            this.p_control.Controls.Add(this.p_ElementsOfSLA);
            this.p_control.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_control.Location = new System.Drawing.Point(0, 25);
            this.p_control.Name = "p_control";
            this.p_control.Size = new System.Drawing.Size(817, 223);
            this.p_control.TabIndex = 9;
            // 
            // p_FooterRight
            // 
            this.p_FooterRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.p_FooterRight.Controls.Add(this.lb_TotalItems);
            this.p_FooterRight.Location = new System.Drawing.Point(366, 191);
            this.p_FooterRight.Name = "p_FooterRight";
            this.p_FooterRight.Size = new System.Drawing.Size(448, 29);
            this.p_FooterRight.TabIndex = 10;
            // 
            // lb_TotalItems
            // 
            this.lb_TotalItems.AutoSize = true;
            this.lb_TotalItems.Dock = System.Windows.Forms.DockStyle.Left;
            this.lb_TotalItems.Location = new System.Drawing.Point(0, 0);
            this.lb_TotalItems.Name = "lb_TotalItems";
            this.lb_TotalItems.Size = new System.Drawing.Size(111, 13);
            this.lb_TotalItems.TabIndex = 0;
            this.lb_TotalItems.Text = "Total elements of SLA";
            // 
            // p_FooterLeft
            // 
            this.p_FooterLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.p_FooterLeft.Controls.Add(this.lb_Status);
            this.p_FooterLeft.Location = new System.Drawing.Point(3, 191);
            this.p_FooterLeft.Name = "p_FooterLeft";
            this.p_FooterLeft.Size = new System.Drawing.Size(354, 29);
            this.p_FooterLeft.TabIndex = 9;
            // 
            // lb_Status
            // 
            this.lb_Status.AutoSize = true;
            this.lb_Status.Dock = System.Windows.Forms.DockStyle.Left;
            this.lb_Status.Location = new System.Drawing.Point(0, 0);
            this.lb_Status.Name = "lb_Status";
            this.lb_Status.Size = new System.Drawing.Size(37, 13);
            this.lb_Status.TabIndex = 1;
            this.lb_Status.Text = "Status";
            // 
            // CloneSLAsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.p_control);
            this.Controls.Add(this.toolStripMenu);
            this.Name = "CloneSLAsControl";
            this.Size = new System.Drawing.Size(817, 248);
            this.Load += new System.EventHandler(this.CloneSLAsControl_Load);
            this.Resize += new System.EventHandler(this.PluginControl_Resize);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.gb_SLAs.ResumeLayout(false);
            this.gb_SLAs.PerformLayout();
            this.gb_ElementsFromSLASelected.ResumeLayout(false);
            this.p_SLAs.ResumeLayout(false);
            this.p_ElementsOfSLA.ResumeLayout(false);
            this.p_control.ResumeLayout(false);
            this.p_FooterRight.ResumeLayout(false);
            this.p_FooterRight.PerformLayout();
            this.p_FooterLeft.ResumeLayout(false);
            this.p_FooterLeft.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private System.Windows.Forms.GroupBox gb_SLAs;
        private System.Windows.Forms.Label lb_MainEntity;
        private System.Windows.Forms.ComboBox cb_SLAs;
        private System.Windows.Forms.GroupBox gb_ElementsFromSLASelected;
        private System.Windows.Forms.Label lb_Description;
        private System.Windows.Forms.TextBox tb_MainEntity;
        private System.Windows.Forms.TextBox tb_Description;
        private System.Windows.Forms.ListView lv_ElementsOfSLA;
        private System.Windows.Forms.Panel p_SLAs;
        private System.Windows.Forms.Panel p_ElementsOfSLA;
        private System.Windows.Forms.Panel p_control;
        private System.Windows.Forms.Panel p_FooterLeft;
        private System.Windows.Forms.Panel p_FooterRight;
        private System.Windows.Forms.Label lb_TotalItems;
        private System.Windows.Forms.Label lb_Status;
    }
}
