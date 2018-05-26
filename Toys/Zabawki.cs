using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toys
{
    class Zabawki
    {
        Wartosc wartoscBazowa;
        double wiek;
        public delegate void zmianaCeny(object sender, EventArgs e);
        public event ZwiekszenieWartosciDelegete zwiekszenieWartosciDelegete;
        public double Wiek
        {
            get
            {
                return wiek;
            }

            set
            {
                if (value > 0)
                {
                    wiek = value;
                }
                else
                {
                    throw new System.ArgumentException("Wartość ujemna!");
                }
            }
        }

        public void zmienBazowaWartosc(double cena, double wartoscSentymentalna, double wiek)
        {
            if (wartoscBazowa.Cena != cena || wartoscBazowa.WartoscSentymentalna != wartoscSentymentalna || this.wiek != wiek )

            {
                zwiekszenieWartosciDelegete(wartoscBazowa.Cena, cena);
                wartoscBazowa.Cena = cena;
                wartoscBazowa.WartoscSentymentalna = wartoscSentymentalna;

                this.wiek = wiek;
            }
        }
        private Wartosc WartoscBazowa { get => wartoscBazowa; set => wartoscBazowa = value; }
        public double WartoscAktualna()
        {
            double wartoscAktualna = 0;
            wartoscAktualna = WartoscBazowa.Cena + (WartoscBazowa.WartoscSentymentalna * wiek);

            return wartoscAktualna;

        }
        public struct Wartosc
        {
            private double cena;
            private double wartoscSentymentalna;

            public Wartosc(double cena, double wartoscSentymentalna)
            {
                if (cena > 0 || wartoscSentymentalna > 0)
                {
                    this.cena = cena;
                    this.wartoscSentymentalna = wartoscSentymentalna;
                }
                else
                {
                    throw new System.ArgumentException("Wartosc Ujemna!");
                }
            }

            
            public double Cena
            {
                set
                {
                    if (value > 0)
                    {
                        cena = value;
                    }
                    else
                    {
                        throw new System.ArgumentException("Wartosc Ujemna!");
                    }
                }

                get
                {
                    return cena;
                }
            }
            public double WartoscSentymentalna
            {
                set
                {
                    if (value > 0)
                    {
                        wartoscSentymentalna = value;
                    }
                    else
                    {
                        throw new System.ArgumentException("wartosc nie moze byc ujemna", "wartosc ujemna");
                    }
                }

                get
                {
                    return wartoscSentymentalna;
                }
            }


        }
    }
}
