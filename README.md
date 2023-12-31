﻿# WarehouseApp
Разработать консольное .NET приложение для склада, удовлетворяющее следующим требованиям:

Построить иерархию классов, описывающих объекты на складе - паллеты и коробки:

- Помимо общего набора стандартных свойств (ID, ширина, высота, глубина, вес), паллета может содержать в себе коробки.
- У коробки должен быть указан срок годности или дата производства. Если указана дата производства, то срок годности вычисляется из даты производства плюс 100 дней.
- Срок годности паллеты вычисляется из наименьшего срока годности коробки, вложенной в паллет. Вес паллеты вычисляется из суммы веса вложенных коробок + 30кг.
- Объем коробки вычисляется как произведение ширины, высоты и глубины.
- Объем паллеты вычисляется как сумма объема всех находящихся на ней коробок и произведения ширины, высоты и глубины паллеты.
- Каждая коробка не должна превышать по размерам паллету (по ширине и длине).

Консольное приложение:

-(Опционально) Организовать запись и чтение коллекции в/из файл(а).
-Вывести на экран:
-Сгруппировать все паллеты по сроку годности, отсортировать по возрастанию срока годности, в каждой группе отсортировать паллеты по весу.
- 3 паллеты, которые содержат коробки с наибольшим сроком годности, отсортированные по возрастанию объема.
- (Опционально) Покрыть функционал unit-тестами.

# Пример использования библиотеки:
<pre><code class="language-csharp">
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

</code></pre>

