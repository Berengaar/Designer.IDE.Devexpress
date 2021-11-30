using BdkAutomation.Scada.Models.UserControls.GeneralUserControls;
using BdkAutomation.Scada.UI.Helper;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BdkAutomation.Scada.BAL.Concrete.EventEditor
{
    //Todo: Edit Mods selector for objects
    public class AppearanceEditor
    {
        public void TextBoxEditor(object sender, MouseEventArgs e,Cursor cursor, EditMods editMods, List<UserControlTextBox> listUserTextBox, Point ObjectLoc, int ObjectWidth, int ObjectHeight)
        {
            var textBoxTag = Convert.ToInt32(((TextEdit)sender).Tag);
            switch (editMods)
            {
                case EditMods.None:
                    cursor = System.Windows.Forms.Cursors.Default;
                    break;
                case EditMods.ReSize:
                    cursor = System.Windows.Forms.Cursors.SizeAll;
                    ((UserControlTextBox)listUserTextBox[textBoxTag]).Size = new Size(ObjectWidth + e.X - ObjectLoc.X, ObjectHeight + e.Y - ObjectLoc.Y);
                    break;
                case EditMods.Move:
                    cursor = System.Windows.Forms.Cursors.SizeAll;
                    ((UserControlTextBox)listUserTextBox[textBoxTag]).Left += e.X - ObjectLoc.X;
                    ((UserControlTextBox)listUserTextBox[textBoxTag]).Top += e.Y - ObjectLoc.Y;
                    break;
            }
        }

        public void LabelEditor(object sender, MouseEventArgs e, Cursor cursor, EditMods editMods, List<UserControlLabel> listUserLabel, Point ObjectLoc, int ObjectWidth, int ObjectHeight)
        {
            var labelTag = Convert.ToInt32(((LabelControl)sender).Tag);
            switch (editMods)
            {
                case EditMods.None:
                    cursor = System.Windows.Forms.Cursors.Default;
                    break;
                case EditMods.ReSize:
                    cursor = System.Windows.Forms.Cursors.SizeAll;
                    ((UserControlLabel)listUserLabel[labelTag]).Size = new Size(ObjectWidth + e.X - ObjectLoc.X, ObjectHeight + e.Y - ObjectLoc.Y);
                    break;
                case EditMods.Move:
                    cursor = System.Windows.Forms.Cursors.SizeAll;
                    ((UserControlLabel)listUserLabel[labelTag]).Left += e.X - ObjectLoc.X;
                    ((UserControlLabel)listUserLabel[labelTag]).Top += e.Y - ObjectLoc.Y;
                    break;
            }
        }

        public void ButtonEditor(object sender, MouseEventArgs e, Cursor cursor, EditMods editMods, List<UserControlButton> listUserButton, Point ObjectLoc, int ObjectWidth, int ObjectHeight)
        {
            var buttonTag = Convert.ToInt32(((SimpleButton)sender).Tag);
            switch (editMods)
            {
                case EditMods.None:
                    cursor = System.Windows.Forms.Cursors.Default;
                    break;
                case EditMods.ReSize:
                    cursor = System.Windows.Forms.Cursors.SizeAll;
                    ((UserControlButton)listUserButton[buttonTag]).Size = new Size(ObjectWidth + e.X - ObjectLoc.X, ObjectHeight + e.Y - ObjectLoc.Y);
                    break;
                case EditMods.Move:
                    cursor = System.Windows.Forms.Cursors.SizeAll;
                    //UserControlButton btn = new UserControlButton();
                    ((UserControlButton)listUserButton[buttonTag]).Left += e.X - ObjectLoc.X;
                    ((UserControlButton)listUserButton[buttonTag]).Top += e.Y - ObjectLoc.Y;
                    break;
            }
        }
    }
}
