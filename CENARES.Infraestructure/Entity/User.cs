using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CENARES.Infraestructure.Entity
{
    public class User
    {
        public int IDE_USER { get; set; }
        public string CODE { get; set; }
        public string NAME { get; set; }
        public string PASSWORD { get; set; }
        public string TYPE { get; set; }
        public string STATESESSION { get; set; }
        public string GUIDSESSION { get; set; }
        public DateTime LASTINITSESSION { get; set; }
        public string FLG_STATUS { get; set; }
    }
}
