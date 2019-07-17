using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Login
    {
        static public UsuarioControl n;
        public void Ok(UsuarioControl a)
        { n = a; }
        public UsuarioControl getUsuario()
        {
            return n;
        }
    }
}
