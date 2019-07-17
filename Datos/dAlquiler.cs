using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Firebase.Database;
using Firebase.Database.Query;
using System.Reactive.Threading;
using System.Reactive.Linq;

namespace Datos
{
    public class dAlquiler
    {
       public Conexion FB = new Conexion();
        dCliente w = new dCliente();
        public string RegistrarAlquiler(eAlquiler h)
        {
            h.ESTADO = "EN ALQUILER";
            string sede;
            if (h.PUNTO== "LARCO")
            {
                sede = "Larcobike";
            }
            else if(h.PUNTO== "SALAVERRY")
            {
                sede = "Salaverry";
            }
            else
            {
                sede = "Campo Marte";
            }
            var observable2 = FB.BaseDatos().Child("NumContratos").OnceAsync<eContrato>().Result.ToList();
            try
            {
                FB.BaseDatos().Child("Alquileres").OnceAsync<eAlquiler>().Result.ToList();
                var observable = FB.BaseDatos().Child("Alquileres").OnceAsync<eAlquiler>().Result.ToList();
                if (!observable.Exists(k => k.Object.NUMERO == h.NUMERO && k.Object.DOCUMENTO == h.DOCUMENTO && k.Object.FECHA== h.FECHA&& k.Object.ESTADO==h.ESTADO))
            {
                    var to = observable2.Find(k => k.Object.Sede == sede);
                    h.CODIGO = to.Object.Numeracion;
                    var ko = (Convert.ToInt64(to.Object.Numeracion)+1).ToString();
                    while(ko.Length <6)
                    {
                        ko = "0" + ko;
                    }
                    to.Object.Numeracion = ko;
                    FB.BaseDatos().Child("Alquileres").PostAsync(h);
                    FB.BaseDatos().Child("NumContratos").Child(to.Key).PutAsync(to.Object);

                    return "Registro de " + h.NombreCompleto + " exitoso";
            }
            else
            {
                return null;
            }
            }
            catch
            {

                var to = observable2.Find(k => k.Object.Sede == sede);
                h.CODIGO = to.Object.Numeracion;
                var ko = (Convert.ToInt64(to.Object.Numeracion) + 1).ToString();
                while (ko.Length < 6)
                {
                    ko = "0" + ko;
                }
                to.Object.Numeracion = ko;
                FB.BaseDatos().Child("Alquileres").PostAsync(h);
                FB.BaseDatos().Child("NumContratos").Child(to.Key).PutAsync(to.Object);
                return "Registro de " + h.NombreCompleto + " exitoso";
            }
        }

      

        public string EliminarAlquiler(eAlquiler h)
        {
            var observable = FB.BaseDatos().Child("Alquileres").OnceAsync<eAlquiler>().Result.ToList();
            var o = observable.Find(k => k.Object.NUMERO == h.NUMERO && k.Object.DOCUMENTO == h.DOCUMENTO&&k.Object.FECHA==h.FECHA&&k.Object.INICIO==h.INICIO);
            if(o!=null)
            {
                eClientes n = new eClientes();
                n.DOCUMENTO = h.DOCUMENTO; n.FRECUENCIA = 0; n.NombreCompleto = h.NombreCompleto;  n.NUMERO = h.NUMERO; n.PUNTOS = h.PAGADO;
                try
                {

                n.TELEFONO = Convert.ToInt64(h.TELEFONO);
                }
                catch 
                {
                    n.TELEFONO = 0;
                }
                w.RegistrarCliente(n);
                o.Object.ESTADO = "DEVUELTO";
                FB.BaseDatos().Child("Alquileres").Child(o.Key).PutAsync(o.Object);

                return "Eliminado";
            }
            else
            {
                return null;
            }
        }
        public string ModificarAlquiler(eAlquiler h)
        {
            var observable = FB.BaseDatos().Child("Alquileres").OnceAsync<eAlquiler>().Result.ToList();
         
            var o = observable.Find(k => k.Object.NUMERO == h.NUMERO && k.Object.DOCUMENTO == h.DOCUMENTO&& k.Object.FECHA==h.FECHA && k.Object.INICIO == h.INICIO);
            if (o != null)
            {
                eAnulacion ka = new eAnulacion { Dia=DateTime.Now.ToShortDateString(), NumContrato=h.CODIGO, Sede=h.PUNTO  };
                FB.BaseDatos().Child("Anulaciones").PostAsync(ka);
                FB.BaseDatos().Child("Alquileres").Child(o.Key).DeleteAsync();
                return "Modificado";
            }
            else
            {
                return null;
            }
        }
        public List<eAnulacion> Anulaciones()
        {
            List<eAnulacion> ah = new List<eAnulacion>();
            var observable = FB.BaseDatos().Child("Anulaciones").OnceAsync<eAnulacion>().Result.ToList();
            foreach (var item in observable)
            {
                    ah.Add(item.Object);
            }
            return ah;
        }
        public List<eAlquiler> ListarCliente(string h)
        {
            List<eAlquiler> ah = new List<eAlquiler>();
            if (h != "") {
                var observable = FB.BaseDatos().Child("Alquileres").OnceAsync<eAlquiler>().Result.ToList();
                foreach (var item in observable)
                {
                    if (item.Object.PUNTO==h) { 
                    ah.Add(item.Object);
                    }
                }
                return ah;
            }
            else
            {
                var observable = FB.BaseDatos().Child("Alquileres").OnceAsync<eAlquiler>().Result.ToList();
                foreach (var item in observable)
                {
                    ah.Add(item.Object);
                }
                return ah;
            }
        }
       



    }
}
