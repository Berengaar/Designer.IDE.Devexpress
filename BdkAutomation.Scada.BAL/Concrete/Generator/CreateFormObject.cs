using BdkAutomation.Scada.Models.JsonModels;
using BdkAutomation.Scada.Models.UserControls.GeneralUserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BdkAutomation.Scada.BAL.Concrete.Generator
{
    //To do : After Json File Read ----> Open Folder -----> Object Create
    public class CreateFormObject
    {
        static int counter = 0;
        public UserControlButton CreateUserButton(int Count)
        {
            UserControlButton userButton = new UserControlButton();
            userButton.UserButtonName = $"UserButton{Count}";
            userButton.UserTag = counter;
            userButton.Tag = counter;
            userButton.Width = 100;
            userButton.Height = 100;
            userButton.Location = new Point(0, 0);
            return userButton;
        }
        public List<UserControlButton> CreateUserButton(List<ButtonsClass> buttonClass)
        {
            List<UserControlButton> userButtonControls = new List<UserControlButton>();
            foreach (var item in buttonClass)
            {
                UserControlButton userButton = new UserControlButton();
                userButton.simpleButton1.Tag = item.ButtonTag;
                userButton.Name = item.ButtonName;
                userButton.simpleButton1.Text = item.ButtonText;
                userButton.Width = item.ButtonWidth;
                userButton.Height = item.ButtonHeight;
                userButton.Location = new Point(item.ButtonLocation_X, item.ButtonLocation_Y);
                userButton.UserLocation = new Point(userButton.simpleButton1.Location.X, userButton.simpleButton1.Location.Y);
                userButtonControls.Add(userButton);
            }
            return userButtonControls;
        }
        public UserControlLabel CreateUserLabel(int Count)
        {
            UserControlLabel userLabel = new UserControlLabel();
            userLabel.Name = $"UserLabel{Count}";
            userLabel.UserTag = counter;
            userLabel.Tag = counter;
            userLabel.Width = 100;
            userLabel.Height = 100;
            userLabel.Location = new Point(0, 0);
            return userLabel;
        }
        public List<UserControlLabel> CreateUserLabel(List<LabelClass> labelClass)
        {
            List<UserControlLabel> userLabelControls = new List<UserControlLabel>();
            foreach (var item in labelClass)
            {
                UserControlLabel userLabel = new UserControlLabel();
                userLabel.Name = item.LabelName;
                userLabel.labelControl1.Text = item.LabelText;
                userLabel.labelControl1.Tag = item.LabelTag;
                userLabel.Location = new Point(item.LabelLocation_X, item.LabelLocation_X);
                userLabelControls.Add(userLabel);
            }
            return userLabelControls;
        }
        public UserControlTextBox CreateUserTextBox(int Count)
        {
            UserControlTextBox userTextBox = new UserControlTextBox();
            userTextBox.Name = $"UserTextBox{Count}";
            userTextBox.UserTag = counter;
            userTextBox.Tag = counter;
            userTextBox.Width = 100;
            userTextBox.Height = 100;
            userTextBox.Location = new Point(0, 0);
            return userTextBox;
        }
        public List<UserControlTextBox> CreateUserLabel(List<TextBoxClass> textBoxClass)
        {
            List<UserControlTextBox> userTextBoxControls = new List<UserControlTextBox>();
            foreach (var item in textBoxClass)
            {
                UserControlTextBox userTextBox = new UserControlTextBox();
                userTextBox.Name = item.TextBoxName;
                userTextBox.textEdit1.Text = item.TextBoxText;
                userTextBox.textEdit1.Tag = item.TextBoxTag;
                userTextBox.Location = new Point(item.TextBoxLocation_X, item.TextBoxLocation_Y);
                userTextBoxControls.Add(userTextBox);
            }
            return userTextBoxControls;
        }
    }
}
