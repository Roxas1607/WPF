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
               
                string depart  = TxtEmail.Text.Trim();
                string destination= TxtDestiation.Text.Trim();
                string mdp = TxtMdp.Text.Trim();

                string sujet = TxtBonjour.Text.Trim();

                string corps= TxtText.Text.Trim();

                MailMessage mail = new MailMessage(depart, destination, sujet, corps);
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential(depart, mdp);
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