using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OrvosiNobeldijasok
{
    
    class Elethossz
    {
        private int Tol { get; set; }
        private int Ig { get; set; }
        public int ElethosszEvekben => Tol == -1 || Ig == -1 ? -1 : Ig - Tol;

        public bool IsmertAzElethossz => ElethosszEvekben != -1;

        public Elethossz(string SzuletesHalalozas)
        {
            string[] m = SzuletesHalalozas.Split('-');
            try
            {
                Tol = int.Parse(m[0]);
            }
            catch (Exception)
            {
                Tol = -1;
            }
            try
            {
                Ig = int.Parse(m[1]);
            }
            catch (Exception)
            {
                Ig = -1;
            }
        }
    }
    class Nobel
    {
        public string nev, kod, elhal;
        public int ev, eh;
        public Nobel(string sor)
        {
            var s = sor.Split(';');
            ev = int.Parse(s[0]);
            nev = s[1];
            kod = s[3];
            elhal = s[2];
            eh = new Elethossz(s[2]).ElethosszEvekben;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var lista = new List<Nobel>();
            var sr = new StreamReader("orvosi_nobeldijak.txt");
            var elso = sr.ReadLine();
            while (!sr.EndOfStream)
            {
                lista.Add(new Nobel(sr.ReadLine()));
            }
            Console.WriteLine($"3. feladat: Díjazottak száma: {lista.Count()} fő");
            var lastev = (from sor in lista orderby sor.ev select sor.ev).Last();

            Console.WriteLine($"4. feladat:Utolsó év: {lastev}");

            Console.WriteLine();
            Console.Write($"5. Feladat: Kérem adja meg egy ország kódját: ");
            string kod = Console.ReadLine().ToUpper();
            var kodok = (from sor in lista where sor.kod == kod select sor);
            if (kodok.Any())
            {
                if (kodok.Count()>1)
                {
                    Console.WriteLine($"A megadott országból {kodok.Count()} fő díjazott volt!");
                }
                else
                {
                    Console.WriteLine("\tA megadott ország díjazottja:");
                    Console.WriteLine($"\tNév {kodok.First().nev}");
                    Console.WriteLine($"\tÉv {kodok.First().ev}");
                    Console.WriteLine($"\tSz/H {kodok.First().elhal}");
                }
            }
            else
            {
                Console.WriteLine("A megadott országból nem vólt díjazott!");
            }

            Console.WriteLine("6. Statisztika");
            var stat = (from sor in lista group sor by sor.kod);
            foreach (var item in stat)
            {
                if (item.Count()>5)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Count()} fő");                    
                }                
            }
            /*   var atlag = new List<int>();
              for (int i = 0; i <lista.Count(); i++)
               {
                   if (lista[i].eh != -1)
                   {
                       atlag.Add(lista[i].eh);
                   }
               }*/
            var atlag = (from sor in lista where sor.eh!=-1 select sor.eh).Average();
           
            Console.WriteLine($"7. Feladat: A keresett átlag {Math.Round(atlag, 1)} év");
            Console.ReadKey();
        }
    }
}
