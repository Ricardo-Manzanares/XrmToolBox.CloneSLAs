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
using XrmToolBox.Extensibility;

namespace CloneSLAs
{
    public partial class CloneSLAsControl : PluginControlBase
    {
        private Settings mySettings;
        private List<ListViewItem> _sourceElementsOfSLA = new List<ListViewItem>();

        public CloneSLAsControl()
        {
            InitializeComponent();
        }

        private void CloneSLAsControl_Load(object sender, EventArgs e)
        {
            ShowInfoNotification("This is a notification that can lead to XrmToolBox repository", new Uri("https://github.com/MscrmTools/XrmToolBox"));

            // Loads or creates the settings for the plugin
            if (!SettingsManager.Instance.TryLoad(GetType(), out mySettings))
            {
                mySettings = new Settings();
                
                LoadElementsOfSLAs();
                LogWarning("Settings not found => a new settings file has been created!");
            }
            else
            {
                LogInfo("Settings found and loaded");
            }
        }

        private void tsbSample_Click(object sender, EventArgs e)
        {
            // The ExecuteMethod method handles connecting to an
            // organization if XrmToolBox is not yet connected
            ExecuteMethod(GetSLAs);
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
                        ColumnSet = new ColumnSet("name", "primaryentityotc", "description"),
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
                        MessageBox.Show($"Found {result.Entities.Count} accounts");
                    }
                }
            });
        }

        private void PluginControl_Resize(object sender, EventArgs e)
        {

        }

        private void LoadElementsOfSLAs()
        {
            lv_ElementsOfSLA.Columns.Clear();
            lv_ElementsOfSLA.Columns.Add("Name", 150);
            lv_ElementsOfSLA.Columns.Add("SLA", 80);
            lv_ElementsOfSLA.Columns.Add("KPI of SLA", 150);
            lv_ElementsOfSLA.Columns.Add("Warning after", 100);
            lv_ElementsOfSLA.Columns.Add("Error after", 100);
            lv_ElementsOfSLA.Columns.Add("Status (SLA)", 100);
            lv_ElementsOfSLA.Columns.Add("Reason for state (SLA)", 100);
            PopulateFakeData();

            lb_TotalItems.Text += " : " + lv_ElementsOfSLA.Items.Count.ToString();
        }

        // Generar un array de líneas ficticias con las columnas definidas en lv_ElementsOfSLA  
        private void PopulateFakeData()
        {
            _sourceElementsOfSLA.Clear();

            // Crear datos ficticios  
            _sourceElementsOfSLA = new List<ListViewItem>();

            for (int i = 1; i <= 250; i++)
            {
                _sourceElementsOfSLA.Add(new ListViewItem(new string[]
                {
                   $"Task {i}",
                   $"SLA {i}",
                   $"KPI {i}",
                   $"{i}h",
                   $"{i * 2}h",
                   i % 2 == 0 ? "Active" : "Inactive",
                   i % 3 == 0 ? "No issues" : i % 3 == 1 ? "Delayed" : "On track"
                }));
            };

            // Actualizar el control ListView  
            lv_ElementsOfSLA.Items.Clear();
            lv_ElementsOfSLA.Items.AddRange(_sourceElementsOfSLA.ToArray());
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
    }
}