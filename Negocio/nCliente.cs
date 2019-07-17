using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;

namespace Negocio
{
    public class nCliente
    {
        private dCliente o= new dCliente();
        public eClientes ExisteCliente(string h, string n) {
            if ( o.ExisteClinte(h,n)==null)
            {
                return null;
            }
            else
                return o.ExisteClinte(h,n); }
        public List<eClientes> Listar()
        {
            return o.ListarCleintes();
        }
    }
}
