using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BdkAutomation.Scada.HelperLayer.TabPageHelper
{
    public static class TabPageClass
    {
        public static int AmountOfTabPage { get; set; } = 0;
        public static string TabPageName { get; set; } = "";
        //Open = true, Close = false
        public static bool PopUpOpenClose { get; set; } = false;
    }
}
