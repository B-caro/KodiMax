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
        private bool contratado = false;

        public Empleados() { }

        public Empleados(int id, string telefono, string dui, string nit, string cargo)
        {
            this.Id = id;
            this.Telefono = telefono;
            this.Dui = dui;
            this.Nit = nit;
            this.Cargo = cargo;
        }

        public int Id { get => id; set => id = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Dui { get => dui; set => dui = value; }
        public string Nit { get => nit; set => nit = value; }
        public string Cargo { get => cargo; set => cargo = value; }

        public void Contratar()
        {
            Random random = new Random();
            if (random.Next(0, 1) == 1)
            {
                contratado = true;
            }
            else
            {
                contratado = false;
            }
        }
    }
}
