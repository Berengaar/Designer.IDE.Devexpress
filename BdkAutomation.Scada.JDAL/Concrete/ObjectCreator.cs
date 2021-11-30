using BdkAutomation.Scada.Models.JsonModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BdkAutomation.Scada.JDAL.Concrete
{
    public class ObjectCreator
    {
        public List<ButtonsClass> GetButtons(string FilePath)
        {
            ButtonsClass btnClass = new ButtonsClass();
            List<ButtonsClass> items = new List<ButtonsClass>();

            if (!string.IsNullOrEmpty(FilePath))
            {
                var readFile = File.ReadAllText(FilePath);
                var jObject = JObject.Parse(readFile);
                if (jObject != null)
                {
                    JArray experiencesArrary = (JArray)jObject["Button"];
                    if (experiencesArrary != null)
                    {
                        foreach (var item in experiencesArrary)
                        {
                            btnClass = new ButtonsClass
                            {
                                ButtonName = item["ButtonName"].ToString(),
                                ButtonTag = item["ButtonTag"].ToString(),
                                ButtonText = item["ButtonText"].ToString(),
                                ButtonWidth = Convert.ToInt32(item["ButtonWidth"].ToString()),
                                ButtonHeight = Convert.ToInt32(item["ButtonHeight"].ToString()),
                                ButtonLocation_X = Convert.ToInt32(item["ButtonLocation_X"].ToString()),
                                ButtonLocation_Y = Convert.ToInt32(item["ButtonLocation_Y"].ToString()),
                            };
                            items.Add(btnClass);
                        }
                    }
                }
            }
            return items;
        }

        public List<LabelClass> GetLabel(string FilePath)
        {
            LabelClass lblClass = new LabelClass();
            List<LabelClass> items = new List<LabelClass>();

            if (!string.IsNullOrEmpty(FilePath))
            {
                var readFile = File.ReadAllText(FilePath);
                var jObject = JObject.Parse(readFile);
                if (jObject != null)
                {
                    JArray experiencesArrary = (JArray)jObject["Label"];
                    if (experiencesArrary != null)
                    {
                        foreach (var item in experiencesArrary)
                        {
                            lblClass = new LabelClass
                            {
                                LabelName = item["LabelName"].ToString(),
                                LabelText = item["LabelText"].ToString(),
                                LabelTag = item["LabelTag"].ToString(),
                                LabelLocation_X = Convert.ToInt32(item["LabelLocation_X"].ToString()),
                                LabelLocation_Y = Convert.ToInt32(item["LabelLocation_Y"].ToString()),
                            };
                            items.Add(lblClass);
                        }
                    }
                }
            }
            return items;
        }

        public List<TextBoxClass> GetTextBox(string FilePath)
        {
            TextBoxClass txtClass = new TextBoxClass();
            List<TextBoxClass> items = new List<TextBoxClass>();

            if (!string.IsNullOrEmpty(FilePath))
            {
                var readFile = File.ReadAllText(FilePath);
                var jObject = JObject.Parse(readFile);
                if (jObject != null)
                {
                    JArray experiencesArrary = (JArray)jObject["TextBox"];
                    if (experiencesArrary != null)
                    {
                        foreach (var item in experiencesArrary)
                        {
                            txtClass = new TextBoxClass
                            {
                                TextBoxName = item["TextBoxName"].ToString(),
                                TextBoxText = item["TextBoxText"].ToString(),
                                TextBoxTag = item["TextBoxTag"].ToString(),
                                TextBoxLocation_X = Convert.ToInt32(item["TextBoxLocation_X"].ToString()),
                                TextBoxLocation_Y = Convert.ToInt32(item["TextBoxLocation_Y"].ToString()),
                            };
                            items.Add(txtClass);
                        }
                    }
                }
            }
            return items;
        }
    }
}
