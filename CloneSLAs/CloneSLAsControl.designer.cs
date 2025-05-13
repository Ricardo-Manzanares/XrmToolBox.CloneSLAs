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
            this.components = new System.ComponentModel.Container();
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.gb_SLAsSource = new System.Windows.Forms.GroupBox();
            this.tb_Description_Source = new System.Windows.Forms.TextBox();
            this.lb_Description_Source = new System.Windows.Forms.Label();
            this.tb_MainEntity_Source = new System.Windows.Forms.TextBox();
            this.lb_MainEntity_Source = new System.Windows.Forms.Label();
            this.cb_SLAs_Source = new System.Windows.Forms.ComboBox();
            this.gb_ElementsFromSLASelected_Source = new System.Windows.Forms.GroupBox();
            this.lv_ElementsOfSLA_Source = new System.Windows.Forms.ListView();
            this.p_SLAsSource = new System.Windows.Forms.Panel();
            this.p_ElementsOfSLASource = new System.Windows.Forms.Panel();
            this.p_control = new System.Windows.Forms.Panel();
            this.p_ElementsOfSLATarget = new System.Windows.Forms.Panel();
            this.gb_ElementsFromSLASelected_Target = new System.Windows.Forms.GroupBox();
            this.lv_ElementsOfSLA_Target = new System.Windows.Forms.ListView();
            this.p_SLAsTarget = new System.Windows.Forms.Panel();
            this.gb_SLAsTarget = new System.Windows.Forms.GroupBox();
            this.tb_Description_Target = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_MainEntity_Target = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_SLAs_Target = new System.Windows.Forms.ComboBox();
            this.p_Footer = new System.Windows.Forms.Panel();
            this.lb_Status = new System.Windows.Forms.Label();
            this.p_settings = new System.Windows.Forms.Panel();
            this.gb_Actions = new System.Windows.Forms.GroupBox();
            this.p_CopyElements = new System.Windows.Forms.Panel();
            this.btn_CopyElementsOfSLA = new System.Windows.Forms.Button();
            this.lb_btnCopyElementsOfSLA = new System.Windows.Forms.Label();
            this.p_CopySLA = new System.Windows.Forms.Panel();
            this.btn_CopySLA = new System.Windows.Forms.Button();
            this.lb_btnCopySLA = new System.Windows.Forms.Label();
            this.p_CreateSLA = new System.Windows.Forms.Panel();
            this.btn_CreateSLA = new System.Windows.Forms.Button();
            this.lb_btnCreateSLA = new System.Windows.Forms.Label();
            this.gb_environments = new System.Windows.Forms.GroupBox();
            this.p_environmentSources = new System.Windows.Forms.Panel();
            this.l_environmentSourceValue = new System.Windows.Forms.Label();
            this.l_environmentSource = new System.Windows.Forms.Label();
            this.l_environmentTargetValue = new System.Windows.Forms.Label();
            this.bt_SelectTarget = new System.Windows.Forms.Button();
            this.timer_Status = new System.Windows.Forms.Timer(this.components);
            this.toolStripMenu.SuspendLayout();
            this.gb_SLAsSource.SuspendLayout();
            this.gb_ElementsFromSLASelected_Source.SuspendLayout();
            this.p_SLAsSource.SuspendLayout();
            this.p_ElementsOfSLASource.SuspendLayout();
            this.p_control.SuspendLayout();
            this.p_ElementsOfSLATarget.SuspendLayout();
            this.gb_ElementsFromSLASelected_Target.SuspendLayout();
            this.p_SLAsTarget.SuspendLayout();
            this.gb_SLAsTarget.SuspendLayout();
            this.p_Footer.SuspendLayout();
            this.p_settings.SuspendLayout();
            this.gb_Actions.SuspendLayout();
            this.p_CopyElements.SuspendLayout();
            this.p_CopySLA.SuspendLayout();
            this.p_CreateSLA.SuspendLayout();
            this.gb_environments.SuspendLayout();
            this.p_environmentSources.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssSeparator1});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(1351, 25);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // gb_SLAsSource
            // 
            this.gb_SLAsSource.Controls.Add(this.tb_Description_Source);
            this.gb_SLAsSource.Controls.Add(this.lb_Description_Source);
            this.gb_SLAsSource.Controls.Add(this.tb_MainEntity_Source);
            this.gb_SLAsSource.Controls.Add(this.lb_MainEntity_Source);
            this.gb_SLAsSource.Controls.Add(this.cb_SLAs_Source);
            this.gb_SLAsSource.Location = new System.Drawing.Point(3, 0);
            this.gb_SLAsSource.Name = "gb_SLAsSource";
            this.gb_SLAsSource.Size = new System.Drawing.Size(358, 174);
            this.gb_SLAsSource.TabIndex = 5;
            this.gb_SLAsSource.TabStop = false;
            this.gb_SLAsSource.Text = "SLAs source";
            // 
            // tb_Description_Source
            // 
            this.tb_Description_Source.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Description_Source.BackColor = System.Drawing.SystemColors.Window;
            this.tb_Description_Source.Cursor = System.Windows.Forms.Cursors.No;
            this.tb_Description_Source.Location = new System.Drawing.Point(9, 111);
            this.tb_Description_Source.Multiline = true;
            this.tb_Description_Source.Name = "tb_Description_Source";
            this.tb_Description_Source.ReadOnly = true;
            this.tb_Description_Source.Size = new System.Drawing.Size(343, 54);
            this.tb_Description_Source.TabIndex = 4;
            // 
            // lb_Description_Source
            // 
            this.lb_Description_Source.AutoSize = true;
            this.lb_Description_Source.Location = new System.Drawing.Point(6, 95);
            this.lb_Description_Source.Name = "lb_Description_Source";
            this.lb_Description_Source.Size = new System.Drawing.Size(60, 13);
            this.lb_Description_Source.TabIndex = 3;
            this.lb_Description_Source.Text = "Description";
            // 
            // tb_MainEntity_Source
            // 
            this.tb_MainEntity_Source.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_MainEntity_Source.BackColor = System.Drawing.SystemColors.Window;
            this.tb_MainEntity_Source.Cursor = System.Windows.Forms.Cursors.No;
            this.tb_MainEntity_Source.Location = new System.Drawing.Point(9, 64);
            this.tb_MainEntity_Source.Name = "tb_MainEntity_Source";
            this.tb_MainEntity_Source.ReadOnly = true;
            this.tb_MainEntity_Source.Size = new System.Drawing.Size(343, 20);
            this.tb_MainEntity_Source.TabIndex = 2;
            // 
            // lb_MainEntity_Source
            // 
            this.lb_MainEntity_Source.AutoSize = true;
            this.lb_MainEntity_Source.Location = new System.Drawing.Point(6, 48);
            this.lb_MainEntity_Source.Name = "lb_MainEntity_Source";
            this.lb_MainEntity_Source.Size = new System.Drawing.Size(58, 13);
            this.lb_MainEntity_Source.TabIndex = 1;
            this.lb_MainEntity_Source.Text = "Main entity";
            // 
            // cb_SLAs_Source
            // 
            this.cb_SLAs_Source.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_SLAs_Source.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_SLAs_Source.FormattingEnabled = true;
            this.cb_SLAs_Source.Location = new System.Drawing.Point(9, 19);
            this.cb_SLAs_Source.Name = "cb_SLAs_Source";
            this.cb_SLAs_Source.Size = new System.Drawing.Size(343, 21);
            this.cb_SLAs_Source.TabIndex = 0;
            this.cb_SLAs_Source.SelectedValueChanged += new System.EventHandler(this.cb_SLAs_SelectedValueChanged);
            // 
            // gb_ElementsFromSLASelected_Source
            // 
            this.gb_ElementsFromSLASelected_Source.Controls.Add(this.lv_ElementsOfSLA_Source);
            this.gb_ElementsFromSLASelected_Source.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_ElementsFromSLASelected_Source.Location = new System.Drawing.Point(0, 0);
            this.gb_ElementsFromSLASelected_Source.Name = "gb_ElementsFromSLASelected_Source";
            this.gb_ElementsFromSLASelected_Source.Size = new System.Drawing.Size(979, 262);
            this.gb_ElementsFromSLASelected_Source.TabIndex = 6;
            this.gb_ElementsFromSLASelected_Source.TabStop = false;
            this.gb_ElementsFromSLASelected_Source.Text = "Items of SLA source selected";
            // 
            // lv_ElementsOfSLA_Source
            // 
            this.lv_ElementsOfSLA_Source.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lv_ElementsOfSLA_Source.FullRowSelect = true;
            this.lv_ElementsOfSLA_Source.HideSelection = false;
            this.lv_ElementsOfSLA_Source.Location = new System.Drawing.Point(6, 20);
            this.lv_ElementsOfSLA_Source.Name = "lv_ElementsOfSLA_Source";
            this.lv_ElementsOfSLA_Source.OwnerDraw = true;
            this.lv_ElementsOfSLA_Source.Size = new System.Drawing.Size(967, 236);
            this.lv_ElementsOfSLA_Source.TabIndex = 0;
            this.lv_ElementsOfSLA_Source.UseCompatibleStateImageBehavior = false;
            this.lv_ElementsOfSLA_Source.View = System.Windows.Forms.View.Details;
            this.lv_ElementsOfSLA_Source.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lv_ElementsOfSLA_DrawColumnHeader);
            this.lv_ElementsOfSLA_Source.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lv_ElementsOfSLA_Source_DrawSubItem);
            // 
            // p_SLAsSource
            // 
            this.p_SLAsSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.p_SLAsSource.Controls.Add(this.gb_SLAsSource);
            this.p_SLAsSource.Location = new System.Drawing.Point(3, 80);
            this.p_SLAsSource.Name = "p_SLAsSource";
            this.p_SLAsSource.Size = new System.Drawing.Size(366, 262);
            this.p_SLAsSource.TabIndex = 7;
            // 
            // p_ElementsOfSLASource
            // 
            this.p_ElementsOfSLASource.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.p_ElementsOfSLASource.Controls.Add(this.gb_ElementsFromSLASelected_Source);
            this.p_ElementsOfSLASource.Location = new System.Drawing.Point(369, 80);
            this.p_ElementsOfSLASource.Name = "p_ElementsOfSLASource";
            this.p_ElementsOfSLASource.Size = new System.Drawing.Size(979, 262);
            this.p_ElementsOfSLASource.TabIndex = 8;
            // 
            // p_control
            // 
            this.p_control.Controls.Add(this.p_ElementsOfSLATarget);
            this.p_control.Controls.Add(this.p_SLAsTarget);
            this.p_control.Controls.Add(this.p_Footer);
            this.p_control.Controls.Add(this.p_SLAsSource);
            this.p_control.Controls.Add(this.p_ElementsOfSLASource);
            this.p_control.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_control.Location = new System.Drawing.Point(0, 25);
            this.p_control.Name = "p_control";
            this.p_control.Size = new System.Drawing.Size(1351, 670);
            this.p_control.TabIndex = 9;
            // 
            // p_ElementsOfSLATarget
            // 
            this.p_ElementsOfSLATarget.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.p_ElementsOfSLATarget.Controls.Add(this.gb_ElementsFromSLASelected_Target);
            this.p_ElementsOfSLATarget.Location = new System.Drawing.Point(369, 345);
            this.p_ElementsOfSLATarget.Name = "p_ElementsOfSLATarget";
            this.p_ElementsOfSLATarget.Size = new System.Drawing.Size(979, 297);
            this.p_ElementsOfSLATarget.TabIndex = 9;
            this.p_ElementsOfSLATarget.Visible = false;
            // 
            // gb_ElementsFromSLASelected_Target
            // 
            this.gb_ElementsFromSLASelected_Target.Controls.Add(this.lv_ElementsOfSLA_Target);
            this.gb_ElementsFromSLASelected_Target.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_ElementsFromSLASelected_Target.Location = new System.Drawing.Point(0, 0);
            this.gb_ElementsFromSLASelected_Target.Name = "gb_ElementsFromSLASelected_Target";
            this.gb_ElementsFromSLASelected_Target.Size = new System.Drawing.Size(979, 297);
            this.gb_ElementsFromSLASelected_Target.TabIndex = 6;
            this.gb_ElementsFromSLASelected_Target.TabStop = false;
            this.gb_ElementsFromSLASelected_Target.Text = "Items of SLA target selected";
            // 
            // lv_ElementsOfSLA_Target
            // 
            this.lv_ElementsOfSLA_Target.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lv_ElementsOfSLA_Target.CheckBoxes = true;
            this.lv_ElementsOfSLA_Target.FullRowSelect = true;
            this.lv_ElementsOfSLA_Target.HideSelection = false;
            this.lv_ElementsOfSLA_Target.Location = new System.Drawing.Point(12, 19);
            this.lv_ElementsOfSLA_Target.Name = "lv_ElementsOfSLA_Target";
            this.lv_ElementsOfSLA_Target.OwnerDraw = true;
            this.lv_ElementsOfSLA_Target.Size = new System.Drawing.Size(961, 272);
            this.lv_ElementsOfSLA_Target.TabIndex = 0;
            this.lv_ElementsOfSLA_Target.UseCompatibleStateImageBehavior = false;
            this.lv_ElementsOfSLA_Target.View = System.Windows.Forms.View.Details;
            this.lv_ElementsOfSLA_Target.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lv_ElementsOfSLA_DrawColumnHeader);
            this.lv_ElementsOfSLA_Target.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lv_ElementsOfSLA_Target_DrawSubItem);
            // 
            // p_SLAsTarget
            // 
            this.p_SLAsTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.p_SLAsTarget.Controls.Add(this.gb_SLAsTarget);
            this.p_SLAsTarget.Location = new System.Drawing.Point(3, 345);
            this.p_SLAsTarget.Name = "p_SLAsTarget";
            this.p_SLAsTarget.Size = new System.Drawing.Size(366, 297);
            this.p_SLAsTarget.TabIndex = 8;
            this.p_SLAsTarget.Visible = false;
            // 
            // gb_SLAsTarget
            // 
            this.gb_SLAsTarget.Controls.Add(this.tb_Description_Target);
            this.gb_SLAsTarget.Controls.Add(this.label1);
            this.gb_SLAsTarget.Controls.Add(this.tb_MainEntity_Target);
            this.gb_SLAsTarget.Controls.Add(this.label2);
            this.gb_SLAsTarget.Controls.Add(this.cb_SLAs_Target);
            this.gb_SLAsTarget.Location = new System.Drawing.Point(3, 0);
            this.gb_SLAsTarget.Name = "gb_SLAsTarget";
            this.gb_SLAsTarget.Size = new System.Drawing.Size(358, 174);
            this.gb_SLAsTarget.TabIndex = 5;
            this.gb_SLAsTarget.TabStop = false;
            this.gb_SLAsTarget.Text = "SLAs target";
            // 
            // tb_Description_Target
            // 
            this.tb_Description_Target.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Description_Target.BackColor = System.Drawing.SystemColors.Window;
            this.tb_Description_Target.Cursor = System.Windows.Forms.Cursors.No;
            this.tb_Description_Target.Location = new System.Drawing.Point(9, 111);
            this.tb_Description_Target.Multiline = true;
            this.tb_Description_Target.Name = "tb_Description_Target";
            this.tb_Description_Target.ReadOnly = true;
            this.tb_Description_Target.Size = new System.Drawing.Size(343, 54);
            this.tb_Description_Target.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Description";
            // 
            // tb_MainEntity_Target
            // 
            this.tb_MainEntity_Target.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_MainEntity_Target.BackColor = System.Drawing.SystemColors.Window;
            this.tb_MainEntity_Target.Cursor = System.Windows.Forms.Cursors.No;
            this.tb_MainEntity_Target.Location = new System.Drawing.Point(9, 64);
            this.tb_MainEntity_Target.Name = "tb_MainEntity_Target";
            this.tb_MainEntity_Target.ReadOnly = true;
            this.tb_MainEntity_Target.Size = new System.Drawing.Size(343, 20);
            this.tb_MainEntity_Target.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Main entity";
            // 
            // cb_SLAs_Target
            // 
            this.cb_SLAs_Target.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_SLAs_Target.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_SLAs_Target.FormattingEnabled = true;
            this.cb_SLAs_Target.Location = new System.Drawing.Point(9, 19);
            this.cb_SLAs_Target.Name = "cb_SLAs_Target";
            this.cb_SLAs_Target.Size = new System.Drawing.Size(343, 21);
            this.cb_SLAs_Target.TabIndex = 0;
            // 
            // p_Footer
            // 
            this.p_Footer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.p_Footer.Controls.Add(this.lb_Status);
            this.p_Footer.Location = new System.Drawing.Point(3, 648);
            this.p_Footer.Name = "p_Footer";
            this.p_Footer.Size = new System.Drawing.Size(1345, 19);
            this.p_Footer.TabIndex = 9;
            // 
            // lb_Status
            // 
            this.lb_Status.AutoSize = true;
            this.lb_Status.Location = new System.Drawing.Point(1, 3);
            this.lb_Status.Name = "lb_Status";
            this.lb_Status.Size = new System.Drawing.Size(0, 13);
            this.lb_Status.TabIndex = 1;
            // 
            // p_settings
            // 
            this.p_settings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.p_settings.Controls.Add(this.gb_Actions);
            this.p_settings.Controls.Add(this.gb_environments);
            this.p_settings.Location = new System.Drawing.Point(3, 25);
            this.p_settings.Name = "p_settings";
            this.p_settings.Size = new System.Drawing.Size(1345, 77);
            this.p_settings.TabIndex = 10;
            // 
            // gb_Actions
            // 
            this.gb_Actions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_Actions.Controls.Add(this.p_CopyElements);
            this.gb_Actions.Controls.Add(this.p_CopySLA);
            this.gb_Actions.Controls.Add(this.p_CreateSLA);
            this.gb_Actions.Location = new System.Drawing.Point(366, 3);
            this.gb_Actions.Margin = new System.Windows.Forms.Padding(0);
            this.gb_Actions.Name = "gb_Actions";
            this.gb_Actions.Size = new System.Drawing.Size(979, 71);
            this.gb_Actions.TabIndex = 6;
            this.gb_Actions.TabStop = false;
            this.gb_Actions.Text = "Actions";
            // 
            // p_CopyElements
            // 
            this.p_CopyElements.Controls.Add(this.btn_CopyElementsOfSLA);
            this.p_CopyElements.Controls.Add(this.lb_btnCopyElementsOfSLA);
            this.p_CopyElements.Location = new System.Drawing.Point(156, 12);
            this.p_CopyElements.Name = "p_CopyElements";
            this.p_CopyElements.Size = new System.Drawing.Size(87, 56);
            this.p_CopyElements.TabIndex = 17;
            // 
            // btn_CopyElementsOfSLA
            // 
            this.btn_CopyElementsOfSLA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_CopyElementsOfSLA.Image = global::CloneSLAs.Properties.Resources.copy_multiple;
            this.btn_CopyElementsOfSLA.Location = new System.Drawing.Point(21, 0);
            this.btn_CopyElementsOfSLA.Name = "btn_CopyElementsOfSLA";
            this.btn_CopyElementsOfSLA.Size = new System.Drawing.Size(40, 40);
            this.btn_CopyElementsOfSLA.TabIndex = 9;
            this.btn_CopyElementsOfSLA.UseVisualStyleBackColor = true;
            this.btn_CopyElementsOfSLA.Click += new System.EventHandler(this.btn_CopyItemsOfSLA_Click);
            // 
            // lb_btnCopyElementsOfSLA
            // 
            this.lb_btnCopyElementsOfSLA.AutoSize = true;
            this.lb_btnCopyElementsOfSLA.Location = new System.Drawing.Point(2, 40);
            this.lb_btnCopyElementsOfSLA.Name = "lb_btnCopyElementsOfSLA";
            this.lb_btnCopyElementsOfSLA.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lb_btnCopyElementsOfSLA.Size = new System.Drawing.Size(84, 13);
            this.lb_btnCopyElementsOfSLA.TabIndex = 10;
            this.lb_btnCopyElementsOfSLA.Text = "Copy SLA items";
            // 
            // p_CopySLA
            // 
            this.p_CopySLA.Controls.Add(this.btn_CopySLA);
            this.p_CopySLA.Controls.Add(this.lb_btnCopySLA);
            this.p_CopySLA.Location = new System.Drawing.Point(81, 12);
            this.p_CopySLA.Name = "p_CopySLA";
            this.p_CopySLA.Size = new System.Drawing.Size(69, 56);
            this.p_CopySLA.TabIndex = 16;
            // 
            // btn_CopySLA
            // 
            this.btn_CopySLA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_CopySLA.Image = global::CloneSLAs.Properties.Resources.copy;
            this.btn_CopySLA.Location = new System.Drawing.Point(14, 0);
            this.btn_CopySLA.Name = "btn_CopySLA";
            this.btn_CopySLA.Size = new System.Drawing.Size(40, 40);
            this.btn_CopySLA.TabIndex = 13;
            this.btn_CopySLA.UseVisualStyleBackColor = true;
            this.btn_CopySLA.Click += new System.EventHandler(this.btn_CopySLA_Click);
            // 
            // lb_btnCopySLA
            // 
            this.lb_btnCopySLA.AutoSize = true;
            this.lb_btnCopySLA.Location = new System.Drawing.Point(6, 40);
            this.lb_btnCopySLA.Name = "lb_btnCopySLA";
            this.lb_btnCopySLA.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lb_btnCopySLA.Size = new System.Drawing.Size(57, 13);
            this.lb_btnCopySLA.TabIndex = 14;
            this.lb_btnCopySLA.Text = "Copy SLA";
            // 
            // p_CreateSLA
            // 
            this.p_CreateSLA.Controls.Add(this.btn_CreateSLA);
            this.p_CreateSLA.Controls.Add(this.lb_btnCreateSLA);
            this.p_CreateSLA.Location = new System.Drawing.Point(6, 12);
            this.p_CreateSLA.Name = "p_CreateSLA";
            this.p_CreateSLA.Size = new System.Drawing.Size(69, 56);
            this.p_CreateSLA.TabIndex = 15;
            // 
            // btn_CreateSLA
            // 
            this.btn_CreateSLA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_CreateSLA.Image = global::CloneSLAs.Properties.Resources.plus;
            this.btn_CreateSLA.Location = new System.Drawing.Point(14, 0);
            this.btn_CreateSLA.Name = "btn_CreateSLA";
            this.btn_CreateSLA.Size = new System.Drawing.Size(40, 40);
            this.btn_CreateSLA.TabIndex = 0;
            this.btn_CreateSLA.UseVisualStyleBackColor = true;
            this.btn_CreateSLA.Click += new System.EventHandler(this.btn_CreateSLA_Click);
            // 
            // lb_btnCreateSLA
            // 
            this.lb_btnCreateSLA.AutoSize = true;
            this.lb_btnCreateSLA.Location = new System.Drawing.Point(1, 40);
            this.lb_btnCreateSLA.Name = "lb_btnCreateSLA";
            this.lb_btnCreateSLA.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lb_btnCreateSLA.Size = new System.Drawing.Size(64, 13);
            this.lb_btnCreateSLA.TabIndex = 8;
            this.lb_btnCreateSLA.Text = "Create SLA";
            // 
            // gb_environments
            // 
            this.gb_environments.Controls.Add(this.p_environmentSources);
            this.gb_environments.Location = new System.Drawing.Point(3, 3);
            this.gb_environments.Margin = new System.Windows.Forms.Padding(0);
            this.gb_environments.Name = "gb_environments";
            this.gb_environments.Size = new System.Drawing.Size(358, 71);
            this.gb_environments.TabIndex = 0;
            this.gb_environments.TabStop = false;
            this.gb_environments.Text = "Environments";
            // 
            // p_environmentSources
            // 
            this.p_environmentSources.Controls.Add(this.l_environmentSourceValue);
            this.p_environmentSources.Controls.Add(this.l_environmentSource);
            this.p_environmentSources.Controls.Add(this.l_environmentTargetValue);
            this.p_environmentSources.Controls.Add(this.bt_SelectTarget);
            this.p_environmentSources.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_environmentSources.Location = new System.Drawing.Point(3, 16);
            this.p_environmentSources.Name = "p_environmentSources";
            this.p_environmentSources.Size = new System.Drawing.Size(352, 52);
            this.p_environmentSources.TabIndex = 6;
            // 
            // l_environmentSourceValue
            // 
            this.l_environmentSourceValue.AutoSize = true;
            this.l_environmentSourceValue.ForeColor = System.Drawing.Color.Green;
            this.l_environmentSourceValue.Location = new System.Drawing.Point(84, 0);
            this.l_environmentSourceValue.Name = "l_environmentSourceValue";
            this.l_environmentSourceValue.Size = new System.Drawing.Size(10, 13);
            this.l_environmentSourceValue.TabIndex = 6;
            this.l_environmentSourceValue.Text = "-";
            // 
            // l_environmentSource
            // 
            this.l_environmentSource.AutoSize = true;
            this.l_environmentSource.Location = new System.Drawing.Point(3, 0);
            this.l_environmentSource.Name = "l_environmentSource";
            this.l_environmentSource.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.l_environmentSource.Size = new System.Drawing.Size(44, 13);
            this.l_environmentSource.TabIndex = 0;
            this.l_environmentSource.Text = "Source";
            // 
            // l_environmentTargetValue
            // 
            this.l_environmentTargetValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.l_environmentTargetValue.AutoSize = true;
            this.l_environmentTargetValue.ForeColor = System.Drawing.Color.Red;
            this.l_environmentTargetValue.Location = new System.Drawing.Point(84, 23);
            this.l_environmentTargetValue.Name = "l_environmentTargetValue";
            this.l_environmentTargetValue.Size = new System.Drawing.Size(89, 13);
            this.l_environmentTargetValue.TabIndex = 7;
            this.l_environmentTargetValue.Text = "Pending selected";
            // 
            // bt_SelectTarget
            // 
            this.bt_SelectTarget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_SelectTarget.Location = new System.Drawing.Point(3, 18);
            this.bt_SelectTarget.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.bt_SelectTarget.Name = "bt_SelectTarget";
            this.bt_SelectTarget.Size = new System.Drawing.Size(75, 23);
            this.bt_SelectTarget.TabIndex = 6;
            this.bt_SelectTarget.Text = "Select target";
            this.bt_SelectTarget.UseVisualStyleBackColor = true;
            this.bt_SelectTarget.Click += new System.EventHandler(this.bt_SelectTarget_Click);
            // 
            // CloneSLAsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.p_settings);
            this.Controls.Add(this.p_control);
            this.Controls.Add(this.toolStripMenu);
            this.Enabled = false;
            this.Name = "CloneSLAsControl";
            this.Size = new System.Drawing.Size(1351, 695);
            this.Load += new System.EventHandler(this.CloneSLAsControl_Load);
            this.Resize += new System.EventHandler(this.PluginControl_Resize);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.gb_SLAsSource.ResumeLayout(false);
            this.gb_SLAsSource.PerformLayout();
            this.gb_ElementsFromSLASelected_Source.ResumeLayout(false);
            this.p_SLAsSource.ResumeLayout(false);
            this.p_ElementsOfSLASource.ResumeLayout(false);
            this.p_control.ResumeLayout(false);
            this.p_ElementsOfSLATarget.ResumeLayout(false);
            this.gb_ElementsFromSLASelected_Target.ResumeLayout(false);
            this.p_SLAsTarget.ResumeLayout(false);
            this.gb_SLAsTarget.ResumeLayout(false);
            this.gb_SLAsTarget.PerformLayout();
            this.p_Footer.ResumeLayout(false);
            this.p_Footer.PerformLayout();
            this.p_settings.ResumeLayout(false);
            this.gb_Actions.ResumeLayout(false);
            this.p_CopyElements.ResumeLayout(false);
            this.p_CopyElements.PerformLayout();
            this.p_CopySLA.ResumeLayout(false);
            this.p_CopySLA.PerformLayout();
            this.p_CreateSLA.ResumeLayout(false);
            this.p_CreateSLA.PerformLayout();
            this.gb_environments.ResumeLayout(false);
            this.p_environmentSources.ResumeLayout(false);
            this.p_environmentSources.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private System.Windows.Forms.GroupBox gb_SLAsSource;
        private System.Windows.Forms.Label lb_MainEntity_Source;
        private System.Windows.Forms.ComboBox cb_SLAs_Source;
        private System.Windows.Forms.GroupBox gb_ElementsFromSLASelected_Source;
        private System.Windows.Forms.Label lb_Description_Source;
        private System.Windows.Forms.TextBox tb_MainEntity_Source;
        private System.Windows.Forms.TextBox tb_Description_Source;
        private System.Windows.Forms.ListView lv_ElementsOfSLA_Source;
        private System.Windows.Forms.Panel p_SLAsSource;
        private System.Windows.Forms.Panel p_ElementsOfSLASource;
        private System.Windows.Forms.Panel p_control;
        private System.Windows.Forms.Panel p_Footer;
        private System.Windows.Forms.Label lb_Status;
        private System.Windows.Forms.Panel p_settings;
        private System.Windows.Forms.GroupBox gb_Actions;
        private System.Windows.Forms.GroupBox gb_environments;
        private System.Windows.Forms.Panel p_environmentSources;
        private System.Windows.Forms.Label l_environmentSourceValue;
        private System.Windows.Forms.Label l_environmentSource;
        private System.Windows.Forms.Label l_environmentTargetValue;
        private System.Windows.Forms.Button bt_SelectTarget;
        private System.Windows.Forms.Panel p_SLAsTarget;
        private System.Windows.Forms.GroupBox gb_SLAsTarget;
        private System.Windows.Forms.TextBox tb_Description_Target;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_MainEntity_Target;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_SLAs_Target;
        private System.Windows.Forms.Panel p_ElementsOfSLATarget;
        private System.Windows.Forms.GroupBox gb_ElementsFromSLASelected_Target;
        private System.Windows.Forms.ListView lv_ElementsOfSLA_Target;
        private System.Windows.Forms.Button btn_CreateSLA;
        private System.Windows.Forms.Label lb_btnCreateSLA;
        private System.Windows.Forms.Label lb_btnCopyElementsOfSLA;
        private System.Windows.Forms.Button btn_CopyElementsOfSLA;
        private System.Windows.Forms.Label lb_btnCopySLA;
        private System.Windows.Forms.Button btn_CopySLA;
        private System.Windows.Forms.Panel p_CopyElements;
        private System.Windows.Forms.Panel p_CopySLA;
        private System.Windows.Forms.Panel p_CreateSLA;
        private System.Windows.Forms.Timer timer_Status;
    }
}
