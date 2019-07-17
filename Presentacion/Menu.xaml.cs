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
using System.Windows.Shapes;
using System.Windows.Threading;
using Entidades;
namespace Presentacion
{
    /// <summary>
    /// Lógica de interacción para Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {


        public Menu()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            try{
            var fullFilePath = @Login.n.linkfoto;
            
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(fullFilePath, UriKind.Absolute);
            bitmap.EndInit();

            ok.Source = bitmap;
            }
            catch
            {
                MessageBox.Show("Imagen no encontrada");
            }

        }

        private  void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            if (Login.n.Cargo == "CAMPO MARTE" || Login.n.Cargo == "SALAVERRY" || Login.n.Cargo.ToUpper() == "LARCOBIKE")
            {
                REPORTES.Visibility = Visibility.Collapsed;
                ImgReportes.Visibility = Visibility.Collapsed;
            }
            DispatcherTimer dispathcer = new DispatcherTimer();
            dispathcer.Interval = new TimeSpan(0, 0, 1);
            dispathcer.Tick += (s, a) =>
            {
                Hora.Content = DateTime.Now.ToLongTimeString();
                Dia.Text = DateTime.Now.ToLongDateString();
            };
            dispathcer.Start();
            NombreCompleto.Content = Login.n.Nombre; Cargo.Content = Login.n.Cargo;
            DoubleAnimation x = new DoubleAnimation(0, 1, new Duration(TimeSpan.FromSeconds(0.5)));
            Grid.BeginAnimation(OpacityProperty, x);
        }
        
        private void ALQUILER_Click(object sender, RoutedEventArgs e)
        {
            hojaAlquiler x = new hojaAlquiler();
            x.Show();
        }

        private void CLIENTES_Click(object sender, RoutedEventArgs e)
        {
            ListaClientes asd = new ListaClientes();
            asd.Show();
        }

        private void REPORTES_Click(object sender, RoutedEventArgs e)
        {
            Reportes a = new Reportes();
            a.Show();
        }

        private void Close_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Min_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Cambio_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow a = new MainWindow();
            a.Show();
            this.Close();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {

            DragMove();
            }
            catch
            {

            }
        }
    }
}
