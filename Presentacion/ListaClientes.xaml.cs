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
using System.Windows.Shapes;
using Negocio;

namespace Presentacion
{
    /// <summary>
    /// Lógica de interacción para ListaClientes.xaml
    /// </summary>
    public partial class ListaClientes : Window
    {
        nCliente f = new nCliente();
        public ListaClientes()
        {
            InitializeComponent();
            CLienteDT.Items.Clear();
            CLienteDT.ItemsSource = f.Listar().OrderBy(k => k.FRECUENCIA);

        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
