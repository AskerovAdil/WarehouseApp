using WarehouseApp.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseApp.Models
{
    public class Pallet : StorageItem
    {
        private readonly List<Box> _boxes = new List<Box>();
        public Pallet(int id, double width, double height, double depth)
            : base(id, width, height, depth)
        {
            int _minWeighyPallet = 30;
            Weight = _minWeighyPallet;
        }
        
        public DateTime? ExpirationDate => _boxes.Count > 0 ? _boxes.Min(b => b.ExpirationDate) : null;
        public double Volume => _boxes.Sum(b => b.Volume) + Width * Height * Depth;

        public List<Box> GetBoxes()
        {
            return _boxes;
        }

        public void AddBox(Box box)
        {
            if (CanAddBox(box))
            {
                _boxes.Add(box);
                Weight += box.Weight;
            }
        }

        private bool CanAddBox(Box box)
        {
            return (box.Width < Width && box.Height < Height) ||
                   (box.Width < Height && box.Height < Width);
        }
    }

}
