using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing.Drawing2D;

namespace Surya_s_uitdagingen
{
    class Program
    {
        static void Main(string[] args)
        {
            //Con1 ps5 = new Con1();
            //ps5.Pythagoras(9, 5);
            //ps5.driehoek(4);
            //ps5.kopieer("goku", 5);
            //ps5.druiven();
            //Console.ReadKey();

            Win1 GEOFORCE = new Win1();
            System.Windows.Forms.Application.Run(GEOFORCE);
        }
    }    

    class Con1
    {
        //1. Pythagoras method
        public double Pythagoras(int a, int b)
        {
            double c = Math.Sqrt(a * a + b * b);
            Console.WriteLine(c);
            return c;
        }

        //2. driehoek in console
        public string driehoek(int aantal)
        {
            int teller;
            string driehoek = "";
            for (teller = 0; teller < aantal; teller++)
            {
                driehoek = driehoek + "+";
                Console.WriteLine(driehoek);
            }
            return driehoek;
        }
        
        //3a. kopieer
        public string kopieer(string copy, int paste)
        {
            string text = "";
            for (int teller = 0; teller < paste; teller++)
            {
                text = text + copy;
            }
            Console.WriteLine(text);
            return text;
        }

        //3b. druiventros van nullen in console
        public string druiven()
        {
            Console.WriteLine("Hoeveel lagen wil je hebben?");
            string aantal_lagen = Console.ReadLine();
            int x = int.Parse(aantal_lagen);
            int druiventeller = x;
            string druiven = "";

            for (int teller = 0; teller < x; teller++)
            {
                druiven = druivenmaker("0", druiventeller);
                druiven = puntenmaker(druiven, teller);
                Console.WriteLine(druiven);
                druiventeller--;
            }
            return druiven;
        }
        string druivenmaker(string copy, int paste)
        {
            string text = "";
            string streepje = "";
            for (int teller = 0; teller < paste; teller++)
            {
                text = text + streepje + copy;
                streepje = "-";
            }
            return text;
        }
        string puntenmaker(string copy, int paste)
        {
            for (int teller = 0; teller < paste; teller++)
            {
                string punt = ".";
                copy = punt + copy + punt;
            }
            return copy;
        }
    }

    class Win1 : Form
    {
        //globals
        TextBox text_x, text_y, text_s;
        ComboBox kleur, vorm;
        Panel panel;


        float gx, gy, gs;

