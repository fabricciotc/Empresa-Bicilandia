using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;


namespace Datos
{
    public class dLogeo
    {
        Conexion x = new Conexion();

        public bool Logeo(string user, string pass)
        {
            try { 
            if (x.BaseDatos().Child("Usuarios").OnceAsync<UsuarioControl>().Result.ToList().Exists(k =>k.Object.Contaseña==pass&&k.Object.Usuario==user))
            {
                var g = x.BaseDatos().Child("Usuarios").OnceAsync<UsuarioControl>().Result.ToList().Find(k => k.Object.Contaseña == pass && k.Object.Usuario == user);
                Login.n = new UsuarioControl();
                Login.n.Cargo = g.Object.Cargo;
                Login.n.Contaseña = g.Object.Contaseña;
                Login.n.linkfoto = g.Object.linkfoto;
                Login.n.Usuario = g.Object.Usuario;
                Login.n.Nombre = g.Object.Nombre;


                return true;
            }
            else
            {
                return false;
            }
            }
            catch {
                MessageBox.Show("Error en conexion al servidor");
                return false;}
        }
    }
}
