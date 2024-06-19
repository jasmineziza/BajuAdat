using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ButikIndonesia
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\t\t\t\t\t   SELAMAT DATANG DI BUTIK INDONESIA ");
            Console.ReadKey();

            Login(); //login
        }

        static void Login()
        {
            var users = new Dictionary<string, string> { { "pengelola", "admin" }, { "peminjam", "guest" } };
            string userNama, password;
            Console.Write("Nama Pengguna: ");
            userNama = Console.ReadLine();
            Console.Write("Password: ");
            password = Console.ReadLine();

            if (users.ContainsKey(userNama) && users[userNama] == password)
            {
                if (userNama == "pengelola")
                {
                    ManagerMenu(); // If the user is a manager (pengelola)
                }
                else if (userNama == "peminjam")
                {
                    BorrowerMenu(); // If the user is a borrower (peminjam)
                }
            }
            else
            {
                Console.WriteLine("UserNama atau password tidak valid. Silakan coba lagi.");
            }
        }

        static void ManagerMenu()
        {
            BajuManager bajuManager = new BajuManager();
            while (true)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Clear();

                Console.WriteLine("\nBUTIK INDONESIA");
                Console.WriteLine("\n\nMENU UTAMA");
                Console.WriteLine("=====================\n");
                Console.WriteLine("[1] Tambahkan Baju");
                Console.WriteLine("[2] Tampilkan Semua Baju");
                Console.WriteLine("[3] Cari Baju");
                Console.WriteLine("[4] Hapus Baju");
                Console.WriteLine("[5] Edit Baju");
                Console.WriteLine("[6] Sewa Baju");
                Console.WriteLine("[7] Kembalikan Baju");
                Console.WriteLine("[8] Daftar Semua Penyewa");
                Console.WriteLine("[9] Cetak Catatan Penyewa Lama");
                Console.WriteLine("[10] Periksa Pakaian Tersedia");
                Console.WriteLine("[0] Keluar");
                Console.WriteLine("=====================\n");
                Console.Write("Masukkan pilihan Anda: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        bajuManager.WriteOnFile();
                        break;
                    case 2:
                        Console.Clear();
                        bajuManager.ReadFromFile();
                        break;
                    case 3:
                        Console.Clear();
                        bajuManager.SearchOnFile();
                        break;
                    case 4:
                        Console.Clear();
                        bajuManager.DeleteFromFile();
                        break;
                    case 5:
                        Console.Clear();
                        bajuManager.EditBaju();
                        break;
                    case 6:
                        Console.Clear();
                        bajuManager.RentBaju();
                        break;
                    case 7:
                        Console.Clear();
                        bajuManager.ReturnBaju();
                        break;
                    case 8:
                        Console.Clear();
                        bajuManager.ListRenters();
                        break;
                    case 9:
                        Console.Clear();
                        bajuManager.PrintOldRenterRecords();
                        break;
                    case 10:
                        Console.Clear();
                        bajuManager.AvailableClothes();
                        break;
                    case 0:
                        Console.Clear();
                        Console.WriteLine("\n\n\n\t\t\t\t\tTerimakasih Telah Menggunakan Jasa Kami.\n\n");
                        Environment.Exit(0);
                        break;
                    default:
                        continue;
                }

                Console.WriteLine("\n\n..::Masukkan Pilihan:\n[1] Menu Utama\t\t[0] Keluar");
                int opt;
                while (!int.TryParse(Console.ReadLine(), out opt))
                {
                    Console.WriteLine("Pilihan tidak valid. Masukkan angka yang valid.");
                    Console.Write("\n\n..::Masukkan Pilihan:\n[1] Menu Utama\t\t[0] Keluar\n");
                }

                if (opt == 0)
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\n\t\t\tTerimakasih telah menggunakan jasa kami.\n\n");
                    Environment.Exit(0);
                }
            }
        }

        static void BorrowerMenu()
        {
            BajuManager bajuManager = new BajuManager();
            while (true)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Clear();

                Console.WriteLine("\nSISTEM MANAJEMEN BAJU");
                Console.WriteLine("\n\nMENU UTAMA");
                Console.WriteLine("=====================\n");
                Console.WriteLine("[3] Cari Baju");
                Console.WriteLine("[9] Periksa Stok Baju");
                Console.WriteLine("[0] Keluar");
                Console.WriteLine("=====================\n");
                Console.Write("Masukkan pilihan Anda: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 3:
                        Console.Clear();
                        bajuManager.SearchOnFile();
                        break;
                    case 9:
                        Console.Clear();
                        bajuManager.AvailableClothes();
                        break;
                    case 0:
                        Console.Clear();
                        Console.WriteLine("\n\n\n\t\t\tTerimakasih telah menggunakan jasa kami.\n\n");
                        Environment.Exit(0);
                        break;
                    default:
                        continue;
                }

                Console.Write("\n\n..::Masukkan Pilihan:\n[1] Menu Utama\t\t[0] Keluar\n");
                int opt = int.Parse(Console.ReadLine());

                if (opt == 0)
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\n\t\t\t\tTerimakasih telah menggunakan jasa kami.\n\n");
                    Environment.Exit(0);
                }
            }
        }
    }
    public class Renter
    {
        public string Nama { get; set; }
        public string BajuDaerah { get; set; }
        public string TanggalKembali { get; set; }

        public Renter() { }

        public Renter(string nama, string bajuDaerah, string tanggalKembali)
        {
            Nama = nama;
            BajuDaerah = bajuDaerah;
            TanggalKembali = tanggalKembali;
        }

        public override string ToString()
        {
            return $"Nama: {Nama}, Baju: {BajuDaerah}, Tanggal Kembali: {TanggalKembali:dd - MM - yyyy}";
        }
    }

    public class Baju
    {
        public string Kode { get; set; }
        public string Nama { get; set; }
        public string Ukuran { get; set; }
        public double Harga { get; set; }

        public Baju(string kode, string nama, string ukuran, double harga)
        {
            Kode = kode;
            Nama = nama;
            Ukuran = ukuran;
            Harga = harga;
        }

        public override string ToString()
        {
            return $"Kode: {Kode}, Nama: {Nama}, Ukuran: {Ukuran}, Harga: Rp.{Harga}";
        }
    }

    public class BajuManager
    {
        private Dictionary<string, Baju> bajuDictionary = new Dictionary<string, Baju>();
        private MinHeap bajuHeap = new MinHeap();
        private List<Renter> renters = new List<Renter>();
        private string filePath = "baju.txt"; // Change the path as needed

        public void WriteOnFile()
        {
            Console.Write("Masukkan Kode Baju: ");
            string kode = Console.ReadLine();
            Console.Write("Masukkan Nama Baju: ");
            string nama = Console.ReadLine();
            Console.Write("Masukkan Ukuran Baju: ");
            string ukuran = Console.ReadLine();
            Console.Write("Masukkan Harga Baju: ");
            double harga = double.Parse(Console.ReadLine());

            Baju baju = new Baju(kode, nama, ukuran, harga);
            bajuDictionary[kode] = baju;
            bajuHeap.Add(baju);

            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine($"{kode},{nama},{ukuran},{harga}");
            }

            Console.WriteLine("Baju berhasil ditambahkan.");
        }

        public void ReadFromFile()
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Data baju tidak ditemukan.");
                return;
            }

            Console.WriteLine("Daftar Baju:");
            foreach (var baju in bajuDictionary.Values)
            {
                Console.WriteLine(baju);
            }
        }

        public void SearchOnFile()
        {
            Console.Write("Masukkan Kode Baju yang Dicari: ");
            string kode = Console.ReadLine();

            if (bajuDictionary.TryGetValue(kode, out Baju baju))
            {
                Console.WriteLine(baju);
            }
            else
            {
                Console.WriteLine("Baju tidak ditemukan.");
            }
        }

        public void DeleteFromFile()
        {
            Console.Write("Masukkan Kode Baju yang Ingin Dihapus: ");
            string kode = Console.ReadLine();

            if (bajuDictionary.Remove(kode))
            {
                // Rebuild heap
                bajuHeap = new MinHeap();
                foreach (var b in bajuDictionary.Values)
                {
                    bajuHeap.Add(b);
                }

                // Update file
                File.WriteAllLines(filePath, bajuDictionary.Values.Select(b => $"{b.Kode},{b.Nama},{b.Ukuran},{b.Harga}"));
                Console.WriteLine("Baju berhasil dihapus.");
            }
            else
            {
                Console.WriteLine("Baju tidak ditemukan.");
            }
        }

        public void EditBaju()
        {
            Console.Write("Masukkan Kode Baju yang Ingin Diedit: ");
            string kode = Console.ReadLine();

            if (bajuDictionary.TryGetValue(kode, out Baju baju))
            {
                Console.Write("Masukkan Nama Baju Baru: ");
                string nama = Console.ReadLine();
                Console.Write("Masukkan Ukuran Baju Baru: ");
                string ukuran = Console.ReadLine();
                Console.Write("Masukkan Harga Baju Baru: ");
                double harga = double.Parse(Console.ReadLine());

                baju.Nama = nama;
                baju.Ukuran = ukuran;
                baju.Harga = harga;

                // Rebuild heap
                bajuHeap = new MinHeap();
                foreach (var b in bajuDictionary.Values)
                {
                    bajuHeap.Add(b);
                }

                // Update file
                File.WriteAllLines(filePath, bajuDictionary.Values.Select(b => $"{b.Kode},{b.Nama},{b.Ukuran},{b.Harga}"));
                Console.WriteLine("Baju berhasil diedit.");
            }
            else
            {
                Console.WriteLine("Baju tidak ditemukan.");
            }
        }

        public void RentBaju()
        {
            Console.Write("Masukkan Kode Baju yang Ingin Disewa: ");
            string kode = Console.ReadLine();

            if (bajuDictionary.TryGetValue(kode, out Baju baju))
            {
                Console.Write("Masukkan Nama Penyewa: ");
                string namaPenyewa = Console.ReadLine();
                Console.Write("Masukkan Tanggal Kembali: ");
                string tanggalKembali = Console.ReadLine();

                Renter renter = new Renter(namaPenyewa, baju.Nama, tanggalKembali);
                renters.Add(renter);
                bajuDictionary.Remove(kode);
                bajuHeap = new MinHeap();
                foreach (var b in bajuDictionary.Values)
                {
                    bajuHeap.Add(b);
                }

                Console.WriteLine("Baju berhasil disewa.");
            }
            else
            {
                Console.WriteLine("Baju tidak ditemukan.");
            }
        }

        public void ReturnBaju()
        {
            Console.Write("Masukkan Nama Penyewa yang Ingin Mengembalikan Baju: ");
            string namaPenyewa = Console.ReadLine();

            Renter renter = renters.FirstOrDefault(r => r.Nama == namaPenyewa);
            if (renter != null)
            {
                Console.Write("Masukkan Kode Baju yang Dikembalikan: ");
                string kode = Console.ReadLine();
                Console.Write("Masukkan Nama Baju yang Dikembalikan: ");
                string namaBaju = Console.ReadLine();
                Console.Write("Masukkan Ukuran Baju yang Dikembalikan: ");
                string ukuran = Console.ReadLine();
                Console.Write("Masukkan Harga Baju yang Dikembalikan: ");
                double harga = double.Parse(Console.ReadLine());

                Baju baju = new Baju(kode, namaBaju, ukuran, harga);
                bajuDictionary[kode] = baju;
                bajuHeap.Add(baju);

                // Tambahkan penyewa ke daftar penyewa lama (OldRenters.txt)
                string line = $"{renter.Nama},{renter.BajuDaerah},{renter.TanggalKembali}";
                using (StreamWriter sw = File.AppendText("OldRenters.txt"))
                {
                    sw.WriteLine(line);
                }

                // Hapus dari daftar penyewa saat ini
                renters.Remove(renter);

                Console.WriteLine("Baju berhasil dikembalikan dan informasi penyewa disimpan di catatan penyewa lama.");
            }
            else
            {
                Console.WriteLine("Penyewa tidak ditemukan.");
            }
        }

        public void ListRenters()
        {
            Console.WriteLine("Daftar Penyewa:");
            foreach (var renter in renters)
            {
                Console.WriteLine(renter);
            }
        }

        public void PrintOldRenterRecords()
        {
            // Pastikan file OldRenters.txt ada
            if (!File.Exists("OldRenters.txt"))
            {
                Console.WriteLine("Tidak ada catatan penyewa lama yang ditemukan.");
                return;
            }

            Console.WriteLine("\n================================\n");
            Console.WriteLine("REKAMAN PEMINJAM LAMA");
            Console.WriteLine("\n================================\n");

            // Membaca semua baris dari OldRenters.txt
            var lines = File.ReadAllLines("OldRenters.txt");

            // Jika tidak ada catatan
            if (lines.Length == 0)
            {
                Console.WriteLine("Tidak ada catatan penyewa lama yang ditemukan.");
                return;
            }

            // Menampilkan setiap catatan penyewa
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length == 3)
                {
                    string nama = parts[0];
                    string bajuDaerah = parts[1];
                    string tanggalKembali = parts[2];

                    // Menampilkan catatan penyewa
                    Console.WriteLine($"Nama Penyewa: {nama}");
                    Console.WriteLine($"Baju Daerah: {bajuDaerah}");
                    Console.WriteLine($"Tanggal Kembali: {tanggalKembali}");
                    Console.WriteLine("\n================================\n");
                }
            }
        }

        public void AvailableClothes()
        {
            Console.WriteLine("Daftar Baju Tersedia:");
            while (bajuHeap.Count > 0)
            {
                Baju baju = bajuHeap.RemoveMin();
                Console.WriteLine(baju);
            }

            // Rebuild the heap after printing the items
            foreach (var baju in bajuDictionary.Values)
            {
                bajuHeap.Add(baju);
            }
        }
    }

}