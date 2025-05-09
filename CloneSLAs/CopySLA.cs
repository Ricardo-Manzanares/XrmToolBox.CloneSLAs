using CloneSLAs.Model;
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
    public partial class CopySLA : Form
    {
        private Guid SLATargetSelected;

        public CopySLA()
        {
            InitializeComponent();
        }

        private void CopySLA_Load(object sender, EventArgs e)
        {
            /*DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[] {
                    new DataColumn("Text", typeof(string)),
                    new DataColumn("Value", typeof(string)) });
            dt.Rows.Add("A", Guid.NewGuid());
            dt.Rows.Add("B", Guid.NewGuid());
            dt.Rows.Add("CASH", Guid.NewGuid());
            dt.Rows.Add("X", Guid.NewGuid());
            cb_SLATarget.DataSource = dt;
            cb_SLATarget.DisplayMember = "Text";
            cb_SLATarget.ValueMember = "Value";
            cb_SLATarget.SelectedIndex = -1;*/
        }

        public Guid GetSLATargetSelected
        {
            get { return SLATargetSelected; }
        }

        public void AddItemsToComboBox(List<SLA> items)
        {
            if (items != null)
            {
                cb_SLATarget.Items.AddRange(items.ToArray());
                cb_SLATarget.DisplayMember = "Text";
                cb_SLATarget.ValueMember = "Value";
                cb_SLATarget.SelectedIndex = -1;
            }
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btn_CopySLA_Click(object sender, EventArgs e)
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

        private void cb_SLATarget_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(cb_SLATarget.SelectedItem != null)
            {
                var itemSelected = cb_SLATarget.SelectedItem;
                SLATargetSelected = Guid.Parse(((DataRowView)cb_SLATarget.SelectedItem).Row.ItemArray[1].ToString());
            }
        }
    }
}
