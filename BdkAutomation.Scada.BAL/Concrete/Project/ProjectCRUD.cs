using BdkAutomation.Scada.JDAL.Concrete;
using BdkAutomation.Scada.Models.UserControls.GeneralUserControls;
using BdkAutomation.Scada.Models.UserControls.ProjectControls;
using DevExpress.XtraEditors;
using DevExpress.XtraVerticalGrid;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BdkAutomation.Scada.BAL.Concrete.Project
{
    public class ProjectCRUD
    {
        static string savePath="";
        public void ProjectCreate(PanelControl panelControl, PropertyGridControl propertyGridControl1)
        {
            ProjectSettings ps = new ProjectSettings();
            DialogResult result = XtraDialog.Show(ps, "Proje Oluştur", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                string path = $@"{ps.btnLocation.Text}\{ps.txtFileName.Text}.json";
                File.Create(path);
                panelControl.Controls.Clear();
                propertyGridControl1.SelectedObject = null;
                savePath = path;
            }
        }

        public void ProjectSave(PanelControl panelControl)
        {
            if (!string.IsNullOrEmpty(savePath))
            {
                JsonGenerator generator = new JsonGenerator();
                List<UserControlButton> buttonList = new List<UserControlButton>();
                List<UserControlLabel> labelList = new List<UserControlLabel>();
                List<UserControlTextBox> textBoxList = new List<UserControlTextBox>();

                foreach (var item in panelControl.Controls)
                {
                    switch (item)
                    {
                        case UserControlButton btn:
                            buttonList.Add(btn);
                            break;
                        case UserControlLabel label:
                            labelList.Add(label);
                            break;
                        case UserControlTextBox textBox:
                            textBoxList.Add(textBox);
                            break;
                    }
                }
                generator.GeneratorJArray(buttonList, labelList, textBoxList, savePath);
                MessageBox.Show("Saving is completed");
            }
            else
            {
                MessageBox.Show("Location can not empty or null");
            }
        }
    }
}
