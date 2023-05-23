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
        //koordynaty myszki
        int myszX;
        int myszY;

        public Rozgrywka()
        {
            InitializeComponent();
        }

        private void planczaKomputera_MouseMove(object sender, MouseEventArgs e)
        {
            myszX = Koordynaty.PobierzKomorke(e.Location.X);
            myszY = Koordynaty.PobierzKomorke(e.Location.Y);
            planczaKomputera.Refresh();
            Rysowanie.RysujObramowanie(myszX, myszY, 4, planczaKomputera);
        }

        private void planszaGracza_Paint(object sender, PaintEventArgs w)
        {
            Rysowanie.RysujUstawioneKomorki(Gra.Uzytkownik.Plansza, w);
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
        }

        private void planczaKomputera_Click(object sender, EventArgs e)
        {

        }
    }
}
