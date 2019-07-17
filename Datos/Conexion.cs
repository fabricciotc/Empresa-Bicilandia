using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;

namespace Datos
{
    public class Conexion
    {
        public FirebaseClient Asd;
        private FirebaseClient f()
        {
            try
            {
                    Asd = new FirebaseClient(
                    "https://bicilandia-peru.firebaseio.com/",
                    new FirebaseOptions
                    {
                        AuthTokenAsyncFactory = () => Task.FromResult("WzjI55uxAsQyzo2rVLX7AUIowRqMbOEoWmLl1UR1")

                    }); 
                    return Asd;
            }
            catch (Exception)
            {

                return null;
            }
    
        }
        public FirebaseClient BaseDatos()
        {
            return f();         
        }

    }
}
