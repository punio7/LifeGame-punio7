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
            plansza.Zaludnij(500);

            while (true)
            {
                Rysuj(plansza);
                System.Threading.Thread.Sleep(100);
                Plansza nowaPlansza = Aktualizuj(plansza);
                plansza = nowaPlansza;
            }
        }
        private static Plansza Aktualizuj(Plansza staraPlansza)
        {
            Plansza nowaPlansza = new Plansza(staraPlansza.Szerokosc, staraPlansza.Dlugosc);

            for (int x = 0; x < staraPlansza.Szerokosc; x++)
            {
                for (int y = 0; y < staraPlansza.Dlugosc; y++)
                {
                    int liczbaSasiadow = staraPlansza.ZywiSasiedzi(x, y);
                    if (!staraPlansza.CzyZyje(x, y))
                    {
                        if (liczbaSasiadow == 3)
                        {
                            nowaPlansza.Ozyj(x, y);
                        }
                    }
                    else
                    {
                        if (liczbaSasiadow == 2 || liczbaSasiadow == 3)
                        {
                            nowaPlansza.Ozyj(x, y);
                        }
                        else
                        {
                            nowaPlansza.Usmierc(x, y);
                        }
                    }
                }
            }

            return nowaPlansza;
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
