using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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
using Entidades;
using Negocio;

namespace Presentacion
{
    /// <summary>
    /// Lógica de interacción para Reportes.xaml
    /// </summary>
    public partial class Reportes : Window
    {
        nAlquiler op = new nAlquiler();
        int pos = 0;
        private int pos1 = 0;
        public void Cargar(int pos2)
        {
            try {
                var t = op.ListarCliente("");
            List<Ingresos> _bar = new List<Ingresos>();
                string a; string b;
                int laring=0; int campoing = 0; int saling = 0;
                string f;
                if (pos2 == 0) { f = DateTime.Now.ToShortDateString(); } else if (pos2 == 1) { f = DateTime.Now.AddDays(-7).ToShortDateString(); } else { f = DateTime.Now.AddMonths(-1).ToShortDateString(); }
                foreach (var item in t)
                {

                    if (item.PUNTO == "LARCO" && Convert.ToDateTime(item.FECHA) >= Convert.ToDateTime(f)) { 
                    a = item.PAGADO.Remove(0, 2);
                     b = a.Remove(a.Length - 3, 3);
                    laring = Convert.ToInt32(b) + laring;
                    }
                    if (item.PUNTO == "CAMPO MARTE" && Convert.ToDateTime(item.FECHA) >= Convert.ToDateTime(f))
                    {
                     a = item.PAGADO.Remove(0, 2);
                     b = a.Remove(a.Length - 3, 3);
                       campoing = Convert.ToInt32(b) + campoing;
                    }
                    if (item.PUNTO == "SALAVERRY" && Convert.ToDateTime(item.FECHA) >= Convert.ToDateTime(f))
                    {
                     a = item.PAGADO.Remove(0, 2);
                     b = a.Remove(a.Length - 3, 3);
                        saling = Convert.ToInt32(b) + saling;
                    }
                }
                Ingresos a2 = new Ingresos { Dinero = saling, Nombre = "SALAVERRY" };
                Ingresos b2 = new Ingresos { Dinero = campoing, Nombre = "CAMPO MARTE" };
                Ingresos c = new Ingresos { Dinero = laring, Nombre = "LARCO" };
                _bar.Add(a2); _bar.Add(b2); _bar.Add(c);
                
                Time.Content = "Ultima actualizacion a las " + DateTime.Now.ToShortTimeString();
            this.DataContext = new RecordCollection(_bar);
            }
            catch(Exception)
            {
                
               MessageBox.Show("Error de conexion a internet");
            }

        }
        public Reportes()
        {
            InitializeComponent();
            NextIngreso.Visibility = Visibility.Collapsed;
            Cargar(pos1);
            NextIngreso.Visibility = Visibility.Visible;
        }
        class RecordCollection : ObservableCollection<Record>
        {

            public RecordCollection(List<Ingresos> barvalues)
            {
                
                Random rand = new Random();
                BrushCollection brushcoll = new BrushCollection();
                foreach (Ingresos barval in barvalues)
                {
                    int num = rand.Next(brushcoll.Count / 3);
                   
                    Add(new Record(barval.Dinero, brushcoll[num], barval.Nombre));
                }
            }

        }

        class BrushCollection : ObservableCollection<Brush>
        {
            public BrushCollection()
            {
                Type _brush = typeof(Brushes);
                PropertyInfo[] props = _brush.GetProperties();
                foreach (PropertyInfo prop in props)
                {
                    Brush _color = (Brush)prop.GetValue(null, null);
                    if (_color != Brushes.LightSteelBlue && _color != Brushes.White &&
                         _color != Brushes.WhiteSmoke && _color != Brushes.LightCyan &&
                         _color != Brushes.LightYellow && _color != Brushes.Linen)
                        Add(_color);
                }
            }
        }

        class Ingresos
        {

            public string Nombre { set; get; }

            public int Dinero  { set; get; }

        }

        class Record : INotifyPropertyChanged
        {
            public Brush Color { set; get; }
            public int Number { set; get; }
            public string Name { set; get; }

            private int _data;
            public int Data
            {
                set
                {
                    if (_data != value)
                    {
                        _data = value;

                    }
                }
                get
                {
                    return _data;
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            public Record(int value, Brush color, string name)
            {
                Data = value;
                Color = color;
                Name = name;
                Number = value;
            }

            protected void PropertyOnChange(string propname)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propname));
                }
            }
        }


        private void Actualizar_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            Cargar(pos1);

        }

        private void SobreClick(object sender, RoutedEventArgs e)
        {

        }

        private void AnuClick(object sender, RoutedEventArgs e)
        {
            if(Local.Content.ToString()!=""&& Local.Content.ToString() != null&&Anu1.Text!=""&& Anu1.Text != null && Anu2.Text != "" && Anu2.Text != null) { 
            List<eAnulacion> cam = new List<eAnulacion>();
            if (DateTime.Compare(Convert.ToDateTime(Anu1.Text), Convert.ToDateTime(Anu2.Text)) < 0|| DateTime.Compare(Convert.ToDateTime(Anu1.Text), Convert.ToDateTime(Anu2.Text)) == 0)
            {

            var t= op.ListarAnulaciones().ToList();
            foreach (var item in t)
            {
                    if (DateTime.Compare(Convert.ToDateTime(Anu1.Text), Convert.ToDateTime(item.Dia)) == 0|| (DateTime.Compare(Convert.ToDateTime(item.Dia), Convert.ToDateTime(Anu2.Text)) < 0&& DateTime.Compare(Convert.ToDateTime(Anu1.Text), Convert.ToDateTime(item.Dia)) < 0) || DateTime.Compare(Convert.ToDateTime(item.Dia), Convert.ToDateTime(Anu2.Text)) == 0)
                    {
                        cam.Add(item);
                    }
            }
             var h=   cam.Where(k => k.Sede == Local.Content.ToString());
                    if (h != null) { 
                    Anulaciones.Content = "Cantidad: " + h.Count();
                    }
                }
            else
            {
                MessageBox.Show("El tiempo de inicio no puede ser mayor al del final");
            }
        }
        }

        private void Path_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (pos==0)
            {
                Local.Content = "CAMPO MARTE";
                pos++;
            }
            else if (pos == 1)
            {
                Local.Content = "SALAVERRY";
                pos++;

            }
            else
            {
                Local.Content = "LARCO";
                pos = 0;
            }
        }

        private void Path2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (pos1 == 0)
            {
                IngresoReport.Content = "Ingreso diario por Local";
                NextIngreso.Visibility = Visibility.Collapsed;
                Cargar(pos1);
                NextIngreso.Visibility = Visibility.Visible;
                pos1++;
            }
            else if (pos1 == 1)
            {
                IngresoReport.Content = "Ingreso semanal por Local";
                NextIngreso.Visibility = Visibility.Collapsed;
                Cargar(pos1);
                NextIngreso.Visibility = Visibility.Visible;
                pos1++;

            }
            else
            {
                IngresoReport.Content = "Ingreso mensual por Local";
                NextIngreso.Visibility = Visibility.Collapsed;
                Cargar(pos1);
                NextIngreso.Visibility = Visibility.Visible;
                pos1 = 0;
            }
        }
    }
}

