using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_klass_work1.Models
{
    public class IdName
    {
        public Guid Id { get; set; }  
        public String Name { get; set; }
        //public String Description = "";
        public override string ToString() => Name;
    }
}
