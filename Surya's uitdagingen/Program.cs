using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Surya_s_uitdagingen
{
    class Program
    {
        static void Main(string[] args)
        {
            Con1 ps5 = new Con1();
            //Con1.Pythagoras();
            //Con1.driehoek();
            //Con1.kopieer();
            //Con1.druiven();
        }
    }    

    class Con1
    {
        //1. Pythagoras method
        public static double Pythagoras()
        {
            string x = Console.ReadLine();
            string y = Console.ReadLine();
            int een = int.Parse(x);
            int twee = int.Parse(y);
            double drie = formule(een, twee);
            Console.WriteLine(drie);
            Console.ReadKey();
            return drie;
        }
        static double formule(int een, int twee)
        {
            double a = een;
            double b = twee;
            double c = Math.Sqrt(a * a + b * b);
            return c;
        }

        //2. driehoek in console
        public static string driehoek()
        {
            string aantal = Console.ReadLine();
            int x = int.Parse(aantal);
            string drie = triangle(x);
            Console.ReadKey();
            return drie;
        }
        static string triangle(int x)
        {
            int teller;
            string driehoek = "";
            for (teller = 0; teller < x; teller++)
            {
                driehoek = driehoek + "+";
                Console.WriteLine(driehoek);
            }
            return driehoek;
        }

        //3a. kopieer
        public static string kopieer()
        {
            string a = Console.ReadLine();
            string b = Console.ReadLine();
            int c = int.Parse(b);
            string tekst = kopieermachine(a, c);
            Console.WriteLine(tekst);
            Console.ReadKey();
            return tekst;
        }
        static string kopieermachine(string copy, int paste)
        {
            int teller;
            string text = "";
            string spatie = "";
            for (teller = 0; teller < paste; teller++)
            {
                text = text + spatie + copy;
                spatie = " ";
            }
            return text;
        }

        //3b. druiventros van nullen in console
        public static string druiven()
        {
            Console.WriteLine("Hoeveel lagen wil je hebben?");
            string aantal_lagen = Console.ReadLine();
            int x = int.Parse(aantal_lagen);
            int druiventeller = x;
            string druiven = "";

            for (int teller = 0; teller < x; teller++)
            {
                druiven = druivenmaker("0", druiventeller);
                druiven = puntenmaker(druiven, teller);
                Console.WriteLine(druiven);
                druiventeller--;
            }
            Console.ReadKey();
            return druiven;
        }
        static string druivenmaker(string copy, int paste)
        {
            int teller;
            string text = "";
            string streepje = "";
            for (teller = 0; teller < paste; teller++)
            {
                text = text + streepje + copy;
                streepje = "-";
            }
            return text;
        }
        static string puntenmaker(string copy, int paste)
        {
            int teller;
            for (teller = 0; teller < paste; teller++)
            {
                string punt = ".";
                copy = punt + copy + punt;
            }
            return copy;
        }
    }

    class Win1 : Forms
    {

    }
}
