using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace OrvosiNobeldijasokGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (txt_ev.Text != "" || txt_nev.Text !=""|| txt_orszag.Text!="" || txt_szh.Text!="")
            {
                
                    int ev =int.Parse( txt_ev.Text);
                    if (ev>1989)
                    {
                        try
                        {

                        if (File.Exists("eredmenyek.txt"))
                        {
                            File.AppendAllText("eredmenyek.txt", txt_ev.Text + ";" + txt_nev.Text + ";" + txt_szh.Text + ";" + txt_orszag.Text + "\n");
                        }
                        else
                        {

                            File.AppendAllText("eredmenyek.txt", "Év;Név;SzületésHalálozás;Országkód\n");

                        }
                        File.AppendAllText("eredmenyek.txt", txt_ev.Text + ";" + txt_nev.Text + ";" + txt_szh.Text + ";" + txt_orszag.Text + "\n");

                    }
                        catch (Exception)
                        {

                        MessageBox.Show("Hiba az állomány írásánál!");
                        }
                       
                    }
                    else
                    {
                        MessageBox.Show("Hiba! Az évszám nem megfelelő!", "Mentés");
                    }
                
            }
            else
            {
                MessageBox.Show("Töltsön ki midnen mezőt!");
            }
        }
    }
}
