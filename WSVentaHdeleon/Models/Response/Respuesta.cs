using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSVentaHdeleon.Models.Response
{
    public class Respuesta
    {
        public int Exito { get; set; }
        public string Mensaje { get; set; }
        public object Data { get; set; }

        public Respuesta()
        {
            Exito = 0;
            this.Mensaje = "Bad";
        }
        public void Ok(object data = null, string mensaje = "Ok")
        {
            this.Exito = 1;
            this.Mensaje = mensaje;
            if (data != null)
            {
                this.Data = data;
            }
        }

        public void Bad(string mensaje = "Bad")
        {
            Exito = 0;
            Mensaje = mensaje;
        }
    }


}
