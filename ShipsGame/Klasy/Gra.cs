using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShipsGame.Klasy
{
    public static class Gra
    {
        public static Gracz Uzytkownik;
        public static Gracz Komputer;

        public static int[] RozmiaryStatkow = new int[4] { 1, 2, 3, 4 };

        public static bool CzyMoznaPostawicStatek(int indexAktualnegoStatku, int komorkaX, int komorkaY, bool jestHoryzontalnie, int[,] komorki)
        {
            if (jestHoryzontalnie)
            {
                if (komorkaX + RozmiaryStatkow[indexAktualnegoStatku] - 1 <= Gracz.OSTATNI_INDEX_PLANSZY)
                {
                    for (int i = Math.Max(0, komorkaX - 1); i <= Math.Min(Gracz.OSTATNI_INDEX_PLANSZY, komorkaX + RozmiaryStatkow[indexAktualnegoStatku]); i++)
                    {
                        for (int j = Math.Max(0, komorkaY - 1); j <= Math.Min(Gracz.OSTATNI_INDEX_PLANSZY, komorkaY + 1); j++)
                        {
                            if (komorki[i, j] != -1)
                            {
                                return false;
                            }
                        }
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (komorkaY + RozmiaryStatkow[indexAktualnegoStatku] - 1 <= Gracz.OSTATNI_INDEX_PLANSZY)
                {
                    for (int i = Math.Max(0, komorkaX - 1); i <= Math.Min(Gracz.OSTATNI_INDEX_PLANSZY, komorkaX + 1); i++)
                    {
                        for (int j = Math.Max(0, komorkaY - 1); j <= Math.Min(Gracz.OSTATNI_INDEX_PLANSZY, komorkaY + RozmiaryStatkow[indexAktualnegoStatku]); j++)
                        {
                            if (komorki[i, j] != -1)
                            {
                                return false;
                            }
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static void RozmiescStatek(int indexAktualnegoStatku, int komorkaX, int komorkaY, bool jestHoryzontalnie, int[,] komorki)
        {
            if (jestHoryzontalnie)
            {
                for (int i = 0; i < RozmiaryStatkow[indexAktualnegoStatku]; i++)
                {
                    komorki[komorkaX + i, komorkaY] = indexAktualnegoStatku;
                }
            }
            else
            {
                for (int i = 0; i < RozmiaryStatkow[indexAktualnegoStatku]; i++)
                {
                    komorki[komorkaX, komorkaY + i] = indexAktualnegoStatku;
                }
            }
        }

        public static void RozmieszczenieStatkowKomputera()
        {
            Random random = new Random();
            int indexAktualnegoStatku = 0;
            // wywołujemy pętlę dla wszystkich statków
            while (indexAktualnegoStatku < RozmiaryStatkow.Length)
            {
                int x = random.Next(Gracz.ROZMIAR_PLANSZY);
                int y = random.Next(Gracz.ROZMIAR_PLANSZY);

                // sprawdzamy czy komputer
                // może postawic statek w wylosowanych współrzędnych
                // dla uproszczenia ustalamy, że komputer
                // może umieszczać statki tylko poziomo
                // (parametr dotyczący obrotu ma wartość true)
                if (CzyMoznaPostawicStatek(indexAktualnegoStatku, x, y, true, Komputer.Plansza))
                {
                    RozmiescStatek(indexAktualnegoStatku, x, y, true, Gra.Komputer.Plansza);
                    indexAktualnegoStatku++;
                }
            }
        }

        public static bool WykonajAtak(int komorkaX, int komorkaY, Gracz atakujacy, Gracz atakowany)
        {
            // wskazane pole zostaje ustawione na odkryte
            atakowany.OdkrytePola[komorkaX, komorkaY] = true;

            // sprawdzenie, czy komórka jest komórką statku przeciwnika (nie była pusta)
            // czyli gracz trafił w komórkę statku
            if (atakowany.Plansza[komorkaX, komorkaY] != -1)
            {
                // zmniejszenie wartości tablicy dla trafionego statku przeciwnika
                atakowany.Flota[atakowany.Plansza[komorkaX, komorkaY]]--;

                // jeśli trafiono wszystkie komórki danego statku przeciwnika
                // czyli wartość jest równa 0
                if (atakowany.Flota[atakowany.Plansza[komorkaX, komorkaY]] == 0)
                {
                    // zmniejszamy liczbę statków do trafienia
                    atakujacy.LiczbaStatkowDoZatopienia--;
                }

                return true;
            }
            // jeśli atakujący nie trafił w statek (czyli pudło)
            else
            {
                return false;
            }
        }

        public static int[] StrzalKomputera(Gracz gracz)
        {

            // utworzenie obiektu losującego
            Random random = new Random();

            // losowanie współrzędnych
            int x = random.Next(Gracz.ROZMIAR_PLANSZY);
            int y = random.Next(Gracz.ROZMIAR_PLANSZY);

            // dopóki nie wylosowano współrzędnych nieodkrytej komórki
            // to losuj dalej współrzędne
            while (gracz.OdkrytePola[x, y] == true)
            {
                x = random.Next(Gracz.ROZMIAR_PLANSZY);
                y = random.Next(Gracz.ROZMIAR_PLANSZY);
            }

            // przypisanie współrzędnych do pomocniczej tablicy
            // i jej zwrócenie przez metodę
            int[] strzal = { x, y };
            return strzal;
        }
    }
}