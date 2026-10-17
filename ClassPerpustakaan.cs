using System;
using System.Collections.Generic;
using System.Text;

namespace TugasPerpustakaan
{
    class Item
    {
        public string Judul { get; set; }
        public int Tahun { get; set; }

        public Item(string judul, int tahun)
        {
            Judul = judul;
            Tahun = tahun;
        }

        public virtual void Deskripsi()
        {
            Console.WriteLine($"Judul: {Judul}, Tahun: {Tahun}");
        }

        public void InfoItem()
        {
            Deskripsi();
        }
    }

    class Buku : Item
    {
        public string Penulis { get; set; }

        public Buku(string judul, int tahun, string penulis) : base(judul, tahun)
        {
            Penulis = penulis;
        }

        public void CekPenulis()
        {
            Console.WriteLine($"Penulis: {Penulis}");
        }

        public override void Deskripsi()
        {
            Console.WriteLine($"(Buku) Judul: {Judul}, Tahun: {Tahun}, Penulis: {Penulis}");
        }
    }

    class Majalah : Item
    {
        public int Edisi { get; set; }

        public Majalah(string judul, int tahun, int edisi) : base(judul, tahun)
        {
            Edisi = edisi;
        }

        public void InfoEdisi()
        {
            Console.WriteLine($"Edisi ke-{Edisi}");
        }

        public override void Deskripsi()
        {
            Console.WriteLine($"(Majalah) Judul: {Judul}, Tahun: {Tahun}, Edisi: {Edisi}");
        }
    }

    class Novel : Buku
    {
        public Novel(string judul, int tahun, string penulis) : base(judul, tahun, penulis)
        {
        }

        public void BacaSinopsis()
        {
            Console.WriteLine($"Membaca sinopsis dari novel ({Judul})");
        }

        public override void Deskripsi()
        {
            Console.WriteLine($"(Novel) Judul: {Judul}, Tahun: {Tahun}, Penulis: {Penulis}");
        }
    }

    class Komik : Buku
    {
        public Komik(string judul, int tahun, string penulis) : base(judul, tahun, penulis)
        {
        }

        public void TampilkanIlustrasi()
        {
            Console.WriteLine($"Menampilkan ilustrasi komik ({Judul})");
        }

        public override void Deskripsi()
        {
            Console.WriteLine($"(Komik) Judul: {Judul}, Tahun: {Tahun}, Penulis: {Penulis}");
        }
    }

    class MajalahAnak : Majalah
    {
        public MajalahAnak(string judul, int tahun, int edisi) : base(judul, tahun, edisi)
        {
        }

        public void KategoriAnak()
        {
            Console.WriteLine($"Kategori: Anak-Anak");
        }

        public override void Deskripsi()
        {
            Console.WriteLine($"(Majalah Anak) Judul: {Judul}, Tahun: {Tahun}, Edisi: {Edisi}");
        }
    }

    class MajalahTeknologi : Majalah
    {
        public MajalahTeknologi(string judul, int tahun, int edisi) : base(judul, tahun, edisi)
        {
        }

        public void TopikTeknologi()
        {
            Console.WriteLine($"Topik: Teknologi");
        }

        public override void Deskripsi()
        {
            Console.WriteLine($"(Majalah Teknologi) Judul: {Judul}, Tahun: {Tahun}, Edisi: {Edisi}");
        }
    }

    class Perpustakaan
    {
        private List<Item> daftarItem = new List<Item>();

        public void TambahItem(Item item)
        {
            daftarItem.Add(item);
            Console.WriteLine($"Berhasil menambahkan ({item.Judul}) ke perpustakaan.");
        }

        public void DaftarItem()
        {
            Console.WriteLine("\nDaftar Koleksi Perpustakaan:");
            foreach (var item in daftarItem)
            {
                item.InfoItem();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Perpustakaan perpustakaan = new Perpustakaan();

            Novel novel1 = new Novel("Seporsi Mie Ayam Sebelum Mati", 2025, "Brian Khrisna");
            Komik komik1 = new Komik("Bleach Vol 1", 2002, "Tite Kubo");
            MajalahAnak majalahAnak1 = new MajalahAnak("Bobo", 2026, 22);
            MajalahTeknologi majalahTekno1 = new MajalahTeknologi("Linux Magazine", 2026, 311);

            Console.WriteLine("Menambahkan Item ke Perpustakaan:");
            perpustakaan.TambahItem(novel1);
            perpustakaan.TambahItem(komik1);
            perpustakaan.TambahItem(majalahAnak1);
            perpustakaan.TambahItem(majalahTekno1);

            perpustakaan.DaftarItem();

            Console.WriteLine("\n Tampilkan Data Item:");
            
            novel1.CekPenulis();
            novel1.BacaSinopsis();

            Console.WriteLine();
            komik1.CekPenulis();
            komik1.TampilkanIlustrasi();

            Console.WriteLine();
            majalahAnak1.InfoEdisi();
            majalahAnak1.KategoriAnak();

            Console.WriteLine();
            majalahTekno1.InfoEdisi();
            majalahTekno1.TopikTeknologi();

            Console.WriteLine("\nDeskripsi objek novel dan majalah");

            Console.WriteLine();
            novel1.Deskripsi();
            komik1.Deskripsi();
            majalahAnak1.Deskripsi();
            majalahTekno1.Deskripsi();

            Console.WriteLine("\nDeskripsi item komik");

            Console.WriteLine();
            Item itemKomik = new Komik("Dragon Ball", 1984, "Akira Toriyama");
            itemKomik.Deskripsi();

        }
    }
}