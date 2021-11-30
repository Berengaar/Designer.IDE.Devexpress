using BdkAutomation.Scada.HelperLayer.TabPageHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BdkAutomation.Scada.UI.HelperForms
{
    public partial class TabPageNamePopUp : Form
    {
        public TabPageNamePopUp()
        {
            InitializeComponent();
        }

        private void btnTabPageName_Click(object sender, EventArgs e)
        {
            TabPageClass.TabPageName = txtTabPageName.Text;
            TabPageClass.PopUpOpenClose = false;
            this.Close();
        }
    }
}
