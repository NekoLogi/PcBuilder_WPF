using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCBuilding
{
    class Components
    {
        //CPU
        public string CPU_Brand { get; set; }
        public string CPU_Series { get; set; }
        public string CPU_Model { get; set; }
        public string CPU_Socket { get; set; }
        public string CPU_Memtype { get; set; }

        //Mainboard
        public string MB_Brand { get; set; }
        public string MB_Series { get; set; }
        public string MB_Socket { get; set; }
    }
}
