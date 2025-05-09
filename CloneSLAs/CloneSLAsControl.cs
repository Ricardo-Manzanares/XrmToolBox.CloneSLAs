using CloneSLAs.Model;
using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using XrmToolBox.Extensibility;

namespace CloneSLAs
{
    public partial class CloneSLAsControl : MultipleConnectionsPluginControlBase
    {
        private Settings mySettings;
        private IOrganizationService _targetService;
        private ConnectionDetail _targetConnectionDetail;

        private List<ListViewItem> _sourceItemsOfSLA = new List<ListViewItem>();
        private List<Entity> _slas = new List<Entity>();
        private List<Entity> _itemsOfsla_Source = new List<Entity>();
        private Entity _slaSelected_Source = new Entity();

        public CloneSLAsControl()
        {
            InitializeComponent();
        }

        private void CloneSLAsControl_Load(object sender, EventArgs e)
        {
            //ShowInfoNotification("This is a notification that can lead to XrmToolBox repository", new Uri("https://github.com/MscrmTools/XrmToolBox"));

            // Loads or creates the settings for the plugin
            if (!SettingsManager.Instance.TryLoad(GetType(), out mySettings))
            {
                mySettings = new Settings();

                Prepare();
                ExecuteMethod(GetSLAs_Source);
                LogWarning("Settings not found => a new settings file has been created!");
                //Prevent focus on the text box
                tb_MainEntity_Source.GotFocus += (textBox, o) => { ((TextBox)textBox).Parent.Focus(); };
                tb_MainEntity_Target.GotFocus += (textBox, o) => { ((TextBox)textBox).Parent.Focus(); };
            }
            else
            {
                LogInfo("Settings found and loaded");
            }
        }

