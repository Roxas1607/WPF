using System;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GestionEmail
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

      
        private void TxtText_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               
                string email_proprio = "hova1608@gmail.com";
                string mdp = "nnbudxddyvgxcxzo"; // mot de passe d’application Gmail

                // Récupération de l’UI
                string email_destiantion = TxtDestination.Text.Trim();
                string body = TxtText.Text.Trim();

                // Vérification basique
                if (string.IsNullOrEmpty(email_destiantion) || string.IsNullOrEmpty(body))
                {
                    MessageBox.Show("Veuillez remplir l’adresse et le message.");
                    return;
                }

                // Création du mail
                MailMessage mail = new MailMessage(email_proprio, email_destiantion);
                mail.Subject = "Message automatique";
                mail.Body = body;

                // Config SMTP Gmail
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(email_proprio, mdp);
                smtp.EnableSsl = true;

                // Envoi
                smtp.Send(mail);

                MessageBox.Show("Email envoyé ✅");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }
    }


    }
