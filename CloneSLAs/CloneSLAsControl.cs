using CloneSLAs.Model;
using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using XrmToolBox.Extensibility;

namespace CloneSLAs
{
    public partial class CloneSLAsControl : MultipleConnectionsPluginControlBase
    {
        const string titleItemsOfSLASourceSelected = "Items of SLA source selected";
        const string titleItemsOfSLATargetSelected = "Items of SLA target selected";
        const string textStatusLastAction = "Status of the last action: ";

        private Settings mySettings;
        private IOrganizationService _targetService;
        private ConnectionDetail _targetConnectionDetail;

        private List<ListViewItem> _sourceLVItemsOfSLA = new List<ListViewItem>();
        private List<Entity> _sourceSLAs = new List<Entity>();
        private List<Entity> _sourceItemsOfSLA = new List<Entity>();
        private Entity _sourceSLASelected = null;

        private List<ListViewItem> _targetLVItemsOfSLA = new List<ListViewItem>();
        private List<Entity> _targetSLAs = new List<Entity>();
        private List<Entity> _targetItemsOfSLA = new List<Entity>();
        private Entity _targetSLASelected = null;

        private List<Entity> _SLAKPIs = new List<Entity>();


        private List<MainEntity> _mainEntitys = new List<MainEntity>();

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

                Prepare_Source();
               
                LogWarning("Settings not found => a new settings file has been created!");
                //Prevent focus on the text box
                tb_MainEntity_Source.GotFocus += (textBox, o) => { ((TextBox)textBox).Parent.Focus(); };
                tb_MainEntity_Target.GotFocus += (textBox, o) => { ((TextBox)textBox).Parent.Focus(); };

                tb_Description_Source.GotFocus += (textBox, o) => { ((TextBox)textBox).Parent.Focus(); };
                tb_Description_Source.GotFocus += (textBox, o) => { ((TextBox)textBox).Parent.Focus(); };
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
                            _sourceSLAs.Add(entity);
                            cb_SLAs_Source.Items.Add(new SLA() { Text = entity.GetAttributeValue<string>("name"), Value = entity.Id, MainEntity = entity.FormattedValues["objecttypecode"].ToString() } );
                        }

                        _sourceLVItemsOfSLA.Clear();
                        lv_ElementsOfSLA_Source.Items.Clear();
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
                        Criteria =
                        {
                            Conditions =
                            {
                                new ConditionExpression("slaid", ConditionOperator.Equal, _sourceSLASelected.Id)
                            }
                        },
                        Orders =
                        {
                            new OrderExpression("name", OrderType.Descending)
                        }
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
                        _sourceItemsOfSLA.Clear();
                        _sourceLVItemsOfSLA.Clear();                       

                        foreach (var entity in result.Entities)
                        {
                            _sourceItemsOfSLA.Add(entity);
                            _sourceLVItemsOfSLA.Add(new ListViewItem(new string[]
                            {
                               entity.GetAttributeValue<string>("name"),
                               _sourceSLASelected.GetAttributeValue<string>("name"),
                               entity.GetAttributeValue<EntityReference>("msdyn_slakpiid").Name,
                               entity.GetAttributeValue<int>("warnafter").ToString(),
                               entity.GetAttributeValue<int>("failureafter").ToString(),
                               _sourceSLASelected.FormattedValues["statuscode"],
                               _sourceSLASelected.FormattedValues["statecode"],
                               entity.GetAttributeValue<int>("sequencenumber").ToString()
                            }));
                        }

