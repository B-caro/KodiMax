using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiMax.Clases
{
    class Ticket
    {
        private string encabezado;
        private int idFactura;
        private DateTime fechaCompra;
        private string pelicula;
        private string tipoSala;
        private ArrayList fila;
        private ArrayList asiento;
        private float precioUnitario;
        private float total;
        private string tipoPago;
        private float cambio;
        private string atendidoPor;

        public Ticket() { }

        public Ticket(string encabezado, int idFactura, DateTime fechaCompra, string pelicula, string tipoSala, ArrayList fila, 
            ArrayList asiento, float precioUnitario, float total, string tipoPago, float cambio, string atendidoPor)
        {
            this.encabezado = encabezado;
            this.idFactura = idFactura;
            this.fechaCompra = fechaCompra;
            this.pelicula = pelicula;
            this.tipoSala = tipoSala;
            this.fila = fila;
            this.asiento = asiento;
            this.precioUnitario = precioUnitario;
            this.total = total;
            this.tipoPago = tipoPago;
            this.cambio = cambio;
            this.atendidoPor = atendidoPor;
        }

        public string Encabezado { get => encabezado; set => encabezado = value; }
        public int IdFactura { get => idFactura; set => idFactura = value; }
        public DateTime FechaCompra { get => fechaCompra; set => fechaCompra = value; }
        public string Pelicula { get => pelicula; set => pelicula = value; }
        public string TipoSala { get => tipoSala; set => tipoSala = value; }
        public ArrayList Fila { get => fila; set => fila = value; }
        public ArrayList Asiento { get => asiento; set => asiento = value; }
        public float PrecioUnitario { get => precioUnitario; set => precioUnitario = value; }
        public float Total { get => total; set => total = value; }
        public string TipoPago { get => tipoPago; set => tipoPago = value; }
        public float Cambio { get => cambio; set => cambio = value; }
        public string AtendidoPor { get => atendidoPor; set => atendidoPor = value; }


    }
}
