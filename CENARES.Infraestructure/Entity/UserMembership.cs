using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CENARES.Infraestructure.Entity
{
    public class UserMembership
    {
        public int IDE_MEMBER { get; set; }
        public int IDE_USER { get; set; }
        public string USER_TYPE { get; set; }
        public string FISRT_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public string DOMAIN { get; set; }
        public string ADDRESS { get; set; }
        public string FLG_STATUS { get; set; }
        public DateTime CREATE_DATE { get; set; }
        public string CREATE_USER { get; set; }
    }
}
