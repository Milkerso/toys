using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Toys
{
    class Program
    {
        public static PokojZabawek pokojZabawek = new PokojZabawek();

        public const double maksymalnaIloscZabawek = 1;
        static void Main(string[] args)
        {
            pokojZabawek.dodanieZabawkiDelegete += new DodanieZabawkiDelegete(dodanieZabaweczki);
            pokojZabawek.iloscZabawekDelegete += new IloscZabawekDelegete(iloscZabawek);
            pokojZabawek.zwiekszonoWartosc += new zwiekszonoWartoscZabawekDelegete(zwWartosc);
            

            Car car =new Car();
            Computer computer = new Computer();
            Plane plane = new Plane();
            double wartosc = 15;
            Submarine submarine = new Submarine();
            Submarine submarinee = new Submarine();
            pokojZabawek.dodajZabawke(car,wartosc);
            pokojZabawek.dodajZabawke(submarine,wartosc);
            pokojZabawek.dodajZabawke(submarinee,wartosc);
            Console.WriteLine("Przed zmiana");
            pokojZabawek.wyswietlSzybkosc();
            Console.WriteLine("Po zmianie");
            pokojZabawek.zmienSzybkosc(80);
            pokojZabawek.wyswietlSzybkosc();
            Console.WriteLine(pokojZabawek.ZwrocWartoscAktualna(wartosc));
         
            foreach(Zabawki zabawka in PokojZabawek.listaZabawek)
            {
                zabawka.zwiekszenieWartosciDelegete += new ZwiekszenieWartosciDelegete(zwiekszenieWartosci);
                zabawka.zmienBazowaWartosc(2, 3, 4);
            }
            pokojZabawek.dodajZabawke(car, wartosc);
            //pokojZabawek.wyswietlWiek();
          //  pokojZabawek.usunZabawke(submarine);
          //  pokojZabawek.wyswietlWartoscAktalna(wartosc);
            Thread watek = new Thread(dodajZabawke);
            watek.Start();
            Thread watek2 = new Thread(usunZabawke);
            watek2.Start();
            Thread watek3 = new Thread(zmienParametry);
            watek3.Start();


            Console.ReadLine();
        }

        private static void zwWartosc(double a, string c)
        {
            Console.WriteLine(c+" "+a);
        }

        static void dodajZabawke()
        {
            //  Thread.Sleep(20);
            while (true)
            {
                Monitor.Enter(pokojZabawek);
                try
                {
                    Submarine submarine = new Submarine();
                    pokojZabawek.dodajZabawke(submarine,50);
                    Car car = new Car();
                    pokojZabawek.dodajZabawke(car,50);
                    
                }
                // catch blocks go here.
                finally
                {
                    Monitor.Exit(pokojZabawek);
                    Thread.Sleep(1500);
                }
            }
        }
        static void usunZabawke()
        {
            while (true)
            {
                Monitor.Enter(pokojZabawek);
                try
                {
                    if (pokojZabawek.zwrocRozmiarListy() > 0)
                    {
                        pokojZabawek.usunZabawkeOstatnia();
                    }
                }
                // catch blocks go here.
                finally
                {
                    Monitor.Exit(pokojZabawek);
                    Thread.Sleep(1000);
                }
            }
        }
        static void zmienParametry()
        {
            //Thread.Sleep(40);
            int i = 0;
            while (true)
            {

                Monitor.Enter(pokojZabawek);
                try
                {
                    if (pokojZabawek.zwrocRozmiarListy() > 0)
                    {
                        i++;
                        pokojZabawek.zmienGlebokosc(i);
                        pokojZabawek.zmienWysokosc(i + 10);
                        pokojZabawek.zmienSzybkosc(i + 30);

                        Console.WriteLine("zmieniono zabawki");
                        pokojZabawek.wyswietlSzybkosc();
                    }
                }
                // catch blocks go here.
                finally
                {
                    Monitor.Exit(pokojZabawek);
                    Thread.Sleep(1000);
                }
            }
        }
        private static void iloscZabawek(string a)
        {
            Console.WriteLine(a);
        }

        private static void zwiekszenieWartosci(double wartoscStara, double wartoscNowa)
        {
            Console.WriteLine("Stara Wartosc "+wartoscStara+" Nowa Wartosc: "+wartoscNowa);
        }

        private static void dodanieZabaweczki(string a)
        {
            Console.WriteLine(a);
        }
    }
}
