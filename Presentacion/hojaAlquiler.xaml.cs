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
using Entidades;
using System.Reactive.Linq;
using Firebase.Database;
using System.Net;
using System.IO;
using System.Windows.Threading;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Printing;
using System.Drawing;
using System.Drawing.Printing;
namespace Presentacion
{
    /// <summary>
    /// Lógica de interacción para hojaAlquiler.xaml
    /// </summary>
    public partial class hojaAlquiler : Window
    {
        nAlquiler alquiler = new nAlquiler();
        string hu;
        eAlquiler hth = new eAlquiler();
        
        nCliente to = new nCliente();

        void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            int SPACE = 105;
            string title = System.Windows.Forms.Application.StartupPath + "\\CBT_Title.png";
            string barcode = System.Windows.Forms.Application.StartupPath + "\\code128bar.jpg";
            Graphics g = e.Graphics;
            g.DrawRectangle(Pens.Black, 1, 5, 188, 420);



            g.DrawImage(System.Drawing.Image.FromFile(title), 37, 6, 120, 120);
            Font fBody = new Font("Lucida Console", 10,System.Drawing.FontStyle.Bold);
            Font fBody1 = new Font("Lucida Console", 10, System.Drawing.FontStyle.Regular);
            Font fBody12 = new Font("Lucida Console", 6, System.Drawing.FontStyle.Bold);
            Font rs = new Font("Stencil", 18, System.Drawing.FontStyle.Bold);
            Font fTType = new Font("", 150, System.Drawing.FontStyle.Bold);
            SolidBrush sb = new SolidBrush(System.Drawing.Color.Black);


            g.DrawString("--------------------", fBody1, sb, 7, 130);

            g.DrawString("Fecha:", fBody, sb, 10, SPACE + 10);
            g.DrawString(DateTime.Now.ToShortDateString(), fBody1, sb, 70, SPACE + 10);

            g.DrawString("N°Ticket:", fBody, sb, 10, SPACE + 40);
            g.DrawString(hth.CODIGO, fBody1, sb, 100, SPACE + 40);

            g.DrawString("INICIO:", fBody, sb, 10, SPACE + 70);
            g.DrawString(hth.INICIO, fBody1, sb, 80, SPACE + 70);


            g.DrawString("FIN:", fBody, sb, 10, SPACE + 90);
            g.DrawString(hth.FIN, fBody1, sb, 50, SPACE + 90);

            //g.DrawString("DriverName:", fBody, sb, 10, SPACE+120);
            //g.DrawString(txtDriveName.Text, fBody1, sb, 153, SPACE + 120);

            g.DrawString("LUGAR:", fBody, sb, 10, SPACE + 110);
            g.DrawString(hth.PUNTO, fBody1, sb, 70, SPACE + 110);

            g.DrawString("NOMBRE:", fBody, sb, 10, SPACE + 130);
            g.DrawString(hth.NombreCompleto.Substring(0,8), fBody1, sb, 80, SPACE + 130);

            g.DrawString("Total."+hth.PAGADO, rs, sb, 9, SPACE + 160);

