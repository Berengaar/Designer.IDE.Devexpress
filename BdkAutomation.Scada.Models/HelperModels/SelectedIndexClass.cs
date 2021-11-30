using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BdkAutomation.Scada.Models.HelperModels
{
    public class SelectedIndexClass
    {
        public int SelectedIndexId { get; set; }
        public string SelectedIndexName { get; set; }
        public string ObjectName { get; set; }

        public string SelectedIndexText { get; set; } = string.Empty;
    }
}
