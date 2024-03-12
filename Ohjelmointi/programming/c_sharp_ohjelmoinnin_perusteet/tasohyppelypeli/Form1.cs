using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tasohyppelypeli
{
    public partial class Form1 : Form
    {

        bool menevasemmalle, meneoikealle, hyppaa, peliloppuu;

        int hyppynopeus = 10;
        int voima = 8;
        int pisteet = 0;
        int pelaajanopeus = 7;

        
        int pystysuoranopeusyksi = 1;
        int pystysuoranopeuskaksi = 1;
        int pystysuoranopeuskolme = 1;

        int vihollisennopeus = 1;



        public Form1()
        {
            InitializeComponent();
        }

        private void pelaaja_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Paapeliajastin(object sender, EventArgs e)
        {
            
            txtpisteet.Text = "Pisteet: " + pisteet;
            pelaaja.Top += hyppynopeus;

            if (menevasemmalle == true)
            {
                pelaaja.Left -= pelaajanopeus;
            }
            if (meneoikealle == true)
            {
                pelaaja.Left += pelaajanopeus;
            }

            if (hyppaa == true && voima < 0)
            {

                hyppaa = false;
            }
            if (hyppaa == true)
            {
                hyppynopeus = -8;
                voima -= 1;
            }
            else
            {
                hyppynopeus = 10;
            }
        
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    if ((string)x.Tag == "taso")
                    {
                        if (pelaaja.Bounds.IntersectsWith(x.Bounds))
                        {
                            voima = 8;
                            pelaaja.Top = x.Top - pelaaja.Height;

                        }
                        x.BringToFront();
                    }

                    if ((string)x.Tag == "tahti")
                    {
                        if (pelaaja.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                        {
                            x.Visible = false;
                            pisteet++;

                        }


                    }


                    if ((string)x.Tag == "vihollinen")
                    {
                        if (pelaaja.Bounds.IntersectsWith(x.Bounds))
                        {

                            peliajastin.Stop();
                            peliloppuu = true;
                            txtpisteet.Text = "Pisteet: " + pisteet + Environment.NewLine + "Naula puhkaisi pallon!";

                        }


                    }





                }

                liikkuvayksi.Top += pystysuoranopeusyksi;

                if (liikkuvayksi.Top < 197 || liikkuvayksi.Top > 423)
                {
                    pystysuoranopeusyksi = -pystysuoranopeusyksi;

                }

                liikkuvakaksi.Top += pystysuoranopeuskaksi;

                if (liikkuvakaksi.Top < 166 || liikkuvakaksi.Top > 438)
                {
                    pystysuoranopeuskaksi = -pystysuoranopeuskaksi;

                }

                liikkuvakolme.Top += pystysuoranopeuskolme;

                if (liikkuvakolme.Top < 76 || liikkuvakolme.Top > 477)
                {
                    pystysuoranopeuskolme = -pystysuoranopeuskolme;

                }

                if (pelaaja.Bounds.IntersectsWith(maali.Bounds) && pisteet == 10)
                {
                    peliajastin.Stop();
                    peliloppuu = true;
                    txtpisteet.Text = "Pisteet: " + pisteet + Environment.NewLine + "Voitit Pelin keräämällä kaikki pisteet ja pääsemällä maaliin!";

                }
                else
                {
                    txtpisteet.Text = "Pisteet : " + pisteet + Environment.NewLine + "Kerää kaikki 10 tähteä voittaaksesi pelin!";

                }



            }


            foreach(Control x in this.Controls)
            {
                if ((string)x.Tag =="taso")
                {
                    if (pelaaja.Bounds.IntersectsWith(x.Bounds))
                    {
                        voima = 8;
                        pelaaja.Top = x.Top - pelaaja.Height;

                    }

                    x.BringToFront();
                }






            }




        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                menevasemmalle = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                meneoikealle = true;
            }
            if (e.KeyCode == Keys.Space && hyppaa == false)
            {
                hyppaa = true;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                menevasemmalle = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                meneoikealle = false;
            }
            if (hyppaa == true)
            {
                hyppaa = false;
            }

            if (e.KeyCode == Keys.Enter && peliloppuu == true)
            {
                RestartGame();
            }



        }

        private void RestartGame()
        {
            hyppaa = false;
            meneoikealle = false;
            menevasemmalle = false;
            peliloppuu = false;
            pisteet = 0;

            txtpisteet.Text = "Pisteet " + pisteet;

            foreach (Control x in this.Controls)
            {

                if (x is PictureBox && x.Visible == false)
                 {
                    x.Visible = true;
                }
            }

            pelaaja.Left = 12;
            pelaaja.Top = 560;
            
            vihollinenyksi.Left = 271;
            vihollinenyksi.Top = 510;
            
            vihollinenkaksi.Left = 488;
            vihollinenkaksi.Top = 510;
            
            vihollinenkolme.Left = 620;
            vihollinenkolme.Top = 290;
            
            liikkuvayksi.Left = 321;
            liikkuvayksi.Top = 388;
            
            liikkuvakaksi.Left = 879;
            liikkuvakaksi.Top = 405;
            
            liikkuvakolme.Left = 991;
            liikkuvakolme.Top = 327;

            peliajastin.Start();
        }
    }
}
