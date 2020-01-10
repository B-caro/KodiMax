using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiMax.Clases
{
    class Usuarios
    {
        private string nombres;
        private string apellidos;
        private string email;
        private DateTime fechaNacimiento;
        private string nombreUsuario;
        private string password;

        public Usuarios()
        {

        }

        public Usuarios(string nombres, string apellidos, string email, DateTime fechaNacimiento, string nombreUsuario, string password)
        {
            this.Nombres = nombres;
            this.Apellidos = apellidos;
            this.Email = email;
            this.FechaNacimiento = fechaNacimiento;
            this.NombreUsuario = nombreUsuario;
            this.Password = password;
        }

        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Email { get => email; set => email = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string Password { get => password; set => password = value; }
    }
}
