using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toys
{
    class PokojZabawek
    {
        public static List<Zabawki> listaZabawek;
        public event DodanieZabawkiDelegete dodanieZabawkiDelegete;
        public event IloscZabawekDelegete iloscZabawekDelegete;
        public event zwiekszonoWartoscZabawekDelegete zwiekszonoWartosc; 

        public PokojZabawek()
        {
            listaZabawek = new List<Zabawki>();
        }
        public void dodajZabawke(Zabawki zabawka,double wartosc)
        {
            if (ZwrocWartoscAktualna(wartosc) < wartosc)
            {
                listaZabawek.Add(zabawka);
                dodanieZabawkiDelegete("Dodano Zabawke");
                if (listaZabawek.Count > Program.maksymalnaIloscZabawek)
                {
                    iloscZabawekDelegete("Masz juz aż " + listaZabawek.Count + " zabawki");
                }
            }
          

        }
        public int zwrocRozmiarListy()
        {
            return listaZabawek.Count;
        }
        public void wyswietlWiek()
        {
            foreach (Zabawki zabawka in listaZabawek)
            {
                Console.WriteLine(zabawka.Wiek);
            }

        }
        public void usunZabawke(Zabawki zabawka)
        {
            listaZabawek.RemoveAt(listaZabawek.LastIndexOf(zabawka));
        }
        public void usunZabawkeOstatnia()
        {
            listaZabawek.RemoveAt(listaZabawek.Count-1);
        }
        public void wyswietlWartoscAktalna(double wartosc)
        {
            
                Console.WriteLine(ZwrocWartoscAktualna(wartosc));
            

        }
        public double ZwrocWartoscAktualna(double wartosc)
        {
            double result = 0;
            foreach (Zabawki zabawka in listaZabawek)
            {
                result += zabawka.WartoscAktualna();
            }
            if (wartosc < result)
            {
                zwiekszonoWartosc(wartosc, "Przekroczono Wartosc");
            }
                return result;

        }
        public void zmienGlebokosc(int change)
        {
            foreach( Zabawki zabawka in listaZabawek)
            {
                if(zabawka is IDive)
                {
                    IDive depth = zabawka as IDive;
                    depth.Dive(change);
                }
            }
        }
        public void wyswietlGlebokosc()
        {
            foreach (Zabawki zabawka in listaZabawek)
            {
                if (zabawka is IDive)
                {
                    IDive wartosc = zabawka as IDive;
                    Console.WriteLine(wartosc.GetType().Name + " " +wartosc.glebokosc);
                }
            }

        }
        public void zmienWysokosc(int change)
        {
            foreach (Zabawki zabawka in listaZabawek)
            {
                if (zabawka is IRise)
                {
                    IRise wysokosc = zabawka as IRise;
                    wysokosc.Rise(change);
                }
            }
        }
        public void wyswietlWysokosc()
        {
            foreach (Zabawki zabawka in listaZabawek)
            {
                if (zabawka is IRise)
                {
                    IRise wartosc = zabawka as IRise;
                    Console.WriteLine(wartosc.GetType().Name + " " + wartosc.wysokosc);
                }
            }
        }
        public void zmienSzybkosc(int change)
        {
            foreach (Zabawki zabawka in listaZabawek)
            {
                if (zabawka is IAccelerate)
                {
                    IAccelerate szybkosc = zabawka as IAccelerate;
                    szybkosc.Accelerate(change);
                }
            }
        }
        public void wyswietlSzybkosc()
        {
            foreach (Zabawki zabawka in listaZabawek)
            {
                if (zabawka is IAccelerate)
                {
                    IAccelerate wartosc = zabawka as IAccelerate;
                    Console.WriteLine(wartosc.GetType().Name + " " + wartosc.przyspieszenie);
                }
            }
        }
    }
}
