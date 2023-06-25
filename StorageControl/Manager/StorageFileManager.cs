using WarehouseApp.Abstract;
using WarehouseApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseApp
{
    public class StorageFileManager
    {
        public Storage LoadFromFile(string filePath)
        {
            var storage = new Storage();

            using (var reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    var palletId = int.Parse(values[0]);
                    var boxId = int.Parse(values[1]);
                    var width = double.Parse(values[2]);
                    var height = double.Parse(values[3]);
                    var depth = double.Parse(values[4]);
                    var weight = double.Parse(values[5]);
                    var productionDate = DateTime.Parse(values[6]);

                    var pallet = new Pallet(palletId, 100, 100, 100);
                    storage.AddPalletIfNotExists(pallet);

                    var box = new Box(boxId, width, height, depth, weight, productionDate);
                    pallet.AddBox(box);
                }
            }

            return storage;
        }

        public void SaveToFile(Storage storage, string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            {
                foreach (var pallet in storage.GetPallets())
                {
                    foreach (var box in pallet.GetBoxes())
                    {
                        var line = $"{pallet.Id},{box.Id},{box.Width},{box.Height},{box.Depth},{box.Weight},{box.ProductionDate.ToShortDateString()}";
                        writer.WriteLine(line);
                    }
                }
            }
        }

    }
}