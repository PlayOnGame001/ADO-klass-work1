using ADO_klass_work1.EfContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_klass_work1.Models
{
    public class DepartmentModel
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public string? InternationalName { get; set; }
        public DateTime? DeletDt {  get; set; }
        public static DepartmentModel FromEntity(Department entity) => new() //Maping - пересоздание моделей
        {
            Id = entity.Id,
            Name = entity.Name,
            InternationalName = entity.InternationlName,
            //DeletDt = entity.DeleteDt,
        };
    }
}
