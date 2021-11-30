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
    public partial class UserControlButton : DevExpress.XtraEditors.XtraUserControl
    {
        public UserControlButton()
        {
            InitializeComponent();
        }
        private string userButtonText;
        public Point userLocation;
        public int _UserTagName=5;

        public int UserTagName
        {
            get
            {
                return _UserTagName;
            }
            set
            {
                _UserTagName = value;
            }
        }

        public Point UserLocation
        {
            get
            {
                return simpleButton1.Location;
            }
            set
            {
                userLocation = new Point(simpleButton1.Location.X, simpleButton1.Location.Y);
            }
        }

        public int UserTag
        {
            get
            {
                return Convert.ToInt32(simpleButton1.Tag);
            }
            set
            {
                simpleButton1.Tag = ButtonTagCounter.butonTag;
            }
        }

        public string UserButtonName
        {
            get { return this.Name; }
            set { this.Name = value; }
        }

        public string UserButtonText
        {
            get { return userButtonText; }
            set { this.simpleButton1.Text = value; }
        }

        //Todo : To change of tag value with double click event
        public void simpleButton1_DoubleClick(object sender, EventArgs e)
        {
            _UserTagName++;
        }
    }
}
