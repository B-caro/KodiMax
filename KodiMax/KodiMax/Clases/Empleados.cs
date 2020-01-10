using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiMax.Clases
{
    class Empleados : Usuarios
    {
        private int id;
        private string telefono;
        private string dui;
        private string nit;
        private string cargo;
        private bool contratado;

        public Empleados():base() { } 

        public Empleados(int id, string nombres, string apellidos, string email, DateTime fechaNacimiento, string nombreUsuario, 
            string password, string telefono, string dui, string nit, string cargo):base(nombres, apellidos, email, fechaNacimiento, nombreUsuario, password)
        {
            this.Id = id;
            this.Telefono = telefono;
            this.Dui = dui;
            this.Nit = nit;
            this.Cargo = cargo;
            this.Contratado = true;
        }

        public int Id { get => id; set => id = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Dui { get => dui; set => dui = value; }
        public string Nit { get => nit; set => nit = value; }
        public string Cargo { get => cargo; set => cargo = value; }
        public bool Contratado { get => contratado; set => contratado = value; }

        public override bool State()
        {
            return this.Contratado;
        }

        public override int ShowData()
        {
            Console.WriteLine("\n Nombre: {0} {1}", this.Nombres, this.Apellidos);
            Console.WriteLine("\n Dui: {0}", this.Dui);
            Console.WriteLine("\n Nit: {0}", this.Nit);
            Console.WriteLine("\n Telefono: {0}", this.Telefono);
            Console.WriteLine("\n Cargo: {0}", this.Cargo);
            Console.WriteLine("\n ID: {0}", this.Id);
            return 0;
        }
    }
}
