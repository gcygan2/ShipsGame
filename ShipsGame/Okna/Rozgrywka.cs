using ShipsGame.Klasy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShipsGame.Okna
{
    public partial class Rozgrywka : Form
    {
        int myszX;
        int myszY;

        public Rozgrywka()
        {
            InitializeComponent();
        }

        private void Rozgrywka_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void planszaGracza_Paint(object sender, PaintEventArgs e)
        {
            Rysowanie.RysujUstawioneKomorki(Gra.Uzytkownik.Plansza, e);
            Rysowanie.RysujKomorki(Gra.Uzytkownik.OdkrytePola, Gra.Uzytkownik.Plansza, e);
        }

        private void planczaKomputera_MouseMove(object sender, MouseEventArgs e)
        {
            myszX = Koordynaty.PobierzKomorke(e.Location.X);
            myszY = Koordynaty.PobierzKomorke(e.Location.Y);

            // odświeżenie planszy 
            // (by rysowała się tylko ta ramka, na którą wskazuje kursor myszy)
            planczaKomputera.Refresh();

            // rysowanie ramki
            Rysowanie.RysujObramowanie(myszX, myszY, 4, planczaKomputera);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int[] strzalKomputera = Gra.StrzalKomputera(Gra.Uzytkownik);

            if (!Gra.WykonajAtak(strzalKomputera[0], strzalKomputera[1], Gra.Komputer, Gra.Uzytkownik))
            {
                timer1.Stop();
                planczaKomputera.Click += planczaKomputera_Click;
            }
            planszaGracza.Refresh();

            if (Gra.Komputer.LiczbaStatkowDoZatopienia == 0)
            {
                MessageBox.Show($"Koniec gry. Wygrał: {Gra.Komputer.Nazwa}");
                planczaKomputera.Enabled = false;
                timer1.Stop();
            }
        }

        private void planczaKomputera_Click(object sender, EventArgs e)
        {
            if (!Gra.Komputer.OdkrytePola[myszX, myszY])
            {
                if (Gra.WykonajAtak(myszX, myszY, Gra.Uzytkownik, Gra.Komputer))
                {
                    planczaKomputera.Refresh();

                    if (Gra.Uzytkownik.LiczbaStatkowDoZatopienia == 0)
                    {
                        MessageBox.Show($"Koniec gry. Wygrał: {Gra.Uzytkownik.Nazwa}");
                        planczaKomputera.Enabled = false;
                    }
                }
                else
                {
                    planczaKomputera.Refresh();
                    planczaKomputera.Click -= planczaKomputera_Click;
                    timer1.Start();
                }
            }
        }

        private void planczaKomputera_Paint(object sender, PaintEventArgs e)
        {
            Rysowanie.RysujUstawioneKomorki(Gra.Komputer.Plansza, e);
            Rysowanie.RysujZatopioneStatki(Gra.Komputer.Plansza, Gra.Komputer.Flota, e);
            Rysowanie.RysujKomorki(Gra.Komputer.OdkrytePola, Gra.Komputer.Plansza, e);
        }
    }
}