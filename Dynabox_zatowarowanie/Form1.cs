using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dynabox_zatowarowanie
{
    public partial class Form1 : Form
    {
        Kolejka k = new Kolejka();
        List<CheckBox> drzwi = new List<CheckBox>();
        List<PictureBox> wiz = new List<PictureBox>();

        public Form1()
        {
            InitializeComponent();
            drzwi.Add(checkBox1);
            drzwi.Add(checkBox2);
            drzwi.Add(checkBox3);
            drzwi.Add(checkBox4);
            drzwi.Add(checkBox5);
            drzwi.Add(checkBox6);
            drzwi.Add(checkBox7);
            drzwi.Add(checkBox8);
            drzwi.Add(checkBox9);
            drzwi.Add(checkBox10);
            drzwi.Add(checkBox11);
            drzwi.Add(checkBox12);
            drzwi.Add(checkBox13);

            wiz.Add(pictureBox1);
            wiz.Add(pictureBox2);
            wiz.Add(pictureBox3);
            wiz.Add(pictureBox4);
            wiz.Add(pictureBox5);
            wiz.Add(pictureBox6);
            wiz.Add(pictureBox7);
            wiz.Add(pictureBox8);
            wiz.Add(pictureBox9);
            wiz.Add(pictureBox10);
            wiz.Add(pictureBox11);
            wiz.Add(pictureBox12);
            wiz.Add(pictureBox13);
        }

        private void Pokaz()
        {
            textBox_kolejka.Text = null;
            short[] kolejka = k.Display();
            for (short i = 0; i < 16; i++)
            {
                textBox_kolejka.Text += ' ' + kolejka[i].ToString(); 
            }
        }

        private void button_dodaj_Click(object sender, EventArgs e)
        {
            for(short i = 0; i < 13; i++)
            {
                if (drzwi[i].Checked == true) k.Add(short.Parse(drzwi[i].Text));
            }
            Pokaz();
            label_ilosc.Text = k.GetNumberOfElements().ToString();
        }

        private void button_pobierz_Click(object sender, EventArgs e)
        {
            label_el.Text = k.Get().ToString();
            Pokaz();
            label_ilosc.Text = k.GetNumberOfElements().ToString();
        }

        private void button_wyslij_rozkaz_Click(object sender, EventArgs e)
        {
            int ilosc_drzwi = k.GetNumberOfElements();
            if (ilosc_drzwi > 3) ilosc_drzwi = 3;
            for (short i = 0; i < ilosc_drzwi; i++)
            {
                short address = k.Get();
                wiz[address - 1].BackColor = Color.Green;
            }
            label_ilosc.Text = k.GetNumberOfElements().ToString();
            // od teraz służy do określenia, które drzwi zostały zamknięte
            for (short j = 0; j < 13; j++)
            {
                drzwi[j].Checked = false;
            }
        }
    }
}
