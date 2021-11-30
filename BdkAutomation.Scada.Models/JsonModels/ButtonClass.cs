using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BdkAutomation.Scada.Models.JsonModels
{
    public class ButtonsClass
    {
        public string ButtonName { get; set; }
        public string ButtonTag { get; set; }

        public int ButtonWidth { get; set; }
        public int ButtonHeight { get; set; }
        public string ButtonText { get; set; }
        public int ButtonLocation_X { get; set; }
        public int ButtonLocation_Y { get; set; }
    }
}
