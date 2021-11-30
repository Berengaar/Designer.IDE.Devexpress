using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BdkAutomation.Scada.Models.UserControls.GeneralUserControls;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;

namespace BdkAutomation.Scada.JDAL.Concrete
{
    public class JsonGenerator
    {
        //Todo : Json Record 
        public void GeneratorJArray(List<UserControlButton> buttonList, List<UserControlLabel> labelList, List<UserControlTextBox> textBoxList,string path)
        {
            JObject jList = new JObject();
            JArray jButtonArray = new JArray();
            JArray jLabelArray = new JArray();
            JArray jTextBoxArray = new JArray();

            foreach (var item in buttonList)
            {
                JObject jButton = new JObject();
                jButton.Add(new JProperty("ButtonName", item.UserButtonName));
                jButton.Add(new JProperty("ButtonTag", item.simpleButton1.Tag));
                jButton.Add(new JProperty("TextBoxWidth", item.UserTag));
                jButton.Add(new JProperty("ButtonText", item.simpleButton1.Text));
                jButton.Add(new JProperty("ButtonLocation_X", item.Location.X));
                jButton.Add(new JProperty("ButtonLocation_Y", item.Location.Y));
                jButton.Add(new JProperty("ButtonWidth", item.Width));
                jButton.Add(new JProperty("ButtonHeight", item.Height));


                jButtonArray.Add(jButton);
            }
            foreach (var item in labelList)
            {
                JObject jLabel = new JObject();
                jLabel.Add(new JProperty("LabelName", item.UserLabelName));
                jLabel.Add(new JProperty("LabelTag", item.labelControl1.Tag));
                jLabel.Add(new JProperty("TextBoxWidth", item.UserTag));
                jLabel.Add(new JProperty("LabelText", item.labelControl1.Text));
                jLabel.Add(new JProperty("LabelLocation_X", item.Location.X));
                jLabel.Add(new JProperty("LabelLocation_Y", item.Location.Y));
                /*Events*/
                jLabelArray.Add(jLabel);
            }
            foreach (var item in textBoxList)
            {
                JObject jTextBox = new JObject();
                jTextBox.Add(new JProperty("TextBoxName", item.UserLabelName));
                jTextBox.Add(new JProperty("TextBoxText", item.textEdit1.Text));
                jTextBox.Add(new JProperty("TextBoxTag", item.textEdit1.Tag));
                jTextBox.Add(new JProperty("TextBoxLocation_X", item.Location.X));
                jTextBox.Add(new JProperty("TextBoxLocation_Y", item.Location.Y));
                jTextBoxArray.Add(jTextBox);
            }

            jList.Add(new JProperty("Button", jButtonArray));
            jList.Add(new JProperty("Label", jLabelArray));
            jList.Add(new JProperty("TextBox", jTextBoxArray));

            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(path))
            {
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, jList);
                }
            }
        }
    }
}
