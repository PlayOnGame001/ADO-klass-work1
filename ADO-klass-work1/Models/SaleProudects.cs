using ADO_klass_work1.EfContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_klass_work1.Models
{
    public class SaleProudects
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }
        public Guid ManagerId { get; set; }
        public DateTime SaleDt { get; set; }
        public DateTime? DeleteDt { get; set; }

        ///////////////////NAVIGATION///////////////
        public Manager Manager { get; set; }
        public Product Product { get; set; }

        public static SaleProudects FromEntity(Sale entity) => new() // Mapping - перетворення моделей
        {
            Id = entity.Id,
            Quantity = entity.Quantity,
            ManagerId = entity.ManagerId
        };
    }
}
