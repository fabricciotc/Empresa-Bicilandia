using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocio
{
    public class nAlquiler
    {
     public   dAlquiler a = new dAlquiler();

        public string ModificarAlquiler(eAlquiler e) {
            return a.EliminarAlquiler(e);
        }
        public string RegistrarAlquiler(eAlquiler e)
        {
            return a.RegistrarAlquiler(e);
        }
        public string EliminarAlquiler(eAlquiler e)
        {
            return a.ModificarAlquiler(e);
        }
        public List<eAlquiler> ListarCliente(string sede)
        {
            return a.ListarCliente(sede);
        }
        public List<eAnulacion> ListarAnulaciones()
        {
            return a.Anulaciones();
        }
    }
}