        private void GetSLAs_Source()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Getting SLAs source",
                Work = (worker, args) =>
                {
                    args.Result = Service.RetrieveMultiple(new QueryExpression("sla")
                    {
                        ColumnSet = new ColumnSet("name", "objecttypecode", "description", "statuscode", "statecode"),
                    });
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    var result = args.Result as EntityCollection;
                    if (result != null)
                    {
                        cb_SLAs_Source.Items.Clear();
                        cb_SLAs_Source.DisplayMember = "Text";
                        cb_SLAs_Source.ValueMember = "Value";
                        foreach (var entity in result.Entities)
                        {
                            _slas.Add(entity);
                            cb_SLAs_Source.Items.Add(new SLA() { Text = entity.GetAttributeValue<string>("name"), Value = entity.Id, MainEntity = entity.FormattedValues["objecttypecode"].ToString() } );
                        }
                        //MessageBox.Show($"Found {result.Entities.Count} accounts");
                    }
                }
            });
        }

        private void GetElementsOfSLA_Source()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Getting Elements of SLA source",
                Work = (worker, args) =>
                {
                    args.Result = Service.RetrieveMultiple(new QueryExpression("slaitem")
                    {
                        ColumnSet = new ColumnSet(true),
                    });
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    var result = args.Result as EntityCollection;
                    if (result != null)
                    {
                        _itemsOfsla_Source.Clear();
                        _sourceItemsOfSLA.Clear();                       

                        foreach (var entity in result.Entities)
                        {
                            _itemsOfsla_Source.Add(entity);
                            _sourceItemsOfSLA.Add(new ListViewItem(new string[]
                            {
                               entity.GetAttributeValue<string>("name"),
                               _slaSelected_Source.GetAttributeValue<string>("name"),
                               entity.GetAttributeValue<EntityReference>("msdyn_slakpiid").Name,
                               entity.GetAttributeValue<int>("warnafter").ToString(),
                               entity.GetAttributeValue<int>("failureafter").ToString(),
                               _slaSelected_Source.FormattedValues["statuscode"],
                               _slaSelected_Source.FormattedValues["statecode"]
                            }));
                        }

                        lv_ElementsOfSLA_Source.Items.Clear();
                        lv_ElementsOfSLA_Source.Items.AddRange(_sourceItemsOfSLA.ToArray());
                        lv_ElementsOfSLA_Source.Items.Cast<ListViewItem>().All(k => k.Checked = false);
                        gb_ElementsFromSLASelected_Source.Text += " (" + result.Entities.Count.ToString() + ")";
                    }
                }
            });
        }

        private void PluginControl_Resize(object sender, EventArgs e)
        {
            int h = (this.ParentForm.Height / 2) - p_settings.Height;
            //lb_Status.Text = "Status: " + h + "-" + p_FooterRight.Location.Y;

            if(_targetService != null)
            {
                p_SLAsSource.Height = h;
                p_ElementsOfSLASource.Height = h;
                p_SLAsTarget.Height = h;
                p_ElementsOfSLATarget.Height = h;
                p_ElementsOfSLATarget.Location = new Point(p_ElementsOfSLATarget.Location.X, p_ElementsOfSLASource.Location.Y + p_ElementsOfSLASource.Height + 10);
                p_SLAsTarget.Visible = true;
                p_ElementsOfSLATarget.Visible = true;
                p_SLAsTarget.Location = new Point(p_SLAsTarget.Location.X, p_ElementsOfSLATarget.Location.Y);
            }
            else
            {
                p_SLAsTarget.Visible = false;
                p_ElementsOfSLATarget.Visible = false;
                int sizeHeight = (this.ParentForm.Height - p_settings.Height - p_Footer.Height) - 40;
                p_SLAsSource.Height = sizeHeight;
                p_ElementsOfSLASource.Height = (this.ParentForm.Height - p_settings.Height - p_Footer.Height) - 40;
            }
        }

        private void Prepare()
        {
            if (ConnectionDetail != null)
            {
                l_environmentSourceValue.Text = ConnectionDetail.ConnectionName;
            }
            else
            {
                l_environmentSourceValue.Text = "Pending selected";
                l_environmentSourceValue.ForeColor = Color.Red;
            }

            //ConfigureGridElementsOfSLAs Source
            _sourceItemsOfSLA = new List<ListViewItem>();

            lv_ElementsOfSLA_Source.Columns.Clear();
            lv_ElementsOfSLA_Source.Columns.Add("Name", 150);
            lv_ElementsOfSLA_Source.Columns.Add("SLA", 80);
            lv_ElementsOfSLA_Source.Columns.Add("KPI of SLA", 150);
            lv_ElementsOfSLA_Source.Columns.Add("Warning after", 100);
            lv_ElementsOfSLA_Source.Columns.Add("Error after", 100);
            lv_ElementsOfSLA_Source.Columns.Add("Status (SLA)", 100);
            lv_ElementsOfSLA_Source.Columns.Add("Reason for state (SLA)", 100);
        }

        private int GetVScrollBarWidth()
        {
            return SystemInformation.VerticalScrollBarWidth;
        }

        /// <summary>
        /// This event occurs when the plugin is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloneSLAsControl_OnCloseTool(object sender, EventArgs e)
        {
            // Before leaving, save the settings
            SettingsManager.Instance.Save(GetType(), mySettings);
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            if (mySettings != null && detail != null)
            {
                mySettings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
                LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);
                l_environmentSourceValue.ForeColor = Color.Green;
                Prepare();
            }
        }

        private void bt_SelectTarget_Click(object sender, EventArgs e)
        {
            AddAdditionalOrganization();
        }

        private void cb_SLAs_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cb_SLAs_Source.SelectedItem != null)
            {
                var selectedSLA = cb_SLAs_Source.SelectedItem;
                var selectedSLAId = ((dynamic)selectedSLA).Value;
                var selectedSLAName = ((dynamic)selectedSLA).Text;
                _slaSelected_Source = _slas.FirstOrDefault(s => s.Id == selectedSLAId);
                if(_slaSelected_Source != null)
                {
                    tb_MainEntity_Source.Text = _slaSelected_Source.FormattedValues["objecttypecode"].ToString();
                    tb_Description_Source.Text = _slaSelected_Source.GetAttributeValue<string>("description");

                    ExecuteMethod(GetElementsOfSLA_Source);
                }
            }
        }

        private void llv_ElementsOfSLA_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void lv_ElementsOfSLA_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {

        }

        private void lv_ElementsOfSLA_ItemChecked(object sender, ItemCheckedEventArgs e)
        {

        }

        private void llv_ElementsOfSLA_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lv_ElementsOfSLA_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if (e.Item.Selected)
            {
                e.Graphics.FillRectangle(Brushes.White, e.Bounds);

                // Flags corregidos
                TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding | TextFormatFlags.NoPrefix | TextFormatFlags.GlyphOverhangPadding | TextFormatFlags.PreserveGraphicsClipping;
                int leftPadding = 6;

                // Luego dibujamos el texto desplazado
                Rectangle textBounds = new Rectangle(
                    e.Bounds.X + leftPadding, // después del checkbox
                    e.Bounds.Y,
                    e.Bounds.Width - (leftPadding),
                    e.Bounds.Height);

                if (e.ColumnIndex == 0 && lv_ElementsOfSLA_Source.CheckBoxes)
                {
                    leftPadding -= 2;

                    Rectangle adjustedBounds = new Rectangle(e.Bounds.X + leftPadding, e.Bounds.Y + 2, e.Bounds.Width - leftPadding, e.Bounds.Height);

                    CheckBoxState state = e.Item.Checked ? CheckBoxState.CheckedNormal : CheckBoxState.UncheckedNormal;
                    CheckBoxRenderer.DrawCheckBox(e.Graphics, adjustedBounds.Location, state);

                    textBounds.X += 16;
                    textBounds.Width -= 16;

                    TextRenderer.DrawText(e.Graphics, e.SubItem.Text, lv_ElementsOfSLA_Source.Font, textBounds, Color.Black, flags);
                }
                else
                {
                    // Otras columnas normales
                    TextRenderer.DrawText(e.Graphics, e.SubItem.Text, lv_ElementsOfSLA_Source.Font, textBounds, Color.Black, flags);
                }
            }
            else
            {
                e.DrawDefault = true;
            }
        }

        protected override void ConnectionDetailsUpdated(NotifyCollectionChangedEventArgs e)
        {
            // For now, only support one target org
            if (e.Action.Equals(NotifyCollectionChangedAction.Add))
            {
                _targetConnectionDetail = (ConnectionDetail)e.NewItems[0];
                _targetService = _targetConnectionDetail.ServiceClient;

                l_environmentTargetValue.Text = _targetConnectionDetail.ConnectionName;
                l_environmentTargetValue.ForeColor = Color.Green;

                Prepare();
            }
        }

        private void btn_CreateSLA_Click(object sender, EventArgs e)
        {
            CreateSLA formCreateSLA = new CreateSLA();
            var result = formCreateSLA.ShowDialog();
            if (result == DialogResult.OK)
            {
                var newNameSLA = formCreateSLA.NewName;
                var newMainEntitySLA = formCreateSLA.NewMainEntity;
                var newDescriptionSLA = formCreateSLA.NewDescription;
            }            
        }

        private void btn_CopySLA_Click(object sender, EventArgs e)
        {
            CreateSLA formCreateSLA = new CreateSLA();
            formCreateSLA.CopySLA = true;
            formCreateSLA.NewName = "Test SLA (copy)";
            var result = formCreateSLA.ShowDialog();
            if (result == DialogResult.OK)
            {
                var newNameSLA = formCreateSLA.NewName;
                var newMainEntitySLA = formCreateSLA.NewMainEntity;
                var newDescriptionSLA = formCreateSLA.NewDescription;
            }
        }

        private void btn_CopyElementsOfSLA_Click(object sender, EventArgs e)
        {
            CopySLA formCopySLA = new CopySLA();
            formCopySLA.AddItemsToComboBox(cb_SLAs_Source.Items.Cast<SLA>().Where(k => k.Value != _slaSelected_Source.Id && k.MainEntity == _slaSelected_Source.FormattedValues["objecttypecode"].ToString()).ToList());
            var result = formCopySLA.ShowDialog();
            if (result == DialogResult.OK)
            {
                Guid SLATarget = formCopySLA.GetSLATargetSelected;
            }
        }
    }
}