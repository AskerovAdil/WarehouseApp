using WarehouseApp.Models;
using System;

namespace WarehouseApp
{
    internal class Program
    {
        static void Main()
        {
            var storage = new Storage();

            var pallet1 = new Pallet(1, 100, 100, 100);
            pallet1.AddBox(new Box(1, 50, 50, 50, 10, DateTime.Now));
            pallet1.AddBox(new Box(2, 50, 50, 50, 20, DateTime.Now));
            pallet1.AddBox(new Box(3, 50, 50, 50, 30, DateTime.Now));
            storage.AddPalletIfNotExists(pallet1);

            var pallet2 = new Pallet(2, 100, 100, 100);
            pallet2.AddBox(new Box(4, 50, 50, 50, 10, new DateTime(2023, 2, 10)));
            pallet2.AddBox(new Box(5, 50, 50, 50, 20, new DateTime(2023, 3, 01)));
            pallet2.AddBox(new Box(6, 50, 50, 50, 30, DateTime.Now));
            storage.AddPalletIfNotExists(pallet2);

            var pallet3 = new Pallet(3, 100, 100, 100);
            pallet3.AddBox(new Box(7, 50, 50, 50, 10, new DateTime(2020, 2, 1)));
            pallet3.AddBox(new Box(8, 50, 50, 50, 20, DateTime.Now));
            pallet3.AddBox(new Box(9, 50, 50, 50, 30, DateTime.Now));
            storage.AddPalletIfNotExists(pallet3);

            var pallet4 = new Pallet(3, 100, 100, 100);
            pallet4.AddBox(new Box(7, 50, 50, 50, 10, DateTime.Now));
            pallet4.AddBox(new Box(8, 50, 50, 50, 20, DateTime.Now));
            pallet4.AddBox(new Box(9, 50, 50, 50, 30, DateTime.Now));
            storage.AddPalletIfNotExists(pallet4);


            storage.PrintPalletsByExpirationDate();
            storage.PrintPalletsWithLongestExpirationDate(3);

            Console.ReadKey();
            Console.WriteLine("\nWrite data to file..");

            var storageFileManager = new StorageFileManager();
            storageFileManager.SaveToFile(storage, "data.csv");

            Console.ReadKey();
            Console.WriteLine("\nRead data from file..");
            storage = storageFileManager.LoadFromFile("data.csv");
            storage.PrintPalletsByExpirationDate();
            storage.PrintPalletsWithLongestExpirationDate(3);
        }
    }
}
