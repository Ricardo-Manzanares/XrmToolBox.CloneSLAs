using CloneSLAs.Model;
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloneSLAs
{
    public partial class CreateSLA : Form
    {
        private Boolean copySLA = false;
        private List<MainEntity> _mainEntitys = new List<MainEntity>();
        private MainEntity _mainEntitySelected = new MainEntity();

        public CreateSLA()
        {
            InitializeComponent();
        }

        private void CreateSLA_Load(object sender, EventArgs e)
        {
            if(_mainEntitys.Count > 0)
            {
                cb_MainEntity.Items.Clear();
                cb_MainEntity.DisplayMember = "DisplayName";
                cb_MainEntity.ValueMember = "LogicalName";

                foreach (var entity in _mainEntitys)
                {
                    cb_MainEntity.Items.Add(new MainEntity() { LogicalName = entity.LogicalName, DisplayName = entity.DisplayName.ToString() });
                }

            }
            if (copySLA)
            {
                cb_MainEntity.GotFocus += (combobox, o) => { ((ComboBox)combobox).Parent.Focus(); };
                cb_MainEntity.DropDown += (combobox, o) => { ((ComboBox)combobox).DroppedDown = false; };
                cb_MainEntity.KeyDown += (combobox, o) => { o.SuppressKeyPress = true; };
                cb_MainEntity.MouseDown += (combobox, o) => { ((ComboBox)combobox).DroppedDown = false; };
                cb_MainEntity.Enter += (combobox, o) => { ((ComboBox)combobox).Parent.Focus(); };
                cb_MainEntity.Cursor = Cursors.No;

                cb_MainEntity.SelectedItem = cb_MainEntity.Items.Cast<MainEntity>().FirstOrDefault(item => item.LogicalName.Equals(_mainEntitySelected.LogicalName, StringComparison.OrdinalIgnoreCase));
            }
        }

        public string NewName
        {
            get { return tb_NewName.Text; }
            set { tb_NewName.Text = value; }
        }

        public MainEntity MainEntitySelected
        {
            get { return _mainEntitySelected; }
            set
            {
                if (value != null)
                {
                    _mainEntitySelected = value;
                }
            }
        }

        public string NewDescription
        {
            get { return tb_NewDescription.Text; }
        }

        public Boolean CopySLA
        {
            set { copySLA = value; }
        }

        public List<MainEntity> SetMainEntitys
        {
            set { _mainEntitys = value;  }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btn_CreateSLA_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        protected override void WndProc(ref Message message)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MOVE = 0xF010;

            switch (message.Msg)
            {
                case WM_SYSCOMMAND:
                    int command = message.WParam.ToInt32() & 0xfff0;
                    if (command == SC_MOVE)
                        return;
                    break;
            }

            base.WndProc(ref message);
        }

        private void cb_MainEntity_SelectedValueChanged(object sender, EventArgs e)
        {
            if(sender != null)
            {
                if (cb_MainEntity.SelectedItem != null)
                {
                    _mainEntitySelected = (MainEntity)cb_MainEntity.SelectedItem;
                }
            }
        }
    }
}