        public Win1()
        {
            // misc. posities
            gx = 1000;
            gy = 1000;
            gs = 150;

            // window
            this.Text = "GEOFORCE!";
            this.Size = new Size(900, 640);
            this.BackColor = Color.LightGray;

            // panel
            panel = new Panel();
            panel.Location = new Point(300, 50);
            panel.Size = new Size(500, 500);
            panel.BackColor = Color.White;
            panel.BorderStyle = BorderStyle.FixedSingle;

            // x-pos
            Label x = new Label();
            x.Text = "X-coördinaat";
            x.Size = new Size(70, 30);
            x.Location = new Point(25, 55);
            
            text_x = new TextBox();
            text_x.Text = "250";
            text_x.Size = new Size(55, 30);
            text_x.Location = new Point(100, 50);

            // y-pos
            Label y = new Label();
            y.Text = "Y-coördinaat";
            y.Size = new Size(70, 30);
            y.Location = new Point(25, 90);
            
            text_y = new TextBox();
            text_y.Text = "250";
            text_y.Size = new Size(55, 30);
            text_y.Location = new Point(100, 90);

            // size
            Label s = new Label();
            s.Text = "Grootte";
            s.Size = new Size(70, 30);
            s.Location = new Point(25, 130);

            text_s = new TextBox();
            text_s.Text = "150";
            text_s.Size = new Size(55, 30);
            text_s.Location = new Point(100, 130);

            // vorm
            Label v = new Label();
            v.Text = "Vorm";
            v.Size = new Size(70, 30);
            v.Location = new Point(25, 170);

            vorm = new ComboBox();
            vorm.Size = new Size(70, 25);
            vorm.Location = new Point(100, 170);
            vorm.Text = "Vierkant";
            vorm.Items.Add("Vierkant"); 
            vorm.Items.Add("Cirkel");

            // kleur
            Label k = new Label();
            k.Text = "Kleur";
            k.Size = new Size(70, 30);
            k.Location = new Point(25, 210);

            kleur = new ComboBox();
            kleur.Size = new Size(70, 25);
            kleur.Location = new Point(100, 210);
            kleur.Text = "Zwart";
            kleur.Items.Add("Zwart");
            kleur.Items.Add("Blauw");
            kleur.Items.Add("Rood");
            kleur.Items.Add("Groen");

            // Teken!
            Button Tekenknop = new Button();
            Tekenknop.Text = "Teken!";
            Tekenknop.Size = new Size(55, 30);
            Tekenknop.Location = new Point(55, 250);
            

            // controls
            this.Controls.Add(panel);
            this.Controls.Add(x);
            this.Controls.Add(y);
            this.Controls.Add(s);
            this.Controls.Add(text_x);
            this.Controls.Add(text_y);
            this.Controls.Add(text_s);
            this.Controls.Add(Tekenknop);
            this.Controls.Add(v);
            this.Controls.Add(k);
            this.Controls.Add(vorm);
            this.Controls.Add(kleur);

            // events
            panel.MouseClick += click;
            panel.Paint += teken;
            Tekenknop.Click += this.button;
        }
        public void teken(object sender, PaintEventArgs e)
        {
            if (vorm.Text == "Cirkel")
                cirkelmaker(e, gx - gs / 2, gy - gs / 2, gs, gs);
            if (vorm.Text == "Vierkant")
                boxmaker(e, gx - gs / 2, gy - gs / 2, gs, gs);
        }
        public void cirkelmaker(PaintEventArgs e, float x, float y, float b, float l)
        {
            Brush zwart = new SolidBrush(Color.Black);
            Brush blauw = new SolidBrush(Color.Blue);
            Brush rood = new SolidBrush(Color.Red);
            Brush groen = new SolidBrush(Color.Green);

            if (kleur.Text == "Zwart")
                e.Graphics.FillEllipse(zwart, x, y, b, l);
            if (kleur.Text == "Blauw")
                e.Graphics.FillEllipse(blauw, x, y, b, l);
            if (kleur.Text == "Rood")
                e.Graphics.FillEllipse(rood, x, y, b, l);
            if (kleur.Text == "Groen")
                e.Graphics.FillEllipse(groen, x, y, b, l);

        }
        public void boxmaker(PaintEventArgs e, float x, float y, float b, float l)
        {
            Brush zwart = new SolidBrush(Color.Black);
            Brush blauw = new SolidBrush(Color.Blue);
            Brush rood = new SolidBrush(Color.Red);
            Brush groen = new SolidBrush(Color.Green);

            if (kleur.Text == "Zwart")
                e.Graphics.FillRectangle(zwart, x, y, b, l);
            if (kleur.Text == "Blauw")
                e.Graphics.FillRectangle(blauw, x, y, b, l);
            if (kleur.Text == "Rood")
                e.Graphics.FillRectangle(rood, x, y, b, l);
            if (kleur.Text == "Groen")
                e.Graphics.FillRectangle(groen, x, y, b, l);
        }
        public void click(object sender, MouseEventArgs e)
        {
            gx = e.X;
            gy = e.Y;
            text_x.Text = gx.ToString();
            text_y.Text = gy.ToString();
            panel.Invalidate(); // refresht wat er gebeurt met een klik in panel
        }
        public void button(object sender, EventArgs e)
        {
            gx = float.Parse(text_x.Text);
            gy = float.Parse(text_y.Text);
            gs = float.Parse(text_s.Text);
            this.Invalidate();
            panel.Invalidate();
            // error: wanneer tekst in textbox wordt gezet, box wordt niet in panel verplaatst
        }
    }
}
