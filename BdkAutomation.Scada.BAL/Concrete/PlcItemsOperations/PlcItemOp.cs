using BdkAutomation.Scada.HelperLayer.PlcTagHelper;
using BdkAutomation.Scada.Models.HelperModels;
using BdkAutomation.Scada.Models.UserControls.GeneralUserControls;
using DevExpress.XtraEditors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BdkAutomation.Scada.BAL.Concrete.PlcItemsOperations
{
    public class PlcItemOp
    {
        public void CreatePlcItems(PanelControl panelControl, DataGridView dataGridView1, List<SelectedIndexClass> selectedIndexList)
        {
            selectedIndexList.Clear();
            int countItem = 0;
            List<PlcTagAddress> plcList = new List<PlcTagAddress>();
            foreach (var item in panelControl.Controls)
            {
                if (item is UserControlButton)
                {
                    string itemsName = ((UserControlButton)item).UserButtonName.ToString();
                    plcList.Add(new PlcTagAddress()
                    {
                        ItemName = itemsName,
                        TagAddress = string.Empty
                    });
                    countItem++;
                }
            }
            //Appearance DataGridView
            dataGridView1.ForeColor = Color.Black;
            dataGridView1.Dock = DockStyle.Fill;
            //Clear
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();

            //ADD COLUMNS
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "ITEMS";
            dataGridView1.Columns[1].Name = "ADDRESS";

            //ADD ROWS
            int listIndex = 0;
            foreach (var item in plcList)
            {
                ArrayList row = new ArrayList();
                row.Add(item.ItemName);
                row.Add(item.TagAddress);
                dataGridView1.Rows.Add(row.ToArray());


                //Listeye ekledik hepsini
                SelectedIndexClass newListItem = new SelectedIndexClass()
                {
                    SelectedIndexId = listIndex,
                    SelectedIndexName = item.ItemName,
                    SelectedIndexText = ""
                };
                selectedIndexList.Add(newListItem);
                listIndex++;
            }
            //ADD ComboBoxColumn
            DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
            comboBoxColumn.HeaderText = "PLC Address";
            comboBoxColumn.Name = "comboBoxPlcAddress";
            var rowCombo = new ArrayList();
            rowCombo.AddRange(new string[] { PlcAd.DB01.ToString(), PlcAd.DB02.ToString(), PlcAd.DB03.ToString(), PlcAd.DB04.ToString() });
            comboBoxColumn.Items.AddRange(rowCombo.ToArray());
            dataGridView1.Columns.Add(comboBoxColumn);
        }
        public void ChangeRow(PanelControl panelControl, DataGridView dataGridView1, List<SelectedIndexClass> selectedIndexList)
        {
            int countItem = 0;
            List<PlcTagAddress> plcList = new List<PlcTagAddress>();
            foreach (var item in panelControl.Controls)
            {
                if (item is UserControlButton)
                {
                    string itemsName = ((UserControlButton)item).UserButtonName.ToString();
                    plcList.Add(new PlcTagAddress()
                    {
                        ItemName = itemsName,
                        TagAddress = string.Empty
                    });
                    countItem++;
                }
            }
            //Appearance DataGridView
            dataGridView1.ForeColor = Color.Black;

            //Clear
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();

            //ADD COLUMNS
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "ITEMS";
            dataGridView1.Columns[1].Name = "ADDRESS";

            //ADD ROWS
            foreach (var item in selectedIndexList)
            {
                foreach (var controller in panelControl.Controls)
                {
                    if (controller is UserControlButton)
                    {
                        ((UserControlButton)controller).UserTagName = 7;
                    }
                }
                ArrayList row = new ArrayList();
                row.Add(item.SelectedIndexName);
                row.Add(item.SelectedIndexText);
                dataGridView1.Rows.Add(row.ToArray());
            }
            //ADD ComboBoxColumn
            DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
            comboBoxColumn.HeaderText = "PLC Address";
            comboBoxColumn.Name = "comboBoxPlcAddress";
            var rowCombo = new ArrayList();
            rowCombo.AddRange(new string[] { PlcAd.DB01.ToString(), PlcAd.DB02.ToString(), PlcAd.DB03.ToString(), PlcAd.DB04.ToString() });
            comboBoxColumn.Items.AddRange(rowCombo.ToArray());
            dataGridView1.Columns.Add(comboBoxColumn);
        }
        public void SelectedIndexChanged(object sender,List<SelectedIndexClass> selectedIndexList)
        {
            #region description
            //SelectedItem= text value
            //EditingControlRowIndex= Row Index
            #endregion
            foreach (var item in selectedIndexList)
            {
                if (item.SelectedIndexId == ((System.Windows.Forms.DataGridViewComboBoxEditingControl)sender).EditingControlRowIndex)
                {
                    item.SelectedIndexText = ((System.Windows.Forms.DataGridViewComboBoxEditingControl)sender).SelectedItem.ToString();
                }
            }
        }
        
    }
}
