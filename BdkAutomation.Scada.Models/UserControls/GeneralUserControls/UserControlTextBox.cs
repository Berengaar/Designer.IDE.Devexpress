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
    public partial class UserControlTextBox : DevExpress.XtraEditors.XtraUserControl
    {
        public UserControlTextBox()
        {
            InitializeComponent();
        }
        private string userTextBoxText;


        public int UserTag
        {
            get
            {
                return Convert.ToInt32(textEdit1.Tag);
            }
            set
            {
                textEdit1.Tag = TextBoxTagCounter.TextBoxTag;
            }
        }

        public string UserLabelName
        {
            get { return this.Name; }
            set { this.Name = value; }
        }

        public string UserLabelText
        {
            get { return userTextBoxText; }
            set { this.textEdit1.Text = value; }
        }
    }
}
