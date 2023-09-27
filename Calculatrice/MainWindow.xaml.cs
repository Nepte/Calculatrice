using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Calculatrice
{
    public partial class MainWindow : Window
    {
        private string operationEnCours = "";
        private double valeurActuelle = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Chiffre_Click(object sender, RoutedEventArgs e)
        {
            Button bouton = (Button)sender;
            string chiffre = bouton.Content.ToString();

            if (operationEnCours == "=")
            {
                TB_Display.Text = chiffre;
                operationEnCours = "";
            }
            else
            {
                if (TB_Display.Text == "0")
                {
                    if (chiffre == ",")
                    {
                        // Si le chiffre est une virgule et TB_Display affiche déjà "0", affiche "0,"
                        TB_Display.Text += ",";
                    }
                    else
                    {
                        // Sinon, remplace "0" par le chiffre
                        TB_Display.Text = chiffre;
                    }
                }
                else
                {
                    TB_Display.Text += chiffre;
                }
            }
        }

        private void Operateur_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TB_Display.Text))
            {
                Button bouton = (Button)sender;
                string operateur = bouton.Content.ToString();

                if (!string.IsNullOrEmpty(operationEnCours))
                {
                    BTN_Egale_Click(sender, e);
                }

                operationEnCours = operateur;
                TB_Display.Text += " " + operateur + " ";
            }
        }

        private void BTN_Egale_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TB_Display.Text) && !string.IsNullOrEmpty(operationEnCours))
            {
                string[] elements = TB_Display.Text.Split(' ');
                double nombre1 = double.Parse(elements[0]);
                double nombre2 = double.Parse(elements[2]);
                double resultat = 0;

                switch (operationEnCours)
                {
                    case "+":
                        resultat = Math.Round(nombre1 + nombre2, 2);
                        break;
                    case "-":
                        resultat = Math.Round(nombre1 - nombre2, 2);
                        break;
                    case "*":
                        resultat = Math.Round(nombre1 * nombre2, 2);
                        break;
                    case "/":
                        if (nombre2 != 0)
                        {
                            resultat = Math.Round(nombre1 / nombre2, 2);
                        }
                        else
                        {
                            TB_Display.Text = "Erreur";
                            return;
                        }
                        break;
                }

                TB_Display.Text = resultat.ToString();
                operationEnCours = "=";
            }
        }

        private void BTN_AC_Click(object sender, RoutedEventArgs e)
        {
            TB_Display.Text = "0";
            operationEnCours = "";
            valeurActuelle = 0;
        }

        private void BTN_Plus_Moins_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TB_Display.Text))
            {
                double nombre = double.Parse(TB_Display.Text);
                nombre = -nombre;
                TB_Display.Text = nombre.ToString();
            }
        }

        private void BTN_Pourcentage_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TB_Display.Text))
            {
                double nombre = double.Parse(TB_Display.Text);
                nombre /= 100;
                TB_Display.Text = nombre.ToString();
            }
        }
    }
}