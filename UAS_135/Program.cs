using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_135
{
    /// <summary>
    /// Node class
    /// </summary>
    /// <remarks> class node berisi variabel nama barang, jenis barang, harga barang, id barang, node next, dan node previous  </remarks>
    class Node
    {
        public string namaBrg, jenisBrg, hargaBrg;
        public int idBrg;
        public Node next;
        public Node prev;

    }
    /// <summary>
    /// main class
    /// </summary>
    /// <remarks> class program dapat melakukan operasi pencarian, penambahan data, penghapusan data, dan pengurutan data </remarks>
    class Program
    {
        /// <summary>
        /// class program
        /// </summary>
        /// <remarks> Mendeklarasikan node sebagai null </remarks>
        Node START;
        public Program()
        {
            START = null;
        }
        /// <summary>
        /// Operasi Pencarian
        /// </summary>
        /// <param name="jnsBrg"> Jenis Barang yang akan dicari </param>
        /// <param name="previous"> Node sebelum node current </param>
        /// <param name="current"> Node yang sedang ditempati </param>
        /// <returns> hasil dari pencarian jenis barang</returns>
        public bool Search(string jnsBrg, ref Node previous, ref Node current)
        {
            for (previous = current = START; current != null &&
                jnsBrg != current.jenisBrg; previous = current,
                current = current.next)
            { }
            return (current != null);
        }
        /// <summary>
        /// Operasi jika List masih kosong
        /// </summary>
        /// <returns> jika data kosong akan mengembalikan perintah bahwa data kosong, jika ada akan melanutkan operasi </returns>
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Operasi pengurutan data
        /// </summary>
        /// <remarks> Jika data masih kosong akan menampilakan tulisan "Data kosong!", jika data tersedia maka data akan ditampilkan secara berurutan </remarks>
        public void traverse()
        {
            if (listEmpty())
                Console.WriteLine("\nData kosong!");
            else
            {
                Console.WriteLine("\nData yang tersedia adalah:\n");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.idBrg + " " + currentNode.namaBrg + " " + currentNode.jenisBrg + " " + currentNode.hargaBrg + "\n");
            }          
        }
        /// <summary>
        /// Operasi pengurutan data dari terbawah
        /// </summary>
        /// <remarks> Jika data masih kosong akan menampilakan tulisan "Data kosong!", jika data tersedia maka data akan ditampilkan secara berurutan dari urutan terbawah</remarks>
        public void revtraverse()
        {
            if (listEmpty())
                Console.WriteLine("\nData kosong");
            else
            {
                Console.WriteLine("\nData dari urutan terbawah " + "adalah:\n");
                Node currentNode;
                for (currentNode = START; currentNode.next != null; currentNode = currentNode.next)
                { }
                while (currentNode != null)
                {
                    Console.Write(currentNode.idBrg + " " + currentNode.namaBrg + " " + currentNode.jenisBrg + " " + currentNode.hargaBrg + "\n");
                    currentNode = currentNode.prev;
                }
            }
        }
        /// <summary>
        /// Operasi penambahan data
        /// </summary>
        /// <remarks> Pertama akan ada perintah untuk mengisi id barang. nama barang, jenis barang, dan harga barang. 
        /// Jika data yang dimasukkan ternyata duplikat maka program akan menampilkan "Data duplikat tidak diperbolehkan" </remarks>
        public void addNode()
        {
            Console.Write("\nMasukkan id barang: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nMasukkan nama barang: ");
            string name = Console.ReadLine();
            Console.Write("\nMasukkan jenis barang: ");
            string jenis = Console.ReadLine();
            Console.Write("\nMasukkan harga barang: ");
            string hrg = Console.ReadLine();

            Node newnode = new Node();
            newnode.idBrg = id;
            newnode.namaBrg = name;
            newnode.hargaBrg = hrg;
            newnode.jenisBrg = jenis;


            if (START == null || id == START.idBrg)
            {
                if ((START != null) && (id == START.idBrg))
                {
                    Console.WriteLine("\nData duplikat tidak diperbolehkan");
                    return;
                }
                newnode.next = START;
                if (START != null)
                    START.prev = newnode;
                newnode.prev = null;
                START = newnode;
                return;
            }
            Node previous, current;
            for (current = previous = START; current != null &&
                id != current.idBrg; previous = current, current =
                current.next)
            {
                if (id == current.idBrg)
                {
                    Console.WriteLine("\nData duplikat tidak diperbolehkan");
                    return;
                }
            }
            
            newnode.next = current;
            newnode.prev = previous;

            if (current == null)
            {
                newnode.next = null;
                previous.next = newnode;
                return;
            }
            current.prev = newnode;
            previous.next = newnode;
        }
        /// <summary>
        /// Operasi penghapusan data
        /// </summary>
        /// <param name="jnsBrg"> Jenis barang yang akan dihapus </param>
        /// <returns> Data jenis barang yang diisi akan terhapus </returns>
        public bool delNode(string jnsBrg)
        {
            Node previous, current;
            previous = current = null;
            if (Search(jnsBrg, ref previous, ref current) == false)
                return false;
            if (current == START)
            {
                START = START.next;
                if (START != null)
                    START.prev = null;
                return true;

            }
            if (current.next == null)
            {
                previous.next = null;
                return true;
            }
            previous.next = current.next;
            current.next.prev = previous;
            return true;
        }
        /// <summary>
        /// Tampilan Utama Program
        /// </summary>
        /// <param name="args"> Untuk meneruskan argumen</param>
        /// <remarks> Akan ada tampilan untuk menampilkan semua data, mencari sebuah data, Menampilkan data dari urutan terbawah, Menambah data, 
        /// Menghapus data, dan keluar dari program dimana perintah-perintah tersebut memiliki korespondensi dengan angka tertentu.
        /// Jika memilih salah satu perintah maka akan menjalankan operasi dari perintah yang dipilih. 
        /// Jika memilih anngka diluar perintah yang ada maka program akan menampilkan eror</remarks>
        static void Main(string[] args)
        {
 
            Program p = new Program();
            while (true)
            {
                try
                {
                    Console.WriteLine("\n Menu" +
                        "\n 1. Menampilkan semua data" +
                        "\n 2. Mencari sebuah data" +
                        "\n 3. Menampilkan data dari urutan terbawah" +
                        "\n 4. Menambah data" +
                        "\n 5. Menghapus data" +
                        "\n 6. Keluar" +

                        "\n Masukkan pilihan anda (1 - 6): "
                        );
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                p.traverse();
                            }
                            break;
                        case '2':
                            {
                                if (p.listEmpty())
                                {
                                    Console.WriteLine("\nData kosong!");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.Write("Masukkan jenis barang dari barang yang datanya ingin dicari: ");
                                string jnsBrg = Console.ReadLine();
                                if (p.Search(jnsBrg, ref prev, ref curr) == false)
                                    Console.WriteLine("\nData tidak ditemukan");
                                else
                                {
                                    Console.WriteLine("\nData ditemukan!");
                                    Console.WriteLine("\nID Barang " + curr.idBrg);
                                    Console.WriteLine("\nNama Barang " + curr.namaBrg);
                                    Console.WriteLine("\nJenis Barang " + curr.jenisBrg);
                                    Console.WriteLine("\nHarga Barang " + curr.hargaBrg);

                                }
                            }
                            break ;
                        case '3':
                            {
                                p.revtraverse();
                            }
                            break;
                        case '4':
                            {
                                
                                p.addNode();
                            }
                            break;
                        case '5':
                            {
                                if (p.listEmpty())
                                {
                                    Console.WriteLine("\nData kosong!");
                                    break;
                                }
                                Console.Write("Masukkan jenis barang dari barang" + " yang datanya ingin dihapus: ");
                                string jnsBrg = Console.ReadLine();
                                Console.WriteLine();
                                if (p.delNode(jnsBrg) == false)
                                    Console.WriteLine("Data tidak ditemukan!");
                                else
                                    Console.WriteLine("Data dengan jenis barang " + jnsBrg + " telah terhapus \n");
                            }
                            break;
                        case '6':
                            return;
                        default:
                            {
                                Console.WriteLine("\nPilihan salah!");
                            }
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}

/* 

2. Algoritma yang digunakan adalah algoritma double linked list
karena didalam studi kasus tertera bahwa data-data yang dikumpulkan
masih belum terurut,double linked list bisa memasukkan node di awal list,
diantara dua node dan diakhir list, maka data-data yang telah dimasukkan 
akan diurutkan.

3. rear dan front.

4. a. struktur tersebut memiliki kedalaman 5
   b. Inorder : 15 20 25 30 31 32 35 48 50 65 66 67 69 70 90 94 98 99 

*/