            g.DrawImage(System.Drawing.Image.FromFile(barcode), 6, SPACE + 190, 180, 40);
            g.DrawString("    -------------------------    ", fBody12, sb, 7, 373);
            g.DrawString("        FIRMA DEL CLIENTE        ", fBody12, sb, 2, 380);
            g.DrawString(" Se acepta los terminos indicados", fBody12, sb, 2, 396);
            g.DrawString(" Num.Emergencias: (+51) 989157166", fBody12, sb, 2, 405);

        }
        void pd_PrintPageAnulacion(object sender, PrintPageEventArgs e)
        {
            string title = System.Windows.Forms.Application.StartupPath + "\\CBT_Title.png";
            string barcode = System.Windows.Forms.Application.StartupPath + "\\code128bar.jpg";
            Graphics g = e.Graphics;
            g.DrawRectangle(Pens.Black, 1, 5, 188, 390);



            g.DrawImage(System.Drawing.Image.FromFile(title), 37, 6, 120, 120);
            Font fBody = new Font("Lucida Console", 10, System.Drawing.FontStyle.Bold);
            Font fBody1 = new Font("Lucida Console", 10, System.Drawing.FontStyle.Regular);
            Font fBody12 = new Font("Lucida Console", 6, System.Drawing.FontStyle.Bold);
            Font fBody122 = new Font("Lucida Console", 8, System.Drawing.FontStyle.Bold);
            Font rs = new Font("Stencil", 12, System.Drawing.FontStyle.Bold);
            Font fTType = new Font("", 150, System.Drawing.FontStyle.Bold);
            SolidBrush sb = new SolidBrush(System.Drawing.Color.Black);


            g.DrawString(" Motivo de Anulación", rs, sb, 7, 105);
         
            g.DrawString("N°Ticket:", fBody, sb, 25, 125);
            g.DrawString(hth.CODIGO, fBody1, sb, 105, 125);

            g.DrawString("--------------------", fBody1, sb, 7, 160);
            g.DrawString("--------------------", fBody1, sb, 7, 180);
            g.DrawString("--------------------", fBody1, sb, 7, 200);
            g.DrawString("--------------------", fBody1, sb, 7, 220);
            g.DrawString("--------------------", fBody1, sb, 7, 240);
            g.DrawString("--------------------", fBody1, sb, 7, 260);
            g.DrawString("--------------------", fBody1, sb, 7, 280);

            g.DrawString("    -------------------------    ", fBody12, sb, 7, 350-8);
            g.DrawString("        FIRMA DEL CLIENTE        ", fBody12, sb, 2, 360-8);
            g.DrawString(" Se acepta los terminos indicados", fBody12, sb, 2, 376-8);
            g.DrawString(" Num.Emergencias: (+51) 989157166", fBody12, sb, 2, 385-8);

        }
        void pd_PrintPageCOPIA(object sender, PrintPageEventArgs e)
        {
            int SPACE = 105;
            string title = System.Windows.Forms.Application.StartupPath + "\\CBT_Title.png";
            string barcode = System.Windows.Forms.Application.StartupPath + "\\code128bar.jpg";
            Graphics g = e.Graphics;
            g.DrawRectangle(Pens.Black, 1, 5, 188, 390);



            g.DrawImage(System.Drawing.Image.FromFile(title), 37, 6, 120, 120);
            Font fBody = new Font("Lucida Console", 10, System.Drawing.FontStyle.Bold);
            Font fBody1 = new Font("Lucida Console", 10, System.Drawing.FontStyle.Regular);
            Font fBody12 = new Font("Lucida Console", 6, System.Drawing.FontStyle.Bold);
            Font fBody122 = new Font("Lucida Console", 8, System.Drawing.FontStyle.Bold);
            Font rs = new Font("Stencil", 18, System.Drawing.FontStyle.Bold);
            Font fTType = new Font("", 150, System.Drawing.FontStyle.Bold);
            SolidBrush sb = new SolidBrush(System.Drawing.Color.Black);


            g.DrawString("--------------------", fBody1, sb, 7, 130);

            g.DrawString("Fecha:", fBody, sb, 10, SPACE + 10);
            g.DrawString(DateTime.Now.ToShortDateString(), fBody1, sb, 70, SPACE + 10);

            g.DrawString("N°Ticket:", fBody, sb, 10, SPACE + 40);
            g.DrawString(hth.CODIGO, fBody1, sb, 100, SPACE + 40);

            g.DrawString("INICIO:", fBody, sb, 10, SPACE + 70);
            g.DrawString(hth.INICIO, fBody1, sb, 80, SPACE + 70);


            g.DrawString("FIN:", fBody, sb, 10, SPACE + 90);
            g.DrawString(hth.FIN, fBody1, sb, 50, SPACE + 90);

            //g.DrawString("DriverName:", fBody, sb, 10, SPACE+120);
            //g.DrawString(txtDriveName.Text, fBody1, sb, 153, SPACE + 120);

            g.DrawString("LUGAR:", fBody, sb, 10, SPACE + 110);
            g.DrawString(hth.PUNTO, fBody1, sb, 70, SPACE + 110);

            g.DrawString("NOMBRE:", fBody, sb, 10, SPACE + 130);
            g.DrawString(hth.NombreCompleto.Substring(0, 8), fBody1, sb, 80, SPACE + 130);

            g.DrawString("Total." + hth.PAGADO, rs, sb, 9, SPACE + 160);

            g.DrawImage(System.Drawing.Image.FromFile(barcode), 6, SPACE + 190, 180, 40);
            
            g.DrawString("    [COPIA AL CLIENTE]     ", fBody122, sb, 2, SPACE+240);
            g.DrawString(" Se acepta los terminos indicados", fBody12, sb, 2, SPACE+260);
            g.DrawString(" Num.Emergencias: (+51) 989157166", fBody12, sb, 2, SPACE+269);

        }
        void btnPrint_Click()
        {
            PrintDocument pd = new PrintDocument();
            PrintDocument pd2 = new PrintDocument();
            PaperSize ps = new PaperSize("", 590, 590);

            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
            pd2.PrintPage += new PrintPageEventHandler(pd_PrintPageCOPIA);
            pd.PrintController = new StandardPrintController();
            pd.DefaultPageSettings.Margins.Left = 0;
            pd.DefaultPageSettings.Margins.Right = 0;
            pd.DefaultPageSettings.Margins.Top = 0;
            pd.DefaultPageSettings.Margins.Bottom = 0;
            pd2.PrintController = new StandardPrintController();
            pd2.DefaultPageSettings.Margins.Left = 0;
            pd2.DefaultPageSettings.Margins.Right = 0;
            pd2.DefaultPageSettings.Margins.Top = 0;
            pd2.DefaultPageSettings.Margins.Bottom = 0;
            pd2.DefaultPageSettings.PaperSize = ps;
            try
            {
                pd.Print();
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));
                pd2.Print();
            }
            catch
            {
                MessageBox.Show("Error en la Cola de Impresion");
            }
        }
        void btnPrint_ClickAnulacion()
        {
            PrintDocument pd = new PrintDocument();
            PrintDocument pd2 = new PrintDocument();
            PaperSize ps = new PaperSize("", 590, 590);

            pd.PrintPage += new PrintPageEventHandler(pd_PrintPageAnulacion);
            pd.PrintController = new StandardPrintController();
            pd.DefaultPageSettings.Margins.Left = 0;
            pd.DefaultPageSettings.Margins.Right = 0;
            pd.DefaultPageSettings.Margins.Top = 0;
            pd.DefaultPageSettings.Margins.Bottom = 0;
          
            try
            {
                pd.Print();
            }
            catch
            {
                MessageBox.Show("Error en la Cola de Impresion");
            }
        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dtCLiente.SelectedItem !=null)
            {
                eAlquiler g = dtCLiente.SelectedItem as eAlquiler;
                try {
                    MessageBoxResult result = MessageBox.Show("¿Esta seguro desea anular el alquiler de: " + g.NombreCompleto + "?", "Anular Contrato", MessageBoxButton.YesNo, MessageBoxImage.Stop);
                    if (result == MessageBoxResult.Yes && g.NUMERO!=null &&g.NUMERO!="")
                {
                        Espera();
                        alquiler.EliminarAlquiler(g);
                        btnPrint_ClickAnulacion();
                        Limpiar();
                  /*  int h = Convert.ToInt32(g.FIN.Remove(g.FIN.Length - 3, 1)) + 20;
                    int t = Convert.ToInt32(DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString());
                    if (h > t)
                    {
                    }
                        else
                        {
                            MessageBox.Show("Agregar el sobreTIME del cliente");
                        }
                  */
                }

            else
            {
                MessageBox.Show("Debe selecionar primero a un cliente que ya finalizo su alquiler");
            }
            }
            catch
            {
                    MessageBox.Show("Debe selecionar primero a un cliente que ya finalizo su alquiler");
            }

            }
        }

        private void Registrar_Click(object sender, RoutedEventArgs e)
        {
            if (Verificador())
            {
                Espera();
                eAlquiler c;
                if (DateTime.Now.Minute >= 10)
                {
                    string y = Convert.ToDateTime(DateTime.Now.Hour +":"+ DateTime.Now.Minute).AddMinutes(7).ToShortTimeString();
                    string h = y.Substring(0, y.Length - 3);
                    c = new eAlquiler
                    {
                        NUMERO = NUMERO.Text.ToUpper(),
                        INICIO = (Convert.ToDateTime(DateTime.Now.Hour + ":" + (DateTime.Now.Minute)).AddMinutes(7)).ToShortTimeString().ToString(),
                        PUNTO = PUNTO.Text.ToUpper(),
                        NombreCompleto = Nombre.Text.ToUpper(),
                        BIKE = (CANTBICI.Text),
                        DOCUMENTO = Documento.Text,
                        PAGADO = "S/" + Abono.Text + ".00",
                        TELEFONO = (TELEFONO.Text),
                        TIME = (TIEMPOALQUI.Text),
                        FECHA = DateTime.Now.ToShortDateString()
                    };
                    if (y.Length == 5)
                    {
                        c.FIN = Convert.ToDateTime(c.INICIO).AddHours(Convert.ToInt32(c.TIME)).ToShortTimeString();
                        
                    }
                    if (y.Length == 4)
                    {
                        c.FIN = Convert.ToDateTime(c.INICIO).AddHours(Convert.ToInt32(c.TIME)).ToShortTimeString();

                    }
                }

                
                else
                {
                    string y = Convert.ToDateTime(DateTime.Now.Hour + ":0" + DateTime.Now.Minute).AddMinutes(7).ToShortTimeString();
                    string h = y.Substring(0, y.Length - 3);
                    c = new eAlquiler
                    {

                        NUMERO = NUMERO.Text.ToUpper(),
                        INICIO = (Convert.ToDateTime(DateTime.Now.Hour + ":" + (DateTime.Now.Minute)).AddMinutes(7)).ToShortTimeString().ToString(),
                        PUNTO = PUNTO.Text.ToUpper(),
                        NombreCompleto = Nombre.Text.ToUpper(),
                        BIKE = (CANTBICI.Text),
                        DOCUMENTO = Documento.Text,
                        PAGADO = "S/" + Abono.Text + ".00",
                        TELEFONO = (TELEFONO.Text),
                        TIME = (TIEMPOALQUI.Text),
                        FECHA = DateTime.Now.ToShortDateString()
                    };
                if (y.Length == 5)
                {
                    c.FIN = Convert.ToString(Convert.ToInt32(h) + Convert.ToInt32(c.TIME)) + ":" + c.INICIO.Substring(c.INICIO.Length - 2, c.INICIO.Length - 3);

                }
                if (y.Length == 4)
                {
                    c.FIN = Convert.ToString(Convert.ToInt32(h) + Convert.ToInt32(c.TIME)) + ":" + c.INICIO.Substring(c.INICIO.Length - 2, c.INICIO.Length - 2);
                }
                }
                if (alquiler.RegistrarAlquiler(c)!=null)
                {
                    Espera();
                    alquiler.RegistrarAlquiler(c);
                    hth = c;
                    btnPrint_Click();


                    Limpiar();
                }
                else
                {
                    MessageBox.Show("Ya se tiene registrado a un Alquiler registrado con ese Numero de Documento");
                    Volver();
                }
            }
            else
            {
                MessageBox.Show("Llene todos los campos porfavor");
                Volver();
            }
        }

        private void NUMERO_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Enter || e.Key == Key.Tab)
            {

                var gt = to.ExisteCliente(Documento.Text, NUMERO.Text);
                if (gt!=null)
                {
                    Nombre.Text = gt.NombreCompleto;
                    TELEFONO.Text = gt.TELEFONO.ToString();

                }
                else
                {
                    if (Documento.Text == "DNI")
                    {

                        if (NUMERO.Text.Length == 8)
                        {
                            if (Int64.TryParse(NUMERO.Text, out long g))
                            {
                                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://aplicaciones007.jne.gob.pe/srop_publico/Consulta/Afiliado/GetNombresCiudadano?DNI=" + NUMERO.Text);
                                request.Method = WebRequestMethods.Http.Get;
                                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                                try
                                {
                                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                                    using (Stream stream = response.GetResponseStream())
                                    using (StreamReader reader = new StreamReader(stream))
                                    {
                                        Nombre.Text = reader.ReadToEnd().Replace("|", " ");
                                    }


                                }
                                catch (Exception)
                                {
                                    NUMERO.Clear();
                                    MessageBox.Show("DNI INVALIDO | DNI NO EXISTENTE");
                                }
                            }
                        }
                    }

                }
            }
        }

        private void ExportToExcelAndCsv()
        {
            dtCLiente.SelectAllCells();
            dtCLiente.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, dtCLiente);
            String resultat = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
            String result = (string)Clipboard.GetData(DataFormats.Text);
            dtCLiente.UnselectAllCells();

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Execl files (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.FileName = DateTime.Now.ToLongDateString();
            saveFileDialog.Title = "Save path of the file to be exported";       
            if (saveFileDialog.ShowDialog()==true ) { 
            System.IO.StreamWriter file1 = new System.IO.StreamWriter(saveFileDialog.FileName);
            file1.WriteLine(result.Replace(',', ' '));
            file1.Close();
                
            MessageBox.Show("Se creo el archivo de los alquileres del: " +DateTime.Now.ToShortDateString(),"Guardado Exitoso",MessageBoxButton.OK,MessageBoxImage.Information);
            }
            else
            {
                
            }

        }

        public hojaAlquiler()
        {
          
            InitializeComponent();
            dtCLiente.Items.Clear();

        
        }
        private void Espera()
        {
            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
            Registrar_Copy.IsEnabled = false;
            Mofica.IsEnabled = false;
            
            Eliminar.IsEnabled = false;
        }
        private void Volver()
        {
            Mouse.OverrideCursor = null;
            Registrar_Copy.IsEnabled = true;
            Mofica.IsEnabled = true;
            Eliminar.IsEnabled = true;
        }
        private void Limpiar()
        {
            Abono.Clear();
            Documento.Text="DNI";
            Nombre.Clear(); TELEFONO.Clear(); PUNTO.Text = hu;
            NUMERO.Clear(); CANTBICI.SelectedIndex = -1;  TIEMPOALQUI.SelectedIndex = -1;
            dtCLiente.ItemsSource = alquiler.ListarCliente(hu).OrderBy(k => Convert.ToDateTime(k.FECHA)).Where(K => Convert.ToDateTime(K.FECHA) > DateTime.Now.AddDays(-7));
            Volver();
        }
        private bool Verificador()
        {
            if (Nombre.Text.Length > 0 && PUNTO.Text != "" && TELEFONO.Text.Length > 0 && NUMERO.Text.Length > 0
                && CANTBICI.Text != "" && Abono.Text != "" && Documento.Text != "")
            {
                return true;
            }
            else
                return false;
        }
        private void Modificar(object sender, RoutedEventArgs e)
        {
            if (dtCLiente.SelectedItem != null)
            {
                eAlquiler m = dtCLiente.SelectedItem as eAlquiler;
                if (Verificador())
                {
                    MessageBoxResult result = MessageBox.Show("¿Esta seguro que " + m.NombreCompleto + " devolvio todo lo rentado?", "Completar alquiler", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                    
                    try
                    {
                        Espera();
                        alquiler.ModificarAlquiler(m);
                            //  Impresion.Imprimir(c);//
                            //System.Threading.Thread.Sleep(5000);
                            //Impresion.Imprimir(c);
                            Limpiar();
                            Limpiar();
                        }
                        catch
                    {
                        MessageBox.Show("No existe un cliente con esos datos para modificar");
                            Limpiar();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Llene todos los campos porfavor");
                }

                }
                    else
                        MessageBox.Show("Debe seleccionar un Cliente");

              
            
        }

        private void dtCLiente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtCLiente.SelectedItem != null)
            {
                eAlquiler h = dtCLiente.SelectedItem as eAlquiler;
                if (h != null&&h.DOCUMENTO!=""&& h.PAGADO!=null)
                {
              
                    Documento.Text = h.DOCUMENTO;
                    Nombre.Text = h.NombreCompleto; TELEFONO.Text = h.TELEFONO.ToString();
                    Abono.Text = h.PAGADO.ToString().Substring(2, h.PAGADO.ToString().Length - 5);
                    NUMERO.Text = h.NUMERO;
                    CANTBICI.Text = Convert.ToString(h.BIKE);
                    TIEMPOALQUI.Text = Convert.ToString(h.TIME);
                    PUNTO.Text = h.PUNTO;
               
                }
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
            Nombre.Text = "  ------------------------------------------------------";
            
            if (Login.n.Cargo=="CAMPO MARTE")
            {
                PUNTO.Text = "CAMPO MARTE";
                PUNTO.IsEditable = false;
                PUNTO.IsEnabled = false;
            dtCLiente.ItemsSource = alquiler.ListarCliente("CAMPO MARTE").OrderBy(k => Convert.ToDateTime(k.FECHA)).Where(K => Convert.ToDateTime(K.FECHA) > DateTime.Now.AddDays(-7));
                hu = "CAMPO MARTE";
                }
             else   if (Login.n.Cargo == "SALAVERRY")
            {
                PUNTO.Text = "SALAVERRY";
                PUNTO.IsEditable = false;
                PUNTO.IsEnabled = false;
                dtCLiente.ItemsSource = alquiler.ListarCliente("SALAVERRY").OrderBy(k => Convert.ToDateTime(k.FECHA)).Where(K => Convert.ToDateTime(K.FECHA) > DateTime.Now.AddDays(-7));
                hu = "SALAVERRY";
            }
            else if (Login.n.Cargo.ToUpper() == "LARCOBIKE")
            {
                PUNTO.Text = "LARCO";
                PUNTO.IsEditable = false;
                PUNTO.IsEnabled = false;
                dtCLiente.ItemsSource = alquiler.ListarCliente("LARCO").OrderBy(k => Convert.ToDateTime(k.FECHA)).Where(K => Convert.ToDateTime(K.FECHA) > DateTime.Now.AddDays(-7));
                hu = "LARCO";
            }
            else
            {
                dtCLiente.ItemsSource = alquiler.ListarCliente("").OrderBy(k => Convert.ToDateTime(k.FECHA)).Where(K => Convert.ToDateTime(K.FECHA) > DateTime.Now.AddDays(-7));
                hu = "";
            }
        }


        private void Documento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(Documento.Text=="DNI")
            {
                NUMERO.MaxLength = 8;
                TELEFONO.MaxLength = 9;
            }
            else
            {
                NUMERO.MaxLength = 15;
                TELEFONO.MaxLength = 15;
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Documento.Text = "DNI";
            DispatcherTimer dispathcer = new DispatcherTimer();
            dispathcer.Interval = new TimeSpan(0, 0, 1);
            dispathcer.Tick += (s, a) =>
            {
                Tiem.Content ="TIEMPO: "+ DateTime.Now.ToLongTimeString();
                
            };
            dispathcer.Start();
        }

        private void Exportar(object sender, RoutedEventArgs e)
        {
            ExportToExcelAndCsv();
        }

        private void Actualizar_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            Espera();
            Limpiar();
        }

        private void ExportarExcel_Copy_Click(object sender, RoutedEventArgs e)
        {
            Espera();
            Limpiar();
        }

        private void TELEFONO_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Tab)
            {
                Abono.Focus();
            }
        }

        private void TELEFONO_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Documento.Text == "DNI")
            {
                NUMERO.MaxLength = 8;
                TELEFONO.MaxLength = 9;
            }
            else
            {
                NUMERO.MaxLength = 15;
                TELEFONO.MaxLength = 15;
            }
        }

        private void NUMERO_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Documento.Text == "DNI")
            {
                NUMERO.MaxLength = 8;
                TELEFONO.MaxLength = 9;
            }
            else
            {
                NUMERO.MaxLength = 15;
                TELEFONO.MaxLength = 15;
            }
        }
    }
}
