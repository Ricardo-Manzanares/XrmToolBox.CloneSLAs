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

        public CreateSLA()
        {
            InitializeComponent();
        }

        private void CreateSLA_Load(object sender, EventArgs e)
        {
            if (copySLA)
            {
                tb_NewMainEntity.ReadOnly = true;
            }
        }

        public string NewName
        {
            get { return tb_NewName.Text; }
            set { tb_NewName.Text = value; }
        }

        public string NewMainEntity
        {
            get { return tb_NewMainEntity.Text; }
        }

        public string NewDescription
        {
            get { return tb_NewDescription.Text; }
        }

        public Boolean CopySLA
        {
            set { copySLA = value; }
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
    }
}
