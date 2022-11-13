using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    internal class Estudiante
    {
        public string Dni { get; set; }
        public string Nombre { get; set; }

        public string Apellido { get; set; }
        public string Email { get; set; }
        public string ImageLocation { get; set; }

        public Estudiante(string dni , string nombre , string apellido , 
            string email , string imageLocation
            )
        {

            Dni = dni;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            ImageLocation = imageLocation;
                
        }


    }
}
