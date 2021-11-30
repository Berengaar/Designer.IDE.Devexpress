using BdkAutomation.Scada.BAL.Concrete.EventEditor;
using BdkAutomation.Scada.BAL.Concrete.Generator;
using BdkAutomation.Scada.BAL.Concrete.PlcItemsOperations;
using BdkAutomation.Scada.BAL.Concrete.Project;
using BdkAutomation.Scada.BAL.Concrete.Tab_Page_Operations;
using BdkAutomation.Scada.HelperLayer.PlcTagHelper;
using BdkAutomation.Scada.HelperLayer.TabPageHelper;
using BdkAutomation.Scada.JDAL.Concrete;
using BdkAutomation.Scada.Models.HelperModels;
using BdkAutomation.Scada.Models.JsonModels;
using BdkAutomation.Scada.Models.UserControls.GeneralUserControls;
using BdkAutomation.Scada.Models.UserControls.ProjectControls;
using BdkAutomation.Scada.UI.Helper;
using BdkAutomation.Scada.UI.HelperForms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using DevExpress.XtraTreeList;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BdkAutomation.Scada.UI
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        CreateFormObject createObject = new CreateFormObject();
        List<UserControlButton> listUserButton = new List<UserControlButton>();
        List<UserControlLabel> listUserLabel = new List<UserControlLabel>();
        List<UserControlTextBox> listUserTextBox = new List<UserControlTextBox>();
        EditMods editMods = new EditMods();
        Point ObjectLoc = new Point();
        int ObjectWidh = 0;
        int ObjectHeight = 0;
        public frmMain()
        {
            InitializeComponent();
            xtraTabControlPages.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
        }
        PanelControl selectedPanelControl = new PanelControl();
        private void CreateObj(object sender, RowClickEventArgs e)
        {
            TreeList tree = (TreeList)sender;
            string selectedGaugeScreen = string.Empty;
            var objName = tree.FocusedNode.GetDisplayText(0);
            foreach (PanelControl panel in xtraTabControlPages.SelectedTabPage.Controls)
            {
                selectedPanelControl = panel;
            }
            switch (objName)
            {
                case "Button":
                    UserControlButton userControlButton = new UserControlButton();
                    userControlButton = createObject.CreateUserButton(ButtonTagCounter.butonTag);
                    userControlButton.simpleButton1.Click += prop;
                    userControlButton.simpleButton1.MouseDown += new MouseEventHandler(PropInfo);
                    userControlButton.simpleButton1.MouseMove += new MouseEventHandler(ObjectEdit);
                    userControlButton.simpleButton1.MouseHover += new EventHandler(Object_MouseHover);
                    userControlButton.simpleButton1.MouseLeave += new EventHandler(Object_MouseLeave);
                    selectedPanelControl.Controls.Add(userControlButton);
                    listUserButton.Add(userControlButton);
                    ButtonTagCounter.butonTag++;
                    break;

                case "Label":
                    UserControlLabel userControlLabel = new UserControlLabel();
                    userControlLabel = createObject.CreateUserLabel(LabelTagCounter.labelTag);
                    userControlLabel.labelControl1.Click += prop;
                    userControlLabel.labelControl1.MouseDown += new MouseEventHandler(PropInfo);
                    userControlLabel.labelControl1.MouseMove += new MouseEventHandler(ObjectEdit);
                    userControlLabel.labelControl1.MouseHover += new EventHandler(Object_MouseHover);
                    userControlLabel.labelControl1.MouseLeave += new EventHandler(Object_MouseLeave);
                    selectedPanelControl.Controls.Add(userControlLabel);
                    listUserLabel.Add(userControlLabel);
                    LabelTagCounter.labelTag++;
                    break;
                case "TextBox":
                    UserControlTextBox userControlTextBox = new UserControlTextBox();
                    userControlTextBox = createObject.CreateUserTextBox(TextBoxTagCounter.TextBoxTag);
                    userControlTextBox.textEdit1.Click += prop;
                    userControlTextBox.textEdit1.MouseDown += new MouseEventHandler(PropInfo);
                    userControlTextBox.textEdit1.MouseMove += new MouseEventHandler(ObjectEdit);
                    userControlTextBox.textEdit1.MouseHover += new EventHandler(Object_MouseHover);
                    userControlTextBox.textEdit1.MouseLeave += new EventHandler(Object_MouseLeave);
                    selectedPanelControl.Controls.Add(userControlTextBox);
                    listUserTextBox.Add(userControlTextBox);
                    TextBoxTagCounter.TextBoxTag++;
                    break;
            }
        }
        public void prop(object sender, EventArgs e)
        {
            string type = sender.GetType().ToString().Substring(23);
            switch (type)
            {
                case "SimpleButton":
                    int butonTag = Convert.ToInt32(((SimpleButton)sender).Tag);
                    propertyGridControl1.SelectedObject = listUserButton[butonTag];
                    break;

                case "LabelControl":
                    int labelTag = Convert.ToInt32(((LabelControl)sender).Tag);
                    propertyGridControl1.SelectedObject = listUserLabel[labelTag];
                    break;
                case "TextEdit":
                    int textBoxTag = Convert.ToInt32(((TextEdit)sender).Tag);
                    propertyGridControl1.SelectedObject = listUserTextBox[textBoxTag];
                    break;
            }

            if (editMods == EditMods.Delete)
            {
                DialogResult s = XtraMessageBox.Show("Objeyi Silmek İstiyor musunuz?", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                switch (sender.GetType().ToString().Substring(23))
                {
                    case "SimpleButton":
                        var buttonTagController = ((SimpleButton)sender).Tag;
                        foreach (var item in selectedPanelControl.Controls)
                        {
                            if (item is UserControlButton)
                            {
                                if (((UserControlButton)item).UserTag.ToString() == buttonTagController.ToString())
                                {
                                    selectedPanelControl.Controls.Remove((Control)item);
                                }
                            }
                        }
                        break;
                    case "LabelControl":
                        var labelTagController = ((LabelControl)sender).Tag;
                        foreach (var item in selectedPanelControl.Controls)
                        {
                            if (item is UserControlLabel)
                            {
                                if (((UserControlLabel)item).UserTag.ToString() == labelTagController.ToString())
                                {
                                    selectedPanelControl.Controls.Remove((Control)item);
                                }
                            }
                        }
                        break;
                    case "TextEdit":
                        var textBoxTagController = ((TextEdit)sender).Tag;
                        foreach (var item in selectedPanelControl.Controls)
                        {
                            if (item is UserControlTextBox)
                            {
                                if (((UserControlTextBox)item).UserTag.ToString() == textBoxTagController.ToString())
                                {
                                    selectedPanelControl.Controls.Remove((Control)item);
                                }
                            }
                        }
                        break;
                }
                Control ctrl = (Control)sender;
                if (s == DialogResult.OK)
                {
                    selectedPanelControl.Controls.Remove(ctrl);
                }
            }
        }


        //Todo : Move yaparken hassasiyeti sağlayan class
        private void PropInfo(object sender, MouseEventArgs e)
        {
            ObjectLoc = new Point();
            ObjectWidh = 0;
            ObjectHeight = 0;
            var objectType = sender.GetType().Name.ToString();
            switch (objectType)
            {
                case "SimpleButton":
                    SimpleButton newButton = (SimpleButton)sender;
                    ObjectLoc = e.Location;
                    ObjectWidh = newButton.Size.Width;
                    ObjectHeight = newButton.Size.Height;
                    break;
            }

        }


        private void ObjectEdit(object sender, MouseEventArgs e)
        {
            AppearanceEditor editor = new AppearanceEditor();
            string editObjectType = sender.GetType().ToString().Substring(23);
            if (e.Button == MouseButtons.Left)
            {
                switch (editObjectType)
                {
                    case "SimpleButton":
                        //SimpleButton newButton = (SimpleButton)sender;
                        editor.ButtonEditor(sender, e, this.Cursor, editMods, listUserButton, ObjectLoc, ObjectWidh, ObjectHeight);
                        break;
                    case "LabelControl":
                        //UserControlButton newButton = (UserControlButton)sender;
                        editor.LabelEditor(sender, e, this.Cursor, editMods, listUserLabel, ObjectLoc, ObjectWidh, ObjectHeight);
                        break;
                    case "TextEdit":
                        //UserControlButton newButton = (UserControlButton)sender;
                        editor.TextBoxEditor(sender, e, this.Cursor, editMods, listUserTextBox, ObjectLoc, ObjectWidh, ObjectHeight);
                        break;
                }
            }
        }
        private void ObjectEditMods(object sender, ItemClickEventArgs e)
        {
            int Tag = Convert.ToInt16(e.Item.Tag);
            editMods = (EditMods)Tag;
            barlblMods.Caption = $"Active Mod:{editMods}";

        }
        private void Object_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void Object_MouseHover(object sender, EventArgs e)
        {
            if (editMods == EditMods.Move)
            {
                this.Cursor = System.Windows.Forms.Cursors.SizeAll;
            }
        }
        //To do : Project Operations
        private void FileProcess(object sender, ItemClickEventArgs e)
        {
            int Tag = Convert.ToInt16(e.Item.Tag);
            ProjectCRUD projectCRUD = new ProjectCRUD();
            switch (Tag)
            {
                case 0:
                    projectCRUD.ProjectCreate(selectedPanelControl, propertyGridControl1);
                    break;
                case 1:
                    ProjectOpen();
                    break;
                case 2:
                    projectCRUD.ProjectSave(selectedPanelControl);
                    break;
                default:
                    break;
            }
        }
        private void ProjectOpen()
        {
            var filePath = string.Empty;
            using (XtraOpenFileDialog openFileDialog = new XtraOpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c\\";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    ObjectCreator jsonReader = new ObjectCreator();
                    listUserButton.Clear();
                    listUserLabel.Clear();
                    listUserTextBox.Clear();
                    selectedPanelControl.Controls.Clear();
                    CreateButton(jsonReader.GetButtons(filePath));
                    CreateLabel(jsonReader.GetLabel(filePath));
                    CreateTextBox(jsonReader.GetTextBox(filePath));
                }
            }
        }

        private void buttonRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult refreshDialog =
                XtraMessageBox.Show("Sayfayı yinelemek istiyor musunuz?", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (refreshDialog == DialogResult.OK)
            {
                selectedPanelControl.Controls.Clear();
                listUserButton.Clear();
                listUserLabel.Clear();
                listUserTextBox.Clear();
                ButtonTagCounter.butonTag = 0;
            }
        }

        #region Creator
        //To do : Json Object Creator
        CreateFormObject formObjects = new CreateFormObject();
        private void CreateButton(List<ButtonsClass> btnClss)
        {
            foreach (var item in formObjects.CreateUserButton(btnClss))
            {
                UserControlButton userControlButton = new UserControlButton();
                userControlButton = item;
                userControlButton.simpleButton1.Click += prop;
                userControlButton.simpleButton1.MouseDown += new MouseEventHandler(PropInfo);
                userControlButton.simpleButton1.MouseMove += new MouseEventHandler(ObjectEdit);
                userControlButton.simpleButton1.MouseHover += new EventHandler(Object_MouseHover);
                userControlButton.simpleButton1.MouseLeave += new EventHandler(Object_MouseLeave);
                listUserButton.Add(userControlButton);
                panelControl.Controls.Add(userControlButton);
            }
        }
        private void CreateLabel(List<LabelClass> lblClss)
        {
            foreach (var item in formObjects.CreateUserLabel(lblClss))
            {
                UserControlLabel userControlLabel = new UserControlLabel();
                userControlLabel = item;
                userControlLabel.labelControl1.Click += prop;
                userControlLabel.labelControl1.MouseDown += new MouseEventHandler(PropInfo);
                userControlLabel.labelControl1.MouseMove += new MouseEventHandler(ObjectEdit);
                userControlLabel.labelControl1.MouseHover += new EventHandler(Object_MouseHover);
                userControlLabel.labelControl1.MouseLeave += new EventHandler(Object_MouseLeave);
                listUserLabel.Add(userControlLabel);
                panelControl.Controls.Add(userControlLabel);
            }
        }

        private void CreateTextBox(List<TextBoxClass> txtClss)
        {
            foreach (var item in formObjects.CreateUserLabel(txtClss))
            {
                UserControlTextBox userControlTextBox = new UserControlTextBox();
                userControlTextBox = item;
                userControlTextBox.textEdit1.Click += prop;
                userControlTextBox.textEdit1.MouseDown += new MouseEventHandler(PropInfo);
                userControlTextBox.textEdit1.MouseMove += new MouseEventHandler(ObjectEdit);
                userControlTextBox.textEdit1.MouseHover += new EventHandler(Object_MouseHover);
                userControlTextBox.textEdit1.MouseLeave += new EventHandler(Object_MouseLeave);
                listUserTextBox.Add(userControlTextBox);
                panelControl.Controls.Add(userControlTextBox);
            }
        }
        #endregion

        private void buttonPlcItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            plcOp.CreatePlcItems(selectedPanelControl, dataGridView1, selectedIndexList);
        }

        System.Windows.Forms.ComboBox comb;     //Winform mu devexpress mi olduğunu belirtmek zorundayız.

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            comb = e.Control as System.Windows.Forms.ComboBox;
            if (comb != null)
            {
                // Attach new event if change selection
                comb.SelectedIndexChanged -= new EventHandler(comb_SelectedIndexChanged);

                //Adding event
                comb.SelectedIndexChanged += comb_SelectedIndexChanged;
            }
        }
        private void comb_SelectedIndexChanged(object sender, EventArgs e)
        {
            plcOp.SelectedIndexChanged(sender, selectedIndexList);
        }
        List<SelectedIndexClass> selectedIndexList = new List<SelectedIndexClass>();
        PlcItemOp plcOp = new PlcItemOp();
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            plcOp.ChangeRow(selectedPanelControl, dataGridView1, selectedIndexList);
        }
        private void buttonPages_ItemClick(object sender, ItemClickEventArgs e)
        {
            TabPageOperationClass tabPageOperationClass = new TabPageOperationClass();
            int tabPageTag = Convert.ToInt16(e.Item.Tag);
            switch (Convert.ToInt16(e.Item.Tag))
            {
                case 0:
                    AddTabPage(tabPageOperationClass, tabPageTag);
                    break;
                case 1:
                    xtraTabControlPages.TabPages.Remove(xtraTabControlPages.SelectedTabPage);
                    break;
            }
        }
        private void AddTabPage(TabPageOperationClass tabPageOperationClass, int tabPageTag)
        {
            #region PopUp
            TabPageClass.PopUpOpenClose = true;
            TabPageNamePopUp popUpForm = new TabPageNamePopUp();
            if (TabPageClass.PopUpOpenClose)
            {
                #region Form
                popUpForm.ShowDialog();
                #endregion
                PanelControl newPanelControl = new PanelControl();
                tabPageOperationClass.AddItems(tabPageTag, newPanelControl, xtraTabControlPages);
            }
            else
            {
                popUpForm.Close();
            }
            #endregion
        }

        private void btnViewMenu_ItemClick(object sender, ItemClickEventArgs e)
        {
            int viewMenuTag = Convert.ToInt16(e.Item.Tag);
            GetViewMenus(viewMenuTag);
        }

        public void GetViewMenus(int viewMenuTag)
        {
            switch (viewMenuTag)
            {
                case 0:
                        dockPanelToolbox.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
                    break;
                case 1:
                    dockPanelSolution.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
                    break;
                case 2:
                    dockPanelPageNavigator.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
                    break;
            }
        }

        private void UIBtnPageNavigate_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            int UIBtnTag = Convert.ToInt16(e.Button.Properties.Tag);
            //int selectedPageIndex = xtraTabControlPages.SelectedTabPageIndex;

            //foreach (XtraTabPage item in xtraTabControlPages.TabPages)
            //{
            //    item.tab
            //}
            //switch (UIBtnTag)
            //{
            //    case 0:
            //        xtraTabControlPages.SelectedTabPage = xtraTabControlPages.sele
            //        break;
            //    case 1:
            ////        break;
            //}
        }
    }
}