using BdkAutomation.Scada.UI.Helper;
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

namespace BdkAutomation.Scada.Models.UserControls.GeneralUserControls
{
    public partial class UserControlLabel : DevExpress.XtraEditors.XtraUserControl
    {
        public UserControlLabel()
        {
            InitializeComponent();
        }
        private string userLabelText;


        public int UserTag
        {
            get
            {
                return Convert.ToInt32(labelControl1.Tag);
            }
            set
            {
                labelControl1.Tag = LabelTagCounter.labelTag;
            }
        }

        public string UserLabelName
        {
            get { return this.Name; }
            set { this.Name = value; }
        }

        public string UserLabelText
        {
            get { return userLabelText; }
            set { this.labelControl1.Text = value; }
        }
    }
}
