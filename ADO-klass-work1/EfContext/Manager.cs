﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_klass_work1.EfContext
{ 
    public class Manager
    {
        public Guid Id { get; set; }
        public String Surname { get; set; }
        public String Name { get; set; }
        public String Secname { get; set; }
        public Guid IdMainDep { get; set; }
        public Guid? IdSecDep { get; set; }
        public Guid? IdChief { get; set; }
        public DateTime? DeleteDt { get; set; }
        public Department MainDepartment { get; set; } 
        public Department? SecondaryDepartment { get; set; }

        public Manager? Chief { get; set; }
        public IEnumerable<Manager> Subordinates { get; set; }
        public IEnumerable<Sale> Sales {  get; set; }

    }
}
