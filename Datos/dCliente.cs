using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Firebase.Database.Query;

namespace Datos
{
    public  class dCliente
    {
        Conexion FB = new Conexion();
        public string RegistrarCliente(eClientes d)
        {
            var observable = FB.BaseDatos().Child("baseClientes").OnceAsync<eClientes>().Result.ToList();
            if (!observable.Exists(k => k.Object.NUMERO == d.NUMERO && k.Object.DOCUMENTO == d.DOCUMENTO))
            {
                FB.BaseDatos().Child("baseClientes").PostAsync(d);
                return "Registro de " + d.NombreCompleto + " exitoso";
            }
            else
            {
                var t = observable.Find(k => k.Object.NUMERO == d.NUMERO && k.Object.DOCUMENTO == d.DOCUMENTO);
                t.Object.PUNTOS = Convert.ToString(Convert.ToDouble(t.Object.PUNTOS.Substring(2, t.Object.PUNTOS.Length - 3)) + Convert.ToDouble(d.PUNTOS.Substring(2, d.PUNTOS.Length - 3)));
                t.Object.PUNTOS = "S/" + t.Object.PUNTOS + ".00";
                t.Object.FRECUENCIA = t.Object.FRECUENCIA + 1;
                FB.BaseDatos().Child("baseClientes").Child(t.Key).PutAsync(t.Object);
                return "Cliente ya existe";
            }
        }
        public eClientes ExisteClinte(string h, string n)
        {
            var observable = FB.BaseDatos().Child("baseClientes").OnceAsync<eClientes>().Result.ToList();
            if (observable.Exists(k => k.Object.NUMERO == n && k.Object.DOCUMENTO == h))
            {
                var t = observable.Find(k => k.Object.NUMERO == n && k.Object.DOCUMENTO == h);
                return t.Object;
            }
            else
            {
                return null;
            }

        }
        public List<eClientes> ListarCleintes()
        {
            List<eClientes> j = new List<eClientes>();
           var observable = FB.BaseDatos().Child("baseClientes").OnceAsync<eClientes>().Result.ToList();
            foreach (var item in observable)
            {
                j.Add(item.Object);
            }
            if(j.Count <=0)
            {
                return null;
            }
            else
            {
                return j;
            }
           
        }
    }
}
