using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_klass_work1.EfContext
{
    public class Department
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public DateTime? DeleteDt { get; set; }
        public String? InternationlName {  get; set; }
        public List<Manager> MainWorkers { get; set; }
        public IEnumerable<Manager> SecondaryWorkers { get; set; }
    }
}
