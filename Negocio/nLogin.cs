using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocio
{
    public class nLogin
    {
        dLogeo a = new dLogeo();
        public bool Logear(string x, string c)
        {
            return a.Logeo(x, c);
        }
    }
}
