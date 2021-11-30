using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BdkAutomation.Scada.Models.JsonModels
{
    public class LabelClass
    {
        public string LabelName { get; set; }
        public string LabelTag { get; set; }

        public string LabelText { get; set; }
        public int LabelLocation_X { get; set; }
        public int LabelLocation_Y { get; set; }
    }
}
