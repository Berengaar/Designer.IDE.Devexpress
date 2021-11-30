using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BdkAutomation.Scada.Models.UserControls.ProjectControls
{
    public partial class ProjectSettings : DevExpress.XtraEditors.XtraUserControl
    {
        public ProjectSettings()
        {
            InitializeComponent();
        }

        private void btnLocation_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            xtraFolderBrowserDialog1.ShowDialog();
            btnLocation.Text = xtraFolderBrowserDialog1.SelectedPath;
        }
    }
}
