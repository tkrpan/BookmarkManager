using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TKrpan.BookmarkManager.Infrastructure;

namespace TKrpan.BookmarkManager
{
    class Program
    {
        static void Main(string[] args)
        {


            var bookmarkManager = new Infrastructure.BookmarkManager();
            int choice;

            do{
                Console.Clear();
            Console.WriteLine("Dobrodošli u BookmarkManager");
            Console.WriteLine("1) Dodaj bookmark");
            Console.WriteLine("2) Ukloni bookmark");
            Console.WriteLine("3) Prikaži sve bookmarke");
            Console.WriteLine("4) Otvori bookmark");
            Console.WriteLine("0) Završi");

            choice = int.Parse(Console.ReadLine());
            Console.WriteLine();

            if (choice == 1)
            {
                Console.Write("Naziv: ");
                var name = Console.ReadLine();

                Console.Write("Url: ");
                var url = Console.ReadLine();

                bookmarkManager.Add(name, url);
            }

            if (choice == 2)
            {
                Console.WriteLine("Index bookmarka ");
                var index = int.Parse(Console.ReadLine());

                bookmarkManager.Remove(index);
            }

            if (choice == 3)
            {
                bookmarkManager.Show();
                Console.WriteLine("Pritisnite neku tipku za nastavak...");
                Console.ReadKey();
            }

            if (choice == 4)
            {
                Console.WriteLine("Index bookmarka koji želite otvoriti");
                var index = int.Parse(Console.ReadLine());

                bookmarkManager.Run(index);
            }

            } while (choice != 0);
        }
    }
}
