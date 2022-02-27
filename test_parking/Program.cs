using System;
using System.Collections.Generic;
using System.Linq;

namespace test_parking
{
    public class Program
    {
        static int Lot = 0;
        static Lot[] Lots;

        static void Main(string[] args)
        {
            Console.Write("Masukan Jumlah Lot : ");
            Lot = int.Parse(Console.ReadLine());
            Lots = new Lot[Lot];

            MenuCommand();
        }

        static void MenuCommand()
        {
            Console.Clear();
            Console.WriteLine($"Jumlah Lot {Lot}");
            Console.WriteLine("1. Parkir");
            Console.WriteLine("2. Keluar");
            Console.WriteLine("3. Status");
            Console.WriteLine("4. Total Kendarann Motor");
            Console.WriteLine("5. Total Kendaraan Mobil");
            Console.WriteLine("6. Cari Plat");
            Console.WriteLine("7. Cari Plat Ganjil");
            Console.WriteLine("8. Cari Plat Genap");
            Console.WriteLine("9. Cari Warna");
            Console.Write("Pilih menu : ");
            string command = Console.ReadLine();
            switch (command)
            {
                case "1":
                    Console.Clear();
                    FillLot();
                    MenuCommand();
                    break;
                case "2":
                    Console.Clear();
                    LeaveLot();
                    MenuCommand();
                    break;
                case "3":
                    Console.Clear();
                    Status();
                    MenuCommand();
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine($"Motor : {Lots.Where(x => x != null && x.Type.ToLower() == "motor").Count()}");
                    Console.ReadLine();
                    MenuCommand();
                    break;
                case "5":
                    Console.Clear();
                    Console.WriteLine($"Mobil : {Lots.Where(x => x != null && x.Type.ToLower() == "mobil").Count()}");
                    Console.ReadLine();
                    MenuCommand();
                    break;
                case "6":
                    Console.Clear();
                    FindSlotByPlat();
                    MenuCommand();
                    break;
                case "7":
                    Console.Clear();
                    MenuCommand();
                    break;
                case "8":
                    Console.Clear();
                    MenuCommand();
                    break;
                case "9":
                    Console.Clear();
                    FindByWarna();
                    MenuCommand();
                    break;
                default:
                    MenuCommand();
                    break;
            }
        }

        static void FillLot()
        {
            Console.Write("Type : ");
            string type = Console.ReadLine();
            Console.Write("Plat No : ");
            string platNo = Console.ReadLine();
            Console.Write("Warna : ");
            string warna = Console.ReadLine();

            var idx = Array.FindIndex(Lots, x => x == null);
            if (idx < 0)
            {
                Console.Write($"Slot Penuh");
                Console.ReadLine();
            }
            else
            {
                Array.Fill(Lots, new Lot()
                {
                    Type = type,
                    PlatNo = platNo,
                    Warna = warna
                }, idx, 1);

                Console.Write($"Alokasi Slot : {idx + 1}");
                Console.ReadLine();
            }
        }

        static void LeaveLot()
        {
            Console.Write("Lot : ");
            int idx = int.Parse(Console.ReadLine());
            Lots[idx - 1] = null;

            Console.Write($"Lot {idx} kosong");
            Console.ReadLine();
        }

        static void Status()
        {
            Console.WriteLine($"Slot || Type || Plat No || Warna");
            for (int i = 0; i < Lots.Length; i++)
            {
                if (Lots[i] != null)
                {
                    Console.WriteLine($"{ i + 1 } || { Lots[i].Type } || {Lots[i].PlatNo} || {Lots[i].Warna}");
                }
            }

            Console.ReadLine();
        }

        static void FindSlotByPlat()
        {
            Console.Write("Plat No :");
            string platNo = Console.ReadLine();

            int idx = Array.IndexOf(Lots, Lots.Where(x => x != null && x.PlatNo == platNo).FirstOrDefault());
            if (idx < 0)
            {
                Console.WriteLine("Not Found");
            }
            else
            {
                Console.WriteLine(idx + 1);
            }

            Console.ReadLine();
        }
        static void FindByWarna()
        {
            Console.Write("Warna :");
            string warna = Console.ReadLine();

            Console.WriteLine($"Slot || Type || Plat No || Warna");
            for (int i = 0; i < Lots.Where(x => x != null && x.Warna == warna).Count(); i++)
            {
                if (Lots[i] != null)
                {
                    Console.WriteLine($"{ i + 1 } || { Lots[i].Type } || {Lots[i].PlatNo} || {Lots[i].Warna}");
                }
            }

            Console.ReadLine();
        }
    }

    public class Lot
    {
        public string Type { get; set; }
        public string PlatNo { get; set; }
        public string Warna { get; set; }
    }
}
