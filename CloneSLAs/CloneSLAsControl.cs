using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
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
    public partial class CloneSLAsControl : PluginControlBase
    {
        private Settings mySettings;
        private List<ListViewItem> _sourceElementsOfSLA = new List<ListViewItem>();
        private List<Entity> _slas = new List<Entity>();
        private List<Entity> _elementsOfsla = new List<Entity>();
        private Entity _slaSelected = new Entity();

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
                
                ConfigureGridElementsOfSLAs();
                ExecuteMethod(GetSLAs);
                LogWarning("Settings not found => a new settings file has been created!");
            }
            else
            {
                LogInfo("Settings found and loaded");
            }
        }

        private void GetSLAs()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Getting SLAs",
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
                        cb_SLAs.Items.Clear();
                        cb_SLAs.DisplayMember = "Text";
                        cb_SLAs.ValueMember = "Value";
                        foreach (var entity in result.Entities)
                        {
                            _slas.Add(entity);
                            cb_SLAs.Items.Add(new { Text = entity.GetAttributeValue<string>("name"), Value = entity.Id.ToString() } );
                        }
                        //MessageBox.Show($"Found {result.Entities.Count} accounts");
                    }
                }
            });
        }

        private void GetElementsOfSLA()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Getting Elements of SLA",
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
                        _elementsOfsla.Clear();
                        _sourceElementsOfSLA.Clear();                       

                        foreach (var entity in result.Entities)
                        {
                            _elementsOfsla.Add(entity);
                            _sourceElementsOfSLA.Add(new ListViewItem(new string[]
                            {
                               entity.GetAttributeValue<string>("name"),
                               _slaSelected.GetAttributeValue<string>("name"),
                               entity.GetAttributeValue<EntityReference>("msdyn_slakpiid").Name,
                               entity.GetAttributeValue<int>("warnafter").ToString(),
                               entity.GetAttributeValue<int>("failureafter").ToString(),
                               _slaSelected.FormattedValues["statuscode"],
                               _slaSelected.FormattedValues["statecode"]
                            }));
                        }

                        lv_ElementsOfSLA.Items.Clear();
                        lv_ElementsOfSLA.Items.AddRange(_sourceElementsOfSLA.ToArray());
                        lv_ElementsOfSLA.Items.Cast<ListViewItem>().All(k => k.Checked = false);
                        lb_TotalItems.Text += " : " + result.Entities.Count.ToString();
                    }
                }
            });
        }

        private void PluginControl_Resize(object sender, EventArgs e)
        {

        }

        private void ConfigureGridElementsOfSLAs()
        {
            // Crear datos ficticios  
            _sourceElementsOfSLA = new List<ListViewItem>();

            lv_ElementsOfSLA.Columns.Clear();
            lv_ElementsOfSLA.Columns.Add("Name", 150);
            lv_ElementsOfSLA.Columns.Add("SLA", 80);
            lv_ElementsOfSLA.Columns.Add("KPI of SLA", 150);
            lv_ElementsOfSLA.Columns.Add("Warning after", 100);
            lv_ElementsOfSLA.Columns.Add("Error after", 100);
            lv_ElementsOfSLA.Columns.Add("Status (SLA)", 100);
            lv_ElementsOfSLA.Columns.Add("Reason for state (SLA)", 100);
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
            }
        }

        private void cb_SLAs_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cb_SLAs.SelectedItem != null)
            {
                var selectedSLA = cb_SLAs.SelectedItem;
                var selectedSLAId = ((dynamic)selectedSLA).Value;
                var selectedSLAName = ((dynamic)selectedSLA).Text;
                _slaSelected = _slas.FirstOrDefault(s => s.Id.ToString() == selectedSLAId);
                if(_slaSelected != null)
                {
                    tb_MainEntity.Text = _slaSelected.FormattedValues["objecttypecode"].ToString();
                    tb_Description.Text = _slaSelected.GetAttributeValue<string>("description");

                    ExecuteMethod(GetElementsOfSLA);
                }
            }
        }

        private void llv_ElementsOfSLA_MouseMove(object sender, MouseEventArgs e)
        {
            ListViewItem item = lv_ElementsOfSLA.GetItemAt(e.X, e.Y);
            if (item != null)
            {
                lv_ElementsOfSLA.Cursor = Cursors.Hand;
            }
            else
            {
                lv_ElementsOfSLA.Cursor = Cursors.Default;
            }
        }

        private void lv_ElementsOfSLA_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            ListView item = (ListView)sender;
            if(item != null && item.Items[e.ItemIndex] != null && item.Items[e.ItemIndex].Selected)
            {
                item.Items[e.ItemIndex].Checked = true;
            }
        }

        private void lv_ElementsOfSLA_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ListViewItem item = (ListViewItem)e.Item;
            if (item != null)
            {
                item.Selected = item.Checked;
            }
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

                if (e.ColumnIndex == 0 && lv_ElementsOfSLA.CheckBoxes)
                {
                    leftPadding -= 2;

                    Rectangle adjustedBounds = new Rectangle(e.Bounds.X + leftPadding, e.Bounds.Y + 2, e.Bounds.Width - leftPadding, e.Bounds.Height);

                    CheckBoxState state = e.Item.Checked ? CheckBoxState.CheckedNormal : CheckBoxState.UncheckedNormal;
                    CheckBoxRenderer.DrawCheckBox(e.Graphics, adjustedBounds.Location, state);

                    textBounds.X += 16;
                    textBounds.Width -= 16;

                    TextRenderer.DrawText(e.Graphics, e.SubItem.Text, lv_ElementsOfSLA.Font, textBounds, Color.Black, flags);
                }
                else
                {
                    // Otras columnas normales
                    TextRenderer.DrawText(e.Graphics, e.SubItem.Text, lv_ElementsOfSLA.Font, textBounds, Color.Black, flags);
                }
            }
            else
            {
                e.DrawDefault = true;
            }
        }
    }
}