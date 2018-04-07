using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeGame
{
    class Sasiedzi
    {
        private int[][] sasiedzi;
        private Plansza plansza;

        public Sasiedzi(Plansza plansza)
        {
            sasiedzi = new int[plansza.Dlugosc][];
            for (int i = 0; i < plansza.Dlugosc; i++)
            {
                sasiedzi[i] = new int[plansza.Szerokosc];
            }
            this.plansza = plansza;
        }

        public int ZywiSasiedzi(int x, int y)
        {
            if (czyJestPozaPlansza(x, y))
            {
                return 0;
            }
            else
            {
                return sasiedzi[y][x];
            }
        }

        public void Aktualizuj()
        {
            wyczysc();

            for (int x = 0; x < plansza.Szerokosc; x++)
            {
                for (int y = 0; y < plansza.Dlugosc; y++)
                {
                    if (plansza.CzyZyje(x, y))
                    {
                        ZwiekszSasiadow(x, y);
                    }
                }
            }
        }

        private void ZwiekszSasiadow(int x, int y)
        {
            if (!czyJestPozaPlansza(x + 1, y - 1)) sasiedzi[y - 1][x + 1]++;
            if (!czyJestPozaPlansza(x + 1, y)) sasiedzi[y][x + 1]++;
            if (!czyJestPozaPlansza(x + 1, y + 1)) sasiedzi[y + 1][x + 1]++;
            if (!czyJestPozaPlansza(x, y + 1)) sasiedzi[y + 1][x]++;
            if (!czyJestPozaPlansza(x - 1, y + 1)) sasiedzi[y + 1][x - 1]++;
            if (!czyJestPozaPlansza(x - 1, y)) sasiedzi[y][x - 1]++;
            if (!czyJestPozaPlansza(x - 1, y - 1)) sasiedzi[y - 1][x - 1]++;
            if (!czyJestPozaPlansza(x, y - 1)) sasiedzi[y - 1][x]++;
        }

        private bool czyJestPozaPlansza(int x, int y)
        {
            return x < 0 || x >= plansza.Szerokosc || y < 0 || y >= plansza.Dlugosc;
        }

        private void wyczysc()
        {
            for (int x = 0; x < plansza.Szerokosc; x++)
            {
                for (int y = 0; y < plansza.Dlugosc; y++)
                {
                    sasiedzi[y][x] = 0;
                }
            }
        }
    }
}
