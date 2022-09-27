using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Noppapeli
{
    // Luo luokka "Noppa", jossa on tallessa nopan arvo 1-6
    // nopalla on myös "Heitto"-metodi, joka arpoo sille arvon 1-6
    // Anna nopalle myös constructor-metodi, joka heti alussa arpoo arvon

    // Lähde tekemään Yatzi-peli

    // Lisää nopalle kuvat 1-6

    public partial class Form1 : Form
    {
        // property
        private Random rng = new Random();
        //Noppa noppa1 = new Noppa(6);
        List<Noppa> Nopat = new List<Noppa>();
        public Form1() // constructor, suoritetaan heti alussa
        {
            InitializeComponent();
            // luodaan 5 noppaa
            for (int i = 0; i < 5; i++)
            {
                PictureBox tempPB = new PictureBox();

                this.Controls.Add(tempPB);

                Noppa tempNoppa = new Noppa(6, tempPB);

                Nopat.Add(tempNoppa);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // for käy läpi kaikki listan nopat
            for (int i = 0; i < Nopat.Count; i++)
            {
                Nopat[i].Heitto(rng);
                editPictureBox(Nopat[i], i);
                //label1.Text = noppa1.Luku.ToString();
            }
            //noppa1.Heitto();
            //editPictureBox(noppa1, 1);
            //label1.Text = noppa1.Luku.ToString();
            // lisää nopalle property "Koko", jolla määritellään
            // montako silmälukua nopalla on
            // ja käytetään sitä luvun arvonnassa
            // nopan koko annetaan sitä generoidessa
        }

        private void editPictureBox(Noppa jokuNoppa, int count)
        {
            const int spacing = 60;

            string key = jokuNoppa.GetNoppaKey();
            jokuNoppa.Boxi.Image = Noppa.GetPictureResX(key);
            jokuNoppa.Boxi.Location = new
                Point(13 + count * spacing, 13);
        }

        // Käy läpi Nopat-listan ja summaa kaikki ykköset
        private void buttonOnes_Click(object sender, EventArgs e)
        {
            // lista
            // elementti - indeksi => int i = 0 => listan loppuun
            // elementti - indeksi
            // elementti - indeksi
            // elementti - indeksi

            // muuttuja, johon tulee summa talteet, oletuksena = 0
            // käydään läpi lista, eli tarvitaan silmukka
            // tarkistetaan onko nopan luku yksi, if-else
            //       indeksi vaihtuu joka kierros, eli tarkistetaan
            //      eri elementtiä<
            // jos totta, lisätään nopan luku summaan
        }

        private void buttonPair_Click(object sender, EventArgs e)
        {
           // { 0, 2, 0, 1, 3, 0 }
            int[] pairs = new int[6]; // count how many of each dice value is found
            // { 0, 4, 0, 0, 10, 0 }
            int[] pairValues = new int[6];
            const int multiplier = 2; // number of dices found, is only multiplied by 2, since you get points for the pair
            // 0 - 5
            for (int i = 0; i < pairs.Length; i++)
            {
                // linQ kirjaston metodeja
                pairs[i] = Nopat.Where(test => 
                    test.Luku == i + 1).Count();
            }

            for (int i = 0; i < pairs.Length; i++)
            {
                if (pairs[i] > 1) // lasketaan vain parit + yli
                {
                    // tarkistetaan, että löytyi 2 paria
                    pairValues[i] = (i + 1) * multiplier;
                }
            }
            // {0, 4, 0, 8, 0, 0}
            buttonPair.Text = pairValues.Max().ToString();

            // päivitetään summa napin teksti
        }
    }
}
