using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiMax.Clases
{
    class Peliculas
    {
        private int id;
        private string nombre;
        private string duracion;
        private ArrayList actores;
        private string clasificacion;

        public Peliculas() { }

        public Peliculas(int id, string nombre, string duracion, ArrayList actores, string clasificacion)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Duracion = duracion;
            this.Actores = actores;
            this.Clasificacion = clasificacion;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Duracion { get => duracion; set => duracion = value; }
        public ArrayList Actores { get => actores; set => actores = value; }
        public string Clasificacion { get => clasificacion; set => clasificacion = value; }
    }
}
