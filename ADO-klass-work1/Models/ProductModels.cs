using ADO_klass_work1.EfContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_klass_work1.Models
{
    public class ProductModels
    {
        public Guid Id { get; private set; }
        public String Name { get; set; }
        public double Price { get; set; }

        public static ProductModels FromEntity(Product entity) => new() // Mapping - перетворення моделей
        {
            Id = entity.Id,
            Name = entity.Name,
            Price = entity.Price
        };
    }
}