                        lv_ElementsOfSLA_Source.Items.Clear();
                        lv_ElementsOfSLA_Source.Items.AddRange(_sourceLVItemsOfSLA.ToArray());
                        lv_ElementsOfSLA_Source.Items.Cast<ListViewItem>().All(k => k.Checked = false);
                        gb_ElementsFromSLASelected_Source.Text = titleItemsOfSLASourceSelected + " (" + result.Entities.Count.ToString() + ")";
                    }
                }
            });
        }

        private void GetSLAs_Target()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Getting SLAs target",
                Work = (worker, args) =>
                {
                    args.Result = _targetService.RetrieveMultiple(new QueryExpression("sla")
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
                        cb_SLAs_Target.Items.Clear();
                        cb_SLAs_Target.DisplayMember = "Text";
                        cb_SLAs_Target.ValueMember = "Value";
                        foreach (var entity in result.Entities)
                        {
                            _targetSLAs.Add(entity);
                            cb_SLAs_Target.Items.Add(new SLA() { Text = entity.GetAttributeValue<string>("name"), Value = entity.Id, MainEntity = entity.FormattedValues["objecttypecode"].ToString() });
                        }

                        _targetLVItemsOfSLA.Clear();
                        lv_ElementsOfSLA_Target.Items.Clear();
                    }
                }
            });
        }

        private void GetElementsOfSLA_Target()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Getting Elements of SLA target",
                Work = (worker, args) =>
                {
                    args.Result = _targetService.RetrieveMultiple(new QueryExpression("slaitem")
                    {
                        ColumnSet = new ColumnSet(true),
                        Criteria =
                        {
                            Conditions =
                            {
                                new ConditionExpression("slaid", ConditionOperator.Equal, _targetSLASelected.Id)
                            }
                        },
                        Orders =
                        {
                            new OrderExpression("name", OrderType.Descending)
                        }
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
                        _targetItemsOfSLA.Clear();
                        _targetLVItemsOfSLA.Clear();

                        foreach (var entity in result.Entities)
                        {
                            _targetItemsOfSLA.Add(entity);
                            _targetLVItemsOfSLA.Add(new ListViewItem(new string[]
                            {
                               entity.GetAttributeValue<string>("name"),
                               _targetSLASelected.GetAttributeValue<string>("name"),
                               entity.GetAttributeValue<EntityReference>("msdyn_slakpiid").Name,
                               entity.GetAttributeValue<int>("warnafter").ToString(),
                               entity.GetAttributeValue<int>("failureafter").ToString(),
                               _targetSLASelected.FormattedValues["statuscode"],
                               _targetSLASelected.FormattedValues["statecode"],
                               entity.GetAttributeValue<int>("sequencenumber").ToString()
                            }));
                        }

                        lv_ElementsOfSLA_Target.Items.Clear();
                        lv_ElementsOfSLA_Target.Items.AddRange(_targetLVItemsOfSLA.ToArray());
                        lv_ElementsOfSLA_Target.Items.Cast<ListViewItem>().All(k => k.Checked = false);
                        gb_ElementsFromSLASelected_Target.Text = titleItemsOfSLATargetSelected + " (" + result.Entities.Count.ToString() + ")";
                    }
                }
            });
        }

        private void GetMainEntitysAvaiable()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Getting Main Entities avaiable",
                Work = (worker, args) =>
                {
                    var request = new RetrieveAllEntitiesRequest
                    {
                        EntityFilters = EntityFilters.Entity,
                        RetrieveAsIfPublished = true
                    };

                    var response = (RetrieveAllEntitiesResponse)Service.Execute(request);

                    args.Result = response.EntityMetadata
                        .Where(e =>
                            e.IsValidForAdvancedFind == true &&
                            e.IsSLAEnabled == true
                        ).ToList<EntityMetadata>();
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    var result = args.Result as List<EntityMetadata>;
                    if (result != null)
                    {
                        _mainEntitys = result.Select(item => new MainEntity
                        {
                            LogicalName = item.LogicalName,
                            DisplayName = ((Microsoft.Xrm.Sdk.Label)item.DisplayName).UserLocalizedLabel.Label.ToString(),
                            ObjectTypeCode = item.ObjectTypeCode.Value
                        }).ToList();
                        this.Enabled = true;
                    }
                }
            });
        }

        private void GetSLAKPIsAvaiable()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Getting SLA KPIs avaiable",
                Work = (worker, args) =>
                {
                    args.Result = Service.RetrieveMultiple(new QueryExpression("msdyn_slakpi")
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
                        _SLAKPIs = result.Entities.ToList();
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

        private void Prepare_Source()
        {
            if (ConnectionDetail != null)
            {
                l_environmentSourceValue.Text = ConnectionDetail.ConnectionName;
            }
            else
            {
                this.Enabled = false;
                l_environmentSourceValue.Text = "Pending selected";
                l_environmentSourceValue.ForeColor = Color.Red;
            }

            //ConfigureGridElementsOfSLAs Source
            _sourceLVItemsOfSLA = new List<ListViewItem>();

            lv_ElementsOfSLA_Source.Columns.Clear();
            lv_ElementsOfSLA_Source.Columns.Add("Name", 150);
            lv_ElementsOfSLA_Source.Columns.Add("SLA", 80);
            lv_ElementsOfSLA_Source.Columns.Add("KPI of SLA", 150);
            lv_ElementsOfSLA_Source.Columns.Add("Warning after", 100);
            lv_ElementsOfSLA_Source.Columns.Add("Error after", 100);
            lv_ElementsOfSLA_Source.Columns.Add("Status (SLA)", 100);
            lv_ElementsOfSLA_Source.Columns.Add("Reason for state (SLA)", 100);
            lv_ElementsOfSLA_Source.Columns.Add("Secuence number", 100);

            tb_MainEntity_Source.Text = "";
            tb_Description_Source.Text = "";

            ExecuteMethod(GetSLAs_Source);
            ExecuteMethod(GetMainEntitysAvaiable);
            ExecuteMethod(GetSLAKPIsAvaiable);
        }

        private void Prepare_Target()
        {
            if (_targetService != null)
            {
                l_environmentTargetValue.Text = _targetConnectionDetail.ConnectionName;
                l_environmentTargetValue.ForeColor = Color.Green;

                //ConfigureGridElementsOfSLAs Target
                _targetLVItemsOfSLA = new List<ListViewItem>();
                lv_ElementsOfSLA_Target.Columns.Clear();

                lv_ElementsOfSLA_Target.Columns.Add("Name", 150);
                lv_ElementsOfSLA_Target.Columns.Add("SLA", 80);
                lv_ElementsOfSLA_Target.Columns.Add("KPI of SLA", 150);
                lv_ElementsOfSLA_Target.Columns.Add("Warning after", 100);
                lv_ElementsOfSLA_Target.Columns.Add("Error after", 100);
                lv_ElementsOfSLA_Target.Columns.Add("Status (SLA)", 100);
                lv_ElementsOfSLA_Target.Columns.Add("Reason for state (SLA)", 100);
                lv_ElementsOfSLA_Target.Columns.Add("Secuence number", 100);

                tb_MainEntity_Target.Text = "";
                tb_Description_Target.Text = "";

                ExecuteMethod(GetSLAs_Target);

                btn_CreateSLA.Enabled = false;
            }
            else
            {
                btn_CreateSLA.Enabled = true;

                l_environmentTargetValue.Text = "Pending selected";
                l_environmentTargetValue.ForeColor = Color.Red;
            }
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
                Prepare_Source();
                Prepare_Target();
            }
        }

        private void bt_SelectTarget_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            AddAdditionalOrganization();
            this.Enabled = true;
        }

        protected override void ConnectionDetailsUpdated(NotifyCollectionChangedEventArgs e)
        {
            // For now, only support one target org
            if (e.Action.Equals(NotifyCollectionChangedAction.Add))
            {
                btn_CreateSLA.Enabled = false;
                _targetConnectionDetail = (ConnectionDetail)e.NewItems[0];
                _targetService = _targetConnectionDetail.ServiceClient;
            }
            else
            {
                btn_CreateSLA.Enabled = true;
            }

            this.Enabled = true;
        }

        private void cb_SLAs_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cb_SLAs_Source.SelectedItem != null)
            {
                var selectedSLA = cb_SLAs_Source.SelectedItem;
                var selectedSLAId = ((dynamic)selectedSLA).Value;
                var selectedSLAName = ((dynamic)selectedSLA).Text;
                _sourceSLASelected = _sourceSLAs.FirstOrDefault(s => s.Id == selectedSLAId);
                if(_sourceSLASelected != null)
                {
                    tb_MainEntity_Source.Text = _sourceSLASelected.FormattedValues["objecttypecode"].ToString();
                    tb_Description_Source.Text = _sourceSLASelected.GetAttributeValue<string>("description");

                    if (_sourceSLASelected != null)
                        ExecuteMethod(GetElementsOfSLA_Source);

                    btn_CopyElementsOfSLA.Enabled = true;
                    btn_CopySLA.Enabled = true;
                }
                else
                {                    
                    btn_CopyElementsOfSLA.Enabled = false;
                    btn_CopySLA.Enabled = false;
                }
            }
            else
            {
                btn_CopyElementsOfSLA.Enabled = false;
                btn_CopySLA.Enabled = false;
            }
        }

        private void lv_ElementsOfSLA_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lv_ElementsOfSLA_Source_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if (e.Item.Selected)
            {
                e.Graphics.FillRectangle(Brushes.White, e.Bounds);

                TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding | TextFormatFlags.NoPrefix | TextFormatFlags.GlyphOverhangPadding | TextFormatFlags.PreserveGraphicsClipping;
                int leftPadding = 6;

                Rectangle textBounds = new Rectangle(
                    e.Bounds.X + leftPadding,
                    e.Bounds.Y,
                    e.Bounds.Width - (leftPadding),
                    e.Bounds.Height);

                if (e.ColumnIndex == 0 && lv_ElementsOfSLA_Source.CheckBoxes)
                {
                    //Column checkbox
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
                    // Other columns
                    TextRenderer.DrawText(e.Graphics, e.SubItem.Text, lv_ElementsOfSLA_Source.Font, textBounds, Color.Black, flags);
                }
            }
            else
            {
                e.DrawDefault = true;
            }
        }

        private void lv_ElementsOfSLA_Target_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if (e.Item.Selected)
            {
                e.Graphics.FillRectangle(Brushes.White, e.Bounds);

                TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding | TextFormatFlags.NoPrefix | TextFormatFlags.GlyphOverhangPadding | TextFormatFlags.PreserveGraphicsClipping;
                int leftPadding = 6;

                Rectangle textBounds = new Rectangle(
                    e.Bounds.X + leftPadding,
                    e.Bounds.Y,
                    e.Bounds.Width - (leftPadding),
                    e.Bounds.Height);

                if (e.ColumnIndex == 0 && lv_ElementsOfSLA_Target.CheckBoxes)
                {
                    //Column checkbox
                    leftPadding -= 2;

                    Rectangle adjustedBounds = new Rectangle(e.Bounds.X + leftPadding, e.Bounds.Y + 2, e.Bounds.Width - leftPadding, e.Bounds.Height);

                    CheckBoxState state = e.Item.Checked ? CheckBoxState.CheckedNormal : CheckBoxState.UncheckedNormal;
                    CheckBoxRenderer.DrawCheckBox(e.Graphics, adjustedBounds.Location, state);

                    textBounds.X += 16;
                    textBounds.Width -= 16;

                    TextRenderer.DrawText(e.Graphics, e.SubItem.Text, lv_ElementsOfSLA_Target.Font, textBounds, Color.Black, flags);
                }
                else
                {
                    // Other columns
                    TextRenderer.DrawText(e.Graphics, e.SubItem.Text, lv_ElementsOfSLA_Target.Font, textBounds, Color.Black, flags);
                }
            }
            else
            {
                e.DrawDefault = true;
            }
        }

        private void btn_CreateSLA_Click(object sender, EventArgs e)
        {            
            CreateSLA formCreateSLA = new CreateSLA();          
            formCreateSLA.SetMainEntitys = _mainEntitys;
            if(_sourceSLASelected != null)
                formCreateSLA.MainEntitySelected = _mainEntitys.Where(k => k.DisplayName == _sourceSLASelected.FormattedValues["objecttypecode"].ToString()).FirstOrDefault();
            var result = formCreateSLA.ShowDialog();
            if (result == DialogResult.OK)
            {
                lb_Status.Text = "";
                ExecuteMethod(() => CreateOrCopy_SLA(formCreateSLA, true));                
            }            
        }

        private void CreateOrCopy_SLA(CreateSLA formCreateSLA, Boolean create)
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = create == true ? "Creating SLA..." : "Copying SLA...",
                Work = (worker, args) =>
                {
                    //Create record SLA in Source  
                    Entity newSLA = new Entity("sla");
                    newSLA["name"] = formCreateSLA.NewName;
                    newSLA["objecttypecode"] = formCreateSLA.MainEntitySelected.LogicalName;
                    newSLA["description"] = formCreateSLA.NewDescription;
                    newSLA["applicablefrom"] = create == true ? "createdon" : (_sourceSLASelected.Contains("applicablefrom") ? _sourceSLASelected.Attributes["applicablefrom"] : "createdon");
                    newSLA["slaversion"] = create == true ? new OptionSetValue(100000001) : (_sourceSLASelected.Contains("slaversion") ? _sourceSLASelected.Attributes["slaversion"] : new OptionSetValue(100000001));
                    newSLA["primaryentityotc"] = formCreateSLA.MainEntitySelected.ObjectTypeCode;

                    if(_targetService == null)
                    {
                        args.Result = Service.Create(newSLA);
                    }
                    else
                    {
                        args.Result = _targetService.Create(newSLA);
                    }
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    var result = args.Result as Guid?;
                    if (result != null && result.Value != Guid.Empty)
                    {
                        SetStatusMessage(create == true ? "SLA created: " : "SLA copied: " + formCreateSLA.NewName);
                        if (create == true)
                        {
                            //Refresh SLAs in source
                            ExecuteMethod(GetSLAs_Source);
                            //Refresh elements of SLA in source
                            if (_sourceSLASelected != null)
                                ExecuteMethod(GetElementsOfSLA_Source);
                        }
                        else
                        {
                            ExecuteMethod(() => Copy_SLAItems("Copying SLA items...", result.Value, true));
                        }
                    }
                }
            });
        }

        private void Copy_SLAItems(string message, Guid newSLA, Boolean process)
        {
            if (!process)
                return;

            WorkAsync(new WorkAsyncInfo
            {
                Message = message,
                Work = (worker, args) =>
                {
                    var statusSLAItems = true;
                    var kpi = _SLAKPIs.Where(k => k.Id == _sourceItemsOfSLA[0].GetAttributeValue<EntityReference>("msdyn_slakpiid").Id).FirstOrDefault();
                    var responseSLAKPIGUID = Guid.Empty;
                    if (kpi != null)
                    {
                        kpi["statecode"] = new OptionSetValue(0);
                        kpi["statuscode"] = new OptionSetValue(1);

                        //Copy SLA KPI to target
                        responseSLAKPIGUID = UpSert(kpi);
                        if (responseSLAKPIGUID == null || responseSLAKPIGUID == Guid.Empty)
                        {
                            statusSLAItems = false;
                        }
                        else
                        {
                            //Enable SLA KPI
                            kpi["statecode"] = new OptionSetValue(1);
                            kpi["statuscode"] = new OptionSetValue(2);

                            //Copy SLA KPI to target
                            responseSLAKPIGUID = UpSert(kpi);
                        }
                    }
                    else
                    {
                        LogWarning($"SLA KPI not found");
                    }
                    //Copy items of SLA to source or target
                    foreach (var item in _sourceItemsOfSLA)
                    {
                        try
                        {
                            Entity newItemInSLA = new Entity("slaitem", item.Id);
                            newItemInSLA["slaid"] = new EntityReference("sla", newSLA);
                            newItemInSLA["name"] = item.Attributes["name"];

                            if (item.Attributes.Contains("msdyn_slakpiid"))
                            {
                                //Set SLA KPI in new SLA item
                                newItemInSLA["msdyn_slakpiid"] = new EntityReference("msdyn_slakpi", responseSLAKPIGUID);
                                
                            }
                            if (item.Attributes.Contains("warnafter"))
                                newItemInSLA["warnafter"] = item.Attributes["warnafter"];
                            if (item.Attributes.Contains("failureafter"))
                                newItemInSLA["failureafter"] = item.Attributes["failureafter"];
                            if (item.Attributes.Contains("sequencenumber"))
                                newItemInSLA["sequencenumber"] = item.Attributes["sequencenumber"];
                            if (item.Attributes.Contains("statuscode"))
                                newItemInSLA["statuscode"] = item.Attributes["statuscode"];
                            if (item.Attributes.Contains("statecode"))
                                newItemInSLA["statecode"] = item.Attributes["statecode"];
                            if (item.Attributes.Contains("allowpauseresume"))
                                newItemInSLA["allowpauseresume"] = item.Attributes["allowpauseresume"];
                            if (item.Attributes.Contains("versionnumber"))
                                newItemInSLA["versionnumber"] = item.Attributes["versionnumber"];
                            if (item.Attributes.Contains("componentstate"))
                                newItemInSLA["componentstate"] = item.Attributes["componentstate"];

                            if (item.Attributes.Contains("applicablewhenxml"))
                                newItemInSLA["applicablewhenxml"] = item.Attributes["applicablewhenxml"];
                            if (item.Attributes.Contains("successconditionsxml"))
                                newItemInSLA["successconditionsxml"] = item.Attributes["successconditionsxml"];
                            if (item.Attributes.Contains("msdyn_pauseconfigurationxml"))
                                newItemInSLA["msdyn_pauseconfigurationxml"] = item.Attributes["msdyn_pauseconfigurationxml"];

                            var responseSLAItemGUID = UpSert(newItemInSLA);
                            if (responseSLAItemGUID == null || responseSLAItemGUID == Guid.Empty)
                            {
                                statusSLAItems = false;
                            }
                        }
                        catch(Exception ex)
                        {
                            LogWarning($"SLAItem {item.Id} from SLA {newSLA} not copied: {ex.Message}");
                        }                        
                    }

                    args.Result = statusSLAItems;
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Any SLA items copy error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    var result = args.Result as Boolean?;
                    if (result != null && result.Value)
                    {
                        if(process)
                            SetStatusMessage("SLA items copied sucess");

                        if (_targetService != null)
                        {
                            _targetLVItemsOfSLA.Clear();
                            lv_ElementsOfSLA_Target.Items.Clear();

                            //Refresh SLAs in target
                            ExecuteMethod(GetSLAs_Target);

                            //Refresh elements of SLA in target
                            if (_targetSLASelected != null && process == false)
                                ExecuteMethod(GetElementsOfSLA_Target);

                            ExecuteMethod(() => Copy_SLAItems("Reorder secuence SLA items...", newSLA, message == "Reorder secuence SLA items..." ? false : true));
                        }
                        else
                        {
                            _sourceLVItemsOfSLA.Clear();
                            lv_ElementsOfSLA_Source.Items.Clear();

                            //Refresh SLAs in source
                            ExecuteMethod(GetSLAs_Source);

                            //Refresh elements of SLA in source
                            if(_sourceSLASelected != null)
                                ExecuteMethod(GetElementsOfSLA_Source);
                        }
                    }
                }
            });
        }

        private Guid UpSert (Entity entity)
        {
            UpsertRequest request = new UpsertRequest()
            {

                Target = entity
            };
            UpsertResponse response = null;
            if (_targetService == null)
            {
                response = (UpsertResponse)Service.Execute(request);
            }
            else
            {
                response = (UpsertResponse)_targetService.Execute(request);                
            }

            if (response != null && response.Target != null && response.Target.Id != Guid.Empty)
            {
                return response.Target.Id;
            }
            else
            {
                return Guid.Empty;
            }
        }

        private void btn_CopySLA_Click(object sender, EventArgs e)
        {
            CreateSLA formCreateSLA = new CreateSLA();
            formCreateSLA.CopySLA = true;
            if (_sourceSLASelected != null)
            {
                var mainEntitySelected = _mainEntitys.Where(k => k.DisplayName == _sourceSLASelected.FormattedValues["objecttypecode"].ToString()).FirstOrDefault();
                formCreateSLA.MainEntitySelected = mainEntitySelected;
                formCreateSLA.NewName = _sourceSLASelected.Attributes["name"] + " (copy)";  
                formCreateSLA.NewDescription = _sourceSLASelected.Attributes["description"] != null ? _sourceSLASelected.Attributes["description"].ToString() : "";
            }
            
            formCreateSLA.SetMainEntitys = _mainEntitys;
            var result = formCreateSLA.ShowDialog();
            if (result == DialogResult.OK)
            {
                lb_Status.Text = "";
                ExecuteMethod(() => CreateOrCopy_SLA(formCreateSLA, false));
            }
        }

        private void btn_CopyItemsOfSLA_Click(object sender, EventArgs e)
        {
            CopySLAItems formCopySLA = new CopySLAItems();
            if (_targetService != null)
            {
                if(cb_SLAs_Target.SelectedItem == null)
                    formCopySLA.AddItemsToComboBox(cb_SLAs_Target.Items.Cast<SLA>().Where(k => k.MainEntity == _sourceSLASelected.FormattedValues["objecttypecode"].ToString()).ToList());
            }
            else
            {
                formCopySLA.AddItemsToComboBox(cb_SLAs_Source.Items.Cast<SLA>().Where(k => k.Value != _sourceSLASelected.Id && k.MainEntity == _sourceSLASelected.FormattedValues["objecttypecode"].ToString()).ToList());
            }

            if ((_targetService != null && cb_SLAs_Target.SelectedItem == null) || (Service != null && _targetService == null))
            {
                var result = formCopySLA.ShowDialog();
                if (result == DialogResult.OK)
                {
                    ExecuteMethod(() => Copy_SLAItems("Copying SLA items...", formCopySLA.GetSLATargetSelected, true));
                }
            }
            else if(_targetService != null)
            {
                ExecuteMethod(() => Copy_SLAItems("Copying SLA items...", ((SLA)cb_SLAs_Target.SelectedItem).Value, true));
            }
        }

        private void SetStatusMessage (string message)
        {
            lb_Status.Text = textStatusLastAction + message;
            p_Footer.BackColor = Color.Yellow;
            timer_Status = new Timer();
            timer_Status.Interval = 2000;
            timer_Status.Tick += new EventHandler(HideStatusMessage);
            timer_Status.Start();
        }

        private void HideStatusMessage (object sender, EventArgs e)
        {
            lb_Status.Text = "";
            p_Footer.BackColor = Color.Transparent;
        }

        private void cb_SLAs_Target_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cb_SLAs_Target.SelectedItem != null)
            {
                var selectedSLA = cb_SLAs_Target.SelectedItem;
                var selectedSLAId = ((dynamic)selectedSLA).Value;
                var selectedSLAName = ((dynamic)selectedSLA).Text;
                _targetSLASelected = _targetSLAs.FirstOrDefault(s => s.Id == selectedSLAId);
                if (_targetSLASelected != null)
                {
                    tb_MainEntity_Source.Text = _targetSLASelected.FormattedValues["objecttypecode"].ToString();
                    tb_Description_Source.Text = _targetSLASelected.GetAttributeValue<string>("description");

                    if (_targetSLASelected != null)
                        ExecuteMethod(GetElementsOfSLA_Target);
                }
            }
            else
            {
                btn_CopyElementsOfSLA.Enabled = false;
                btn_CopySLA.Enabled = false;
            }
        }
    }
}