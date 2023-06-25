using WarehouseApp.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseApp.Models
{
    public class Box : StorageItem
    {
        public DateTime ProductionDate { get; }

        public Box(int id, double width, double height, double depth, double weight, DateTime productionDate)
            : base(id, width, height, depth)
        {
            Weight = weight;
            ProductionDate = productionDate;
        }

        public DateTime? ExpirationDate => ProductionDate.AddDays(100);
        public double Volume => Width * Height * Depth;
    }

}
