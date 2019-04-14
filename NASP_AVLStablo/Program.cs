using System;

namespace NASP_AVLStablo
{
    class Program
    {
        static void Main(string[] args)
        {

            AVLTree tree = new AVLTree();

            if (args.Length < 1)
            {
                Console.WriteLine("Potrebno upisati datoteku s vrijednostima čvorova!");
                Environment.Exit(0);
            }

            try
            {
                string file = System.IO.File.ReadAllText(args[0]).Trim();
                if (String.IsNullOrWhiteSpace(file) == false)
                {
                    foreach (string number in file.Split(','))
                    {
                        tree.Add(Int32.Parse(number));
                    }
                }
            }
            catch
            {
                Console.WriteLine("Pogreška kod učitavanja vrijednosti čvorova!");
                Environment.Exit(0);
            }

            tree.Root.Print();
            Console.WriteLine("Za dodati čvor na stablo upisati riječ \"insert\" te, nakon razmaka, navesti vrijednost čvora.");

            while (true)
            {               
                string insert = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(insert) == false)
                {
                    string[] line = insert.Split(' ');

                    if (line[0] == "insert")
                    {
                        try
                        {
                            tree.Add(Int32.Parse(line[1]));
                        }
                        catch
                        {
                            Console.WriteLine("Pogreška kod parsiranja vrijednosti čvora!");
                            continue;
                        }

                    }
                    else
                    {
                        Console.WriteLine("Naredba ne postoji!");
                        continue;
                    }
                }
                tree.Root.Print();
            }

            //AVLTree tree = new AVLTree();
            //tree.Add(1);
            //tree.Add(2);
            //tree.Add(3);
            //tree.Add(6);
            //tree.Add(15);
            //tree.Add(-2);
            //tree.Add(-5);
            //tree.Add(-8);
            //tree.Root.Print();

            //AVLTree tree = new AVLTree();
            //tree.Add(6);
            //tree.Add(2);
            //tree.Add(3);
            //tree.Add(11);
            //tree.Add(30);
            //tree.Root.Print();
            //tree.Add(9);
            //tree.Root.Print();
            //tree.Add(13);
            //tree.Add(18);

            // ReSharper disable once FunctionNeverReturns
        }
    }
}
