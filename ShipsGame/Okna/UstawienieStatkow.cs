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
            indexAktualnegoStatku = 3;
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
    }
}
