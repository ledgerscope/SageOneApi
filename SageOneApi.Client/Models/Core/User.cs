using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SageOneApi.Client.Models.Core
{
    public class User : SageOneCoreEntity
    {
        public string first_name { get; set; }
        public string lasst_name { get; set; }
        public string initials { get; set; }
        public string email { get; set; }
        public string locale { get; set; }
    }
}
