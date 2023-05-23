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
    public partial class UstawienieStatkow : Form
    {
        //współrzędne myszy
        int myszX;
        int myszY;
        //indeks do tablicy z długością statków
        int indexAktualnegoStatku;
        //poziomo = true, pionowo = false
        bool poziom;
        bool[] rozmieszczoneStatki = new bool[4];
        public UstawienieStatkow()
        {
            InitializeComponent();
            planszaGracza.Width = 400;
            planszaGracza.Height = 400;
            poziom = true;
            Gra.Uzytkownik = new Gracz();
            Gra.Komputer = new Gracz();
            indexAktualnegoStatku = 0;
            lblNazwaGracza.Visible = false;
            btnDalej.Enabled = false;
        }

        private void btnObrot_Click(object sender, EventArgs e)
        {
            poziom = !poziom;
        }

        private void planszaGracza_MouseMove(object sender, MouseEventArgs e)
        {
            if (indexAktualnegoStatku < rozmieszczoneStatki.Length)
            {
                myszX = Koordynaty.PobierzKomorke(e.Location.X);
                myszY = Koordynaty.PobierzKomorke(e.Location.Y);
                planszaGracza.Refresh();
                if (poziom)
                {
                    for (int i = 0; i < Gra.RozmiaryStatkow[indexAktualnegoStatku]; i++)
                    {
                        if (myszX + i <= Gracz.OSTATNI_INDEX_PLANSZY)
                        {
                            Rysowanie.RysujObramowanie(myszX + i, myszY, indexAktualnegoStatku, planszaGracza);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < Gra.RozmiaryStatkow[indexAktualnegoStatku]; i++)
                    {
                        if (myszY + i <= Gracz.OSTATNI_INDEX_PLANSZY)
                        {
                            Rysowanie.RysujObramowanie(myszX, myszY + i, indexAktualnegoStatku, planszaGracza);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }

        private void planszaGracza_Click(object sender, EventArgs e)
        {
            if (Gra.CzyMoznaPostawicStatek(indexAktualnegoStatku, myszX, myszY, poziom, Gra.Uzytkownik.Plansza))
            {
                rozmieszczoneStatki[indexAktualnegoStatku] = true;
                Gra.RozmiescStatek(indexAktualnegoStatku, myszX, myszY, poziom, Gra.Uzytkownik.Plansza);
                planszaGracza.Refresh();
                if (indexAktualnegoStatku < Gra.RozmiaryStatkow.Length)
                {
                    indexAktualnegoStatku++;
                    int pos = Array.IndexOf(rozmieszczoneStatki, false);
                    if (pos == -1)
                    {
                        btnDalej.Enabled = true;
                        planszaGracza.Enabled = false;
                    }
                }
                
            }

        }

        private void planszaGracza_Paint(object sender, PaintEventArgs e)
        {
            Rysowanie.RysujUstawioneKomorki(Gra.Uzytkownik.Plansza, e);
        }

        private void btnDalej_Click(object sender, EventArgs e)
        {
            if (txtNazwaGracza.Text == "")
            {
                lblNazwaGracza.Visible = true;
            }
            else
            {
                Gra.Uzytkownik.Nazwa = txtNazwaGracza.Text;
                Gra.Komputer.Nazwa = "bot";
                Gra.RozmieszczenieStatkowKomputera();
                Hide();
                Rozgrywka rozgrywka = new Rozgrywka();
                rozgrywka.Show();
            }
        }
    }
}
