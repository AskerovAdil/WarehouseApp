using System;
using System.Collections.Generic;
using System.Linq;

namespace WarehouseApp.Models
{
    public class Storage
    {

        private readonly List<Pallet> _pallets = new List<Pallet>();

        public Pallet AddPalletIfNotExists(Pallet newPallet)
        {
            var pallet = _pallets.FirstOrDefault(p => p.Id == newPallet.Id);
            if (pallet == null)
                _pallets.Add(newPallet);
            
            return pallet;
        }

        public IEnumerable<Pallet> GetPallets()
        {
            return _pallets;
        }

        public void PrintPalletsByExpirationDate()
        {
            var palletsByExpirationDate = _pallets
                .Where(p => p.ExpirationDate.HasValue)
                .OrderBy(p => p.ExpirationDate)
                .ThenBy(p => p.Weight)
                .GroupBy(p => p.ExpirationDate.Value.Date);

            foreach (var group in palletsByExpirationDate)
            {
                Console.WriteLine($"Pallets with expiration date {group.Key.ToShortDateString()}:");

                foreach (var pallet in group)
                {
                    Console.WriteLine($"- Pallet {pallet.Id}, weight: {pallet.Weight}");
                }
            }
        }

        public void PrintPalletsWithLongestExpirationDate(int count)
        {
            var palletsByExpirationDate = _pallets
                .Where(p => p.ExpirationDate.HasValue)
                .OrderByDescending(p => p.ExpirationDate)
                .Take(count)
                .OrderBy(p => p.Volume);

            Console.WriteLine($"Top {count} pallets with longest expiration date:");

            foreach (var pallet in palletsByExpirationDate)
            {
                Console.WriteLine($"- Pallet {pallet.Id}, volume: {pallet.Volume}");
            }
        }
    }
}
