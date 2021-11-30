using BdkAutomation.Scada.HelperLayer.TabPageHelper;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BdkAutomation.Scada.BAL.Concrete.Tab_Page_Operations
{
    public class TabPageOperationClass
    {
        public void AddItems(int tabPageTag, PanelControl newPanelControl, XtraTabControl xtraTabControlPages)
        {
            #region selectedPanelControl
            if (!string.IsNullOrEmpty(TabPageClass.TabPageName))
            {
                newPanelControl.Dock = DockStyle.Fill;
                newPanelControl.BackColor = Color.WhiteSmoke;
                newPanelControl.Appearance.BorderColor = Color.Red;
                newPanelControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
                newPanelControl.LookAndFeel.UseDefaultLookAndFeel = false;
                newPanelControl.LookAndFeel.UseWindowsXPTheme = true;

                #endregion
                #region TabPage
                XtraTabPage newTabPage = new XtraTabPage();
                newTabPage.Name = $"TabPage0{TabPageClass.AmountOfTabPage}";
                newTabPage.Text = TabPageClass.TabPageName;
                #endregion
                #region AddTabPageOperations
                newTabPage.Controls.Add(newPanelControl);
                TabPageClass.AmountOfTabPage++;
                xtraTabControlPages.TabPages.Add(newTabPage);
                xtraTabControlPages.SelectedTabPage = newTabPage;
                #endregion
            }
        }
    }
}
