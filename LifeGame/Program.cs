using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Plansza plansza = new Plansza(80, 24);
            Sasiedzi sasiedzi = new Sasiedzi(plansza);
            plansza.Zaludnij(500);

            while (true)
            {
                Rysuj(plansza);
                System.Threading.Thread.Sleep(100);
                Aktualizuj(plansza, sasiedzi);
            }
        }
        private static Plansza Aktualizuj(Plansza plansza, Sasiedzi sasiedzi)
        {
            sasiedzi.Aktualizuj();

            for (int x = 0; x < plansza.Szerokosc; x++)
            {
                for (int y = 0; y < plansza.Dlugosc; y++)
                {
                    int liczbaSasiadow = sasiedzi.ZywiSasiedzi(x, y);
                    if (!plansza.CzyZyje(x, y))
                    {
                        if (liczbaSasiadow == 3)
                        {
                            plansza.Ozyj(x, y);
                        }
                    }
                    else
                    {
                        if (liczbaSasiadow == 2 || liczbaSasiadow == 3)
                        {
                            plansza.Ozyj(x, y);
                        }
                        else
                        {
                            plansza.Usmierc(x, y);
                        }
                    }
                }
            }

            return plansza;
        }

        private static void Rysuj(Plansza plansza)
        {
            Console.Clear();
            for (int y = 0; y < plansza.Dlugosc; y++)
            {
                for (int x = 0; x < plansza.Szerokosc; x++)
                {
                    Console.Write(plansza.Pobierz(x, y));
                }
            }
        }
    }
}
