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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Negocio;

namespace Presentacion
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        nLogin a = new nLogin();
       
        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.Manual;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Cloase_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Usuario_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void COntraseña_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void COntraseña_GotFocus(object sender, RoutedEventArgs e)
        {
            if (COntraseña.Password == "Contraseña")
            {
                COntraseña.Clear();
            }
        }

        private void Usuario_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Usuario.Text == "Usuario")
            {
                Usuario.Clear();
            }
        }

        private void COntraseña_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {


        }

        private void Usuario_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Usuario.Text.Length == 0)
            {
                Usuario.Text = "Usuario";
            }
        }

        private void COntraseña_LostFocus(object sender, RoutedEventArgs e)
        {
            if (COntraseña.Password.Length == 0)
            {
                COntraseña.Password = "Contraseña";
            }

        }

        private void COntraseña_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }

        private void ojo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            COntraseña.PasswordChar = '\0';
        }

        private void Esperar()
        {
            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
            iniciobtn.IsEnabled = false;
        }
        private void Volver()
        {
            Mouse.OverrideCursor = null;
            iniciobtn.IsEnabled = true;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Entrar();
        }
        private void Entrar()
        {
            Esperar();
            if (a.Logear(Usuario.Text, COntraseña.Password))
            {
                Menu jk = new Menu();
                jk.Show();
                Volver();
                this.Close();
            }
            else
            {
                Incorrecto.Visibility = Visibility.Visible;
                Volver();
            }
        }

        private void Button_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void iniciobtn_GotFocus(object sender, RoutedEventArgs e)
        {
        }

        private void iniciobtn_IsStylusDirectlyOverChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {


        }
        private void B_Load(object sender, RoutedEventArgs e)
        {
            DoubleAnimation x = new DoubleAnimation(0, 1, new Duration(TimeSpan.FromSeconds(0.7)));
            Negro.BeginAnimation(OpacityProperty, x);
        }

        private void COntraseña_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Entrar();
            }
        }

        private void Usuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Entrar();
              
            }
        }

        private void ojo_MouseUp(object sender, MouseButtonEventArgs e)
        {
            COntraseña.PasswordChar = '*';
        }
    }
}
