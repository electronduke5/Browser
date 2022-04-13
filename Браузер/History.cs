using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Браузер
{
    [Serializable]
    public class History
    {
        public string URL { get; set; }
        public string Time { get; set; }
        public string Date { get; set; }
    }
}
