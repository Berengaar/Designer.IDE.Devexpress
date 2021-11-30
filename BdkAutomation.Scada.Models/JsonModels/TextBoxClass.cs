using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BdkAutomation.Scada.Models.JsonModels
{
    public class TextBoxClass
    {
        public string TextBoxName { get; set; }
        public string TextBoxTag { get; set; }

        public string TextBoxText { get; set; }
        public int TextBoxLocation_X { get; set; }
        public int TextBoxLocation_Y { get; set; }
    }
}
